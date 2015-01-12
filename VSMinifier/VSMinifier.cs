using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using EnvDTE;
using EnvDTE80;
using Microsoft.Ajax.Utilities;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using VSLangProj80;
using Yahoo.Yui.Compressor;

namespace VSMinifier
{
	[Guid( Consts.GUID )]
	[CodeGeneratorRegistration( typeof( VSMinifier ), Consts.Me, vsContextGuids.vsContextGuidVCSProject )]
	[CodeGeneratorRegistration( typeof( VSMinifier ), Consts.Me, vsContextGuids.vsContextGuidVBProject )]
	[ProvideObject( typeof( VSMinifier ) )]
	[ProvideOptionPage( typeof( OptionPage ), "Custom Tools", Consts.Me, 0, 0, true )]
	[ProvideMenuResource( "VSCT", 1 )]
	[InstalledProductRegistration( "#4001", "#4002", "1.13.1", IconResourceID = 4000 )]
	public sealed class VSMinifier : Package, IVsSingleFileGenerator
	{
		#region Properties

		private string _Ext;

		#region Application

		private EnvDTE80.DTE2 _Application;

		public EnvDTE80.DTE2 Application
		{
			get
			{
				if ( _Application == null )
				{
					_Application = ( EnvDTE80.DTE2 )Package.GetGlobalService( typeof( EnvDTE.DTE ) );
				}

				return ( _Application );
			}
		}

		#endregion

		#region ProjectItem

		public EnvDTE.ProjectItem ProjectItem
		{
			get
			{
				return ( Application.SelectedItems.Item( 1 ).ProjectItem );
			}
		}

		#endregion

		#region ServiceProvider

		private System.IServiceProvider _ServiceProvider;

		public System.IServiceProvider ServiceProvider
		{
			get
			{
				if ( _ServiceProvider == null )
				{
					_ServiceProvider = new Microsoft.VisualStudio.Shell.ServiceProvider( ( Microsoft.VisualStudio.OLE.Interop.IServiceProvider )Application );
				}

				return ( _ServiceProvider );
			}
		}

		#endregion

		#region BuildProject

		private Microsoft.Build.Evaluation.Project _BuildProject;

		public Microsoft.Build.Evaluation.Project BuildProject
		{
			get
			{
				if ( _BuildProject == null )
				{
					_BuildProject = Microsoft.Build.Evaluation.ProjectCollection.GlobalProjectCollection.GetLoadedProjects( ProjectItem.ContainingProject.FullName ).SingleOrDefault( );
				}

				return ( _BuildProject );
			}
		}
		#endregion

		#region ProjectGUID

		private Microsoft.Build.Evaluation.ProjectProperty _ProjectGUID;

		Microsoft.Build.Evaluation.ProjectProperty ProjectGUID
		{
			get
			{
				if ( _ProjectGUID == null )
				{
					_ProjectGUID = BuildProject.AllEvaluatedProperties.SingleOrDefault( oProperty => oProperty.Name == "ProjectGuid" );
				}

				return ( _ProjectGUID );
			}
		}

		#endregion

		#region ProjectName

		private Microsoft.Build.Evaluation.ProjectProperty _ProjectName;

		Microsoft.Build.Evaluation.ProjectProperty ProjectName
		{
			get
			{
				if ( _ProjectName == null )
				{
					_ProjectName = BuildProject.AllEvaluatedProperties.SingleOrDefault( oProperty => oProperty.Name == "ProjectName" );
				}

				return ( _ProjectName );
			}
		}

		#endregion

		#region VsHierarchy

		private Microsoft.VisualStudio.Shell.Interop.IVsHierarchy _VsHierarchy;

		public Microsoft.VisualStudio.Shell.Interop.IVsHierarchy VsHierarchy
		{
			get
			{
				if ( _VsHierarchy == null )
				{
					_VsHierarchy = VsShellUtilities.GetHierarchy( ServiceProvider, new Guid( ProjectGUID.EvaluatedValue ) );
				}

				return ( _VsHierarchy );
			}

		}

		#endregion

		#region VsProject

		public Microsoft.VisualStudio.Shell.Interop.IVsProject VsProject
		{
			get
			{
				return ( ( IVsProject )VsHierarchy );
			}
		}

		#endregion

		#region VsBuildPropertyStorage

		public Microsoft.VisualStudio.Shell.Interop.IVsBuildPropertyStorage VsBuildPropertyStorage
		{
			get
			{
				return ( ( Microsoft.VisualStudio.Shell.Interop.IVsBuildPropertyStorage )VsHierarchy );
			}
		}

		#endregion

		#region OptionPage

		private OptionPage _OptionPage;

		public OptionPage OptionPage
		{
			get
			{
				if ( _OptionPage == null )
				{
					_OptionPage = new OptionPage( );
					PropertyInfo[ ] oPropertyInfoArray = _OptionPage.GetType( ).GetProperties( );
					Properties oProperties = Application.get_Properties( "Custom Tools", Consts.Me );

					foreach ( PropertyInfo oPropertyInfo in oPropertyInfoArray )
					{
						if ( oPropertyInfo.ReflectedType == oPropertyInfo.DeclaringType )
						{
							oPropertyInfo.SetValue( _OptionPage, oProperties.Item( oPropertyInfo.Name ).Value, null );
						}
					}
				}

				return ( _OptionPage );
			}
		}

		#endregion

		#endregion

		#region Helpers

		private Microsoft.Build.Evaluation.ProjectItem GetProjectItem ( string ItemPath )
		{
			return ( BuildProject.ItemsIgnoringCondition.Where( item => item.EvaluatedInclude.EndsWith( Path.GetFileName( ItemPath ) ) ).Single( ) );
		}

		private uint GetProjectItemId ( string ItemPath )
		{
			uint nID;

			VsHierarchy.ParseCanonicalName( ItemPath, out nID );

			return ( nID );
		}

		private byte[ ] GenerateCode ( string InputFileContent, string InputFilePath, IVsGeneratorProgress GenerateProgress )
		{
			bool bDo = false;
			string OutputFileContent = InputFileContent;
			string[ ] szFiles;
			string szInputContent = string.Empty;
			string szOutputContent = string.Empty;

			_Ext = Path.GetExtension( InputFilePath );

			if ( _Ext.Equals( Consts.CSSExt ) )
			{
				_Ext = OptionPage.CSSExt;
				bDo = true;
			}

			if ( _Ext.Equals( Consts.JSExt ) )
			{
				_Ext = OptionPage.JSExt;
				bDo = true;
			}

			if ( bDo )
			{
				if ( InputFileContent.StartsWith( "// FILE LIST" ) )
				{
					szFiles = GetFileList( InputFileContent );
				}
				else
				{
					szFiles = new string[ ] { string.Empty };
				}

				foreach ( string szFile in szFiles )
				{
					if ( szFile == string.Empty )
					{
						szInputContent = InputFileContent;
					}
					else
					{
						string szPath = Path.Combine( Path.GetDirectoryName( InputFilePath ), szFile.Replace( "//", string.Empty ).Trim( ) );

						szInputContent = File.ReadAllText( szPath );
					}

					if ( _Ext == OptionPage.JSExt )
					{
						switch ( OptionPage.JSEngine )
						{
							case JSEngineType.MicrosoftAjaxMinifier:
							{
								Minifier oMinifier = new Minifier( );
								CodeSettings oSettings = new CodeSettings( );

								oSettings.LocalRenaming = OptionPage.JSMsLocalRename;
								oSettings.OutputMode = OptionPage.JSMsOutputMode;
								oSettings.PreserveImportantComments = OptionPage.JSMsPreserveImportantComments;
								oSettings.RemoveUnneededCode = OptionPage.JSMsRemoveUnneededCode;
								oSettings.PreserveFunctionNames = OptionPage.JSMsPreserveFunctionNames;
								oSettings.RemoveFunctionExpressionNames = OptionPage.JSMsRemoveFunctionExpressionNames;

								szOutputContent += oMinifier.MinifyJavaScript( szInputContent, oSettings );
							}
							break;

							case JSEngineType.GoogleClosureCompiler:
							{
								GoogleClosure oCompiler = new GoogleClosure( );

								szOutputContent += oCompiler.Compress( szInputContent, OptionPage.JSGCompilationLevel );
							}
							break;

							case JSEngineType.YUICompressor:
							{
								JavaScriptCompressor oCompressor = new JavaScriptCompressor( );

								oCompressor.CompressionType = CompressionType.Standard;

								oCompressor.DisableOptimizations = OptionPage.JSYDisableOptimizations;
								oCompressor.PreserveAllSemicolons = OptionPage.JSYPreserveAllSemicolons;
								oCompressor.ObfuscateJavascript = OptionPage.JSYObfuscateJavascript;

								szOutputContent += oCompressor.Compress( szInputContent );
							}
							break;
						}
					}

					if ( _Ext == OptionPage.CSSExt )
					{
						switch ( OptionPage.CSSEngine )
						{
							case CSSEngineType.MicrosoftAjaxMinifier:
							{
								Minifier oMinifier = new Minifier( );
								CssSettings oSettings = new CssSettings( );

								oSettings.ColorNames = OptionPage.CSSMsColorNames;
								oSettings.CommentMode = OptionPage.CSSMsCommentMode;
								oSettings.CssType = OptionPage.CSSMsCssType;
								oSettings.MinifyExpressions = OptionPage.CSSMsMinifyExpressions;
								oSettings.OutputMode = OptionPage.CSSMsOutputMode;

								szOutputContent += oMinifier.MinifyStyleSheet( szInputContent, oSettings );
							}
							break;

							case CSSEngineType.YUICompressor:
							{
								CssCompressor oCompressor = new CssCompressor( );

								oCompressor.CompressionType = CompressionType.Standard;

								oCompressor.RemoveComments = OptionPage.CSSYRemoveComments;

								szOutputContent += oCompressor.Compress( szInputContent );
							}
							break;
						}
					}


					szOutputContent += Environment.NewLine;

					OutputFileContent = szOutputContent;
				}

				return ( Encoding.UTF8.GetBytes( OutputFileContent ) );
			}
			else
			{
				GenerateProgress.GeneratorError( 1, 1, "VSMinifier can handle only js and css files...", 0, 0 );

				return ( null );
			}
		}

		private string GetDefaultExtension ( )
		{
			return ( _Ext );
		}

		private string[ ] GetFileList ( string InputFileContent )
		{
			List<string> szFileList = new List<string>( InputFileContent.Split( new string[ ] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries ) );

			szFileList.RemoveAt( 0 );

			return ( szFileList.ToArray( ) );
		}

		#endregion

		#region Package Members

		protected override void Initialize ( )
		{
			base.Initialize( );

			OleMenuCommandService oOleMenuCommandService = ( OleMenuCommandService )GetService( typeof( IMenuCommandService ) );

			if ( oOleMenuCommandService != null )
			{
				CommandID oCommandID = new CommandID( Consts.MenuGUID, ( int )Consts.CompileTargetCommand );
				CommandID oCommandListID = new CommandID( Consts.MenuGUID, ( int )Consts.CompileTargetCommandList );

				OleMenuCommand oCommand = new OleMenuCommand( CommandInvoke, oCommandID );
				OleMenuCommand oCommandList = new OleMenuCommand( CommandListInvoke, oCommandListID );

				oCommand.BeforeQueryStatus += CommandQueryStatus;

				oOleMenuCommandService.AddCommand( oCommand );
				oOleMenuCommandService.AddCommand( oCommandList );
			}
		}

		#endregion

		#region Event Handlers

		private void CommandInvoke ( object sender, EventArgs e )
		{
			OleMenuCmdEventArgs oOleMenuCmdEventArgs = ( OleMenuCmdEventArgs )e;
			Microsoft.Build.Evaluation.ProjectItem oItem = GetProjectItem( ProjectItem.Name );

			if ( oOleMenuCmdEventArgs.OutValue != IntPtr.Zero )
			{
				string szOut = string.IsNullOrEmpty( oItem.Xml.Condition ) ? "Default" : oItem.Xml.Condition.Replace( "'$(Configuration)' ==", string.Empty ).Replace( "'", string.Empty ).Trim( );

				Marshal.GetNativeVariantForObject( szOut, oOleMenuCmdEventArgs.OutValue );
			}
			else if ( oOleMenuCmdEventArgs.InValue != null )
			{
				switch ( Convert.ToString( oOleMenuCmdEventArgs.InValue ) )
				{
					case "Default":
					{
						oItem.Xml.Condition = string.Empty;
					}
					break;

					case "Debug":
					{
						oItem.Xml.Condition = " '$(Configuration)' == 'Debug' ";
					}
					break;

					case "Release":
					{
						oItem.Xml.Condition = " '$(Configuration)' == 'Release' ";
					}
					break;
				}
			}
		}

		private void CommandListInvoke ( object sender, EventArgs e )
		{
			OleMenuCmdEventArgs oOleMenuCmdEventArgs = ( OleMenuCmdEventArgs )e;

			if ( oOleMenuCmdEventArgs.OutValue != IntPtr.Zero )
			{
				Marshal.GetNativeVariantForObject( new string[ ] { "Default", "Debug", "Release" }, oOleMenuCmdEventArgs.OutValue );
			}
		}

		private void CommandQueryStatus ( object sender, EventArgs e )
		{
			OleMenuCommand oCommand = ( OleMenuCommand )sender;
			Microsoft.Build.Evaluation.ProjectItem oItem = GetProjectItem( ProjectItem.Name );
			Microsoft.Build.Evaluation.ProjectMetadata oMetadata = oItem.Metadata.SingleOrDefault( oProperty => oProperty.Name == "Generator" );
			bool bFit = false;

			if ( oMetadata != null )
			{
				string szTool = oMetadata.EvaluatedValue;

				if ( szTool.ToUpper( ) == Consts.Me.ToUpper( ) )
				{
					bFit = true;
				}
			}

			if ( !bFit )
			{
				oMetadata = oItem.Metadata.SingleOrDefault( oProperty => oProperty.Name == "DependentUpon" );

				if ( oMetadata != null )
				{
					oItem = GetProjectItem( oMetadata.EvaluatedValue );

					oMetadata = oItem.Metadata.SingleOrDefault( oProperty => oProperty.Name == "Generator" );

					string szTool = oMetadata.EvaluatedValue;

					if ( szTool.ToUpper( ) == Consts.Me.ToUpper( ) )
					{
						bFit = true;
					}
				}
			}

			oCommand.Visible = bFit;
		}

		#endregion

		#region IVsSingleFileGenerator Members

		int IVsSingleFileGenerator.DefaultExtension ( out string DefaultExtension )
		{
			DefaultExtension = GetDefaultExtension( );

			return ( VSConstants.S_OK );
		}

		int IVsSingleFileGenerator.Generate ( string InputFilePath, string InputFileContents, string DefaultNamespace, IntPtr[ ] OutputFileContents, out uint Output, IVsGeneratorProgress GenerateProgress )
		{
			byte[ ] bOutputFileContents = GenerateCode( InputFileContents, InputFilePath, GenerateProgress );
			string szOutputFilePath = InputFilePath.Replace( Path.GetExtension( InputFilePath ), _Ext );

			if ( bOutputFileContents != null )
			{
				uint nItemId;
				uint nMinItemId;
				VSADDRESULT[ ] oAddResult = new VSADDRESULT[ 1 ];
				FileStream oOutputFile = File.Create( szOutputFilePath );

				oOutputFile.Write( bOutputFileContents, 0, bOutputFileContents.Length );
				oOutputFile.Close( );

				nItemId = GetProjectItemId( InputFilePath );

				if ( VsProject.AddItem( nItemId, VSADDITEMOPERATION.VSADDITEMOP_OPENFILE, szOutputFilePath, 1, new string[ ] { szOutputFilePath }, IntPtr.Zero, oAddResult ) == VSConstants.S_OK )
				{
					nMinItemId = GetProjectItemId( szOutputFilePath );

					Microsoft.Build.Evaluation.ProjectItem oItem = GetProjectItem( InputFilePath );
					Microsoft.Build.Evaluation.ProjectItem oMinItem = GetProjectItem( szOutputFilePath );

					VsBuildPropertyStorage.SetItemAttribute( nItemId, "LastGenOutput", Path.GetFileName( szOutputFilePath ) );

					VsBuildPropertyStorage.SetItemAttribute( nMinItemId, "AutoGen", "True" );
					VsBuildPropertyStorage.SetItemAttribute( nMinItemId, "DesignTime", "True" );
					VsBuildPropertyStorage.SetItemAttribute( nMinItemId, "DependentUpon", Path.GetFileName( InputFilePath ) );

					switch ( OptionPage.CompileTargetType )
					{
						case CompileTargetType.Default:
						{
							oItem.Xml.Condition = string.Empty;
							oMinItem.Xml.Condition = string.Empty;
						}
						break;

						case CompileTargetType.Mixed:
						{
							oItem.Xml.Condition = " '$(Configuration)' == 'Debug' ";
							oMinItem.Xml.Condition = " '$(Configuration)' == 'Release' ";
						}
						break;
					}

					switch ( OptionPage.BuildActionType )
					{
						case BuildActionType.Copy:
						{
							oMinItem.ItemType = oItem.ItemType;
						}
						break;

						case BuildActionType.Custom:
						{
							oItem.ItemType = OptionPage.OriginalBuildAction;
							oMinItem.ItemType = OptionPage.MinifiedBuildAction;
						}
						break;
					}


					//////////////////////

					Application.Windows.Item( EnvDTE.Constants.vsWindowKindSolutionExplorer ).Activate( );
					Application.ToolWindows.SolutionExplorer.GetItem( string.Format( "{0}\\{1}", Path.GetFileNameWithoutExtension( Application.Solution.FullName ), ProjectName.EvaluatedValue ) ).Select( vsUISelectionType.vsUISelectionTypeSelect );

					BuildProject.Save( );

					Application.ExecuteCommand( "Project.UnloadProject" );
					Application.ExecuteCommand( "Project.ReloadProject" );

					Application.Windows.Item( EnvDTE.Constants.vsWindowKindSolutionExplorer ).Activate( );
					Application.ToolWindows.SolutionExplorer.GetItem( string.Format( "{0}\\{1}\\{2}", Path.GetFileNameWithoutExtension( Application.Solution.FullName ), ProjectName.EvaluatedValue, oItem.EvaluatedInclude ) ).Select( vsUISelectionType.vsUISelectionTypeSelect );
				}
				else
				{
					GenerateProgress.GeneratorError( 1, 1, "VSMinifier can't add minified file to project...", 0, 0 );
				}
			}

			Output = 0;

			return ( VSConstants.E_FAIL );
		}

		#endregion
	}
}
