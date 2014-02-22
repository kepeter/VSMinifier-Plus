using System;
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
	[CodeGeneratorRegistration( typeof( VSMinifier ), "VSMinifier", vsContextGuids.vsContextGuidVCSProject )]
	[CodeGeneratorRegistration( typeof( VSMinifier ), "VSMinifier", vsContextGuids.vsContextGuidVBProject )]
	[ProvideObject( typeof( VSMinifier ) )]
	[ProvideOptionPage( typeof( OptionPage ), "Custom Tools", "VSMinifier", 0, 0, true )]
	[ProvideMenuResource( "VSCT", 1 )]
	[InstalledProductRegistration( "#4001", "#4002", "1.13.1", IconResourceID = 4000 )]
	public sealed class VSMinifier : Package, IVsSingleFileGenerator
	{
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
					Properties oProperties = Application.get_Properties( "Custom Tools", "VSMinifier" );

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

		private void CommandInvoke ( object sender, EventArgs e )
		{
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

			oCommand.Visible = true;
		}

		private byte[ ] GenerateCode ( string InputFileContent, string InputFilePath, IVsGeneratorProgress GenerateProgress )
		{
			bool bDo = false;
			string OutputFileContent = InputFileContent;

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

							OutputFileContent = oMinifier.MinifyJavaScript( InputFileContent, oSettings );
						}
						break;

						case JSEngineType.GoogleClosureCompiler:
						{
							GoogleClosure oCompiler = new GoogleClosure( );

							OutputFileContent = oCompiler.Compress( InputFileContent, OptionPage.JSGCompilationLevel );
						}
						break;

						case JSEngineType.YUICompressor:
						{
							JavaScriptCompressor oCompressor = new JavaScriptCompressor( );

							oCompressor.CompressionType = CompressionType.Standard;

							oCompressor.DisableOptimizations = OptionPage.JSYDisableOptimizations;
							oCompressor.PreserveAllSemicolons = OptionPage.JSYPreserveAllSemicolons;
							oCompressor.ObfuscateJavascript = OptionPage.JSYObfuscateJavascript;

							OutputFileContent = oCompressor.Compress( InputFileContent );
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

							OutputFileContent = oMinifier.MinifyStyleSheet( InputFileContent, oSettings );
						}
						break;

						case CSSEngineType.YUICompressor:
						{
							CssCompressor oCompressor = new CssCompressor( );

							oCompressor.CompressionType = CompressionType.Standard;

							oCompressor.RemoveComments = OptionPage.CSSYRemoveComments;

							OutputFileContent = oCompressor.Compress( InputFileContent );
						}
						break;
					}
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

			EnvDTE.ProjectItem oProjectItem = Application.SelectedItems.Item( 1 ).ProjectItem;
			System.IServiceProvider oServiceProvider = new Microsoft.VisualStudio.Shell.ServiceProvider( ( Microsoft.VisualStudio.OLE.Interop.IServiceProvider )Application );
			Microsoft.Build.Evaluation.Project oBuildProject = Microsoft.Build.Evaluation.ProjectCollection.GlobalProjectCollection.GetLoadedProjects( oProjectItem.ContainingProject.FullName ).SingleOrDefault( );
			Microsoft.Build.Evaluation.ProjectProperty oGUID = oBuildProject.AllEvaluatedProperties.SingleOrDefault( oProperty => oProperty.Name == "ProjectGuid" );
			Microsoft.Build.Evaluation.ProjectProperty oName = oBuildProject.AllEvaluatedProperties.Single( oProperty => oProperty.Name == "ProjectName" );
			Microsoft.VisualStudio.Shell.Interop.IVsHierarchy oVsHierarchy = VsShellUtilities.GetHierarchy( oServiceProvider, new Guid( oGUID.EvaluatedValue ) );
			Microsoft.VisualStudio.Shell.Interop.IVsProject oVsProject = ( IVsProject )oVsHierarchy;
			Microsoft.VisualStudio.Shell.Interop.IVsBuildPropertyStorage oVsBuildPropertyStorage = ( Microsoft.VisualStudio.Shell.Interop.IVsBuildPropertyStorage )oVsHierarchy;
			VSADDRESULT[ ] oAddResult = new VSADDRESULT[ 1 ];

			uint nItemId;
			uint nMinItemId;

			if ( bOutputFileContents != null )
			{
				FileStream oOutputFile = File.Create( szOutputFilePath );

				oOutputFile.Write( bOutputFileContents, 0, bOutputFileContents.Length );
				oOutputFile.Close( );

				oVsHierarchy.ParseCanonicalName( InputFilePath, out nItemId );

				if ( oVsProject.AddItem( nItemId, VSADDITEMOPERATION.VSADDITEMOP_OPENFILE, szOutputFilePath, 1, new string[ ] { szOutputFilePath }, IntPtr.Zero, oAddResult ) == VSConstants.S_OK )
				{
					oVsHierarchy.ParseCanonicalName( szOutputFilePath, out nMinItemId );

					Microsoft.Build.Evaluation.ProjectItem oItem = oBuildProject.ItemsIgnoringCondition.Where( item => item.EvaluatedInclude.EndsWith( Path.GetFileName( InputFilePath ) ) ).Single( );
					Microsoft.Build.Evaluation.ProjectItem oMinItem = oBuildProject.ItemsIgnoringCondition.Where( item => item.EvaluatedInclude.EndsWith( Path.GetFileName( szOutputFilePath ) ) ).Single( );

					oVsBuildPropertyStorage.SetItemAttribute( nItemId, "LastGenOutput", Path.GetFileName( szOutputFilePath ) );

					oVsBuildPropertyStorage.SetItemAttribute( nMinItemId, "AutoGen", "True" );
					oVsBuildPropertyStorage.SetItemAttribute( nMinItemId, "DesignTime", "True" );
					oVsBuildPropertyStorage.SetItemAttribute( nMinItemId, "DependentUpon", Path.GetFileName( InputFilePath ) );

					//////////////////////
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
					Application.ToolWindows.SolutionExplorer.GetItem( string.Format( "{0}\\{1}", Path.GetFileNameWithoutExtension( Application.Solution.FullName ), oName.EvaluatedValue ) ).Select( vsUISelectionType.vsUISelectionTypeSelect );

					oBuildProject.Save( );

					Application.ExecuteCommand( "Project.UnloadProject" );
					Application.ExecuteCommand( "Project.ReloadProject" );

					Application.Windows.Item( EnvDTE.Constants.vsWindowKindSolutionExplorer ).Activate( );
					Application.ToolWindows.SolutionExplorer.GetItem( string.Format( "{0}\\{1}\\{2}", Path.GetFileNameWithoutExtension( Application.Solution.FullName ), oName.EvaluatedValue, oItem.EvaluatedInclude ) ).Select( vsUISelectionType.vsUISelectionTypeSelect );
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
