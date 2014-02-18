using System;
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
	[InstalledProductRegistration( "#4001", "#4002", "1.13.1", IconResourceID = 4000 )]
	public sealed class VSMinifier : Package, IVsSingleFileGenerator
	{
		private string _Ext;
		private OptionPage _OptionPage;

		private byte[ ] GenerateCode ( string InputFileContent, string InputFilePath, IVsGeneratorProgress GenerateProgress )
		{
			bool bDo = false;
			string OutputFileContent = InputFileContent;
			
			_OptionPage = LoadOptions( );

			_Ext = Path.GetExtension( InputFilePath );

			if ( _Ext.Equals( Consts.CSSExt ) )
			{
				_Ext = _OptionPage.CSSExt;
				bDo = true;
			}

			if ( _Ext.Equals( Consts.JSExt ) )
			{
				_Ext = _OptionPage.JSExt;
				bDo = true;
			}

			if ( bDo )
			{
				if ( _Ext == _OptionPage.JSExt )
				{
					switch ( _OptionPage.JSEngine )
					{
						case JSEngineType.MicrosoftAjaxMinifier:
						{
							Minifier oMinifier = new Minifier( );
							CodeSettings oSettings = new CodeSettings( );

							oSettings.LocalRenaming = _OptionPage.JSMsLocalRename;
							oSettings.OutputMode = _OptionPage.JSMsOutputMode;
							oSettings.PreserveImportantComments = _OptionPage.JSMsPreserveImportantComments;
							oSettings.RemoveUnneededCode = _OptionPage.JSMsRemoveUnneededCode;
							oSettings.PreserveFunctionNames = _OptionPage.JSMsPreserveFunctionNames;
							oSettings.RemoveFunctionExpressionNames = _OptionPage.JSMsRemoveFunctionExpressionNames;

							OutputFileContent = oMinifier.MinifyJavaScript( InputFileContent, oSettings );
						}
						break;

						case JSEngineType.GoogleClosureCompiler:
						{
							GoogleClosure oCompiler = new GoogleClosure( );

							OutputFileContent = oCompiler.Compress( InputFileContent, _OptionPage.JSGCompilationLevel );
						}
						break;

						case JSEngineType.YUICompressor:
						{
							JavaScriptCompressor oCompressor = new JavaScriptCompressor( );

							oCompressor.CompressionType = CompressionType.Standard;

							oCompressor.DisableOptimizations = _OptionPage.JSYDisableOptimizations;
							oCompressor.PreserveAllSemicolons = _OptionPage.JSYPreserveAllSemicolons;
							oCompressor.ObfuscateJavascript = _OptionPage.JSYObfuscateJavascript;

							OutputFileContent = oCompressor.Compress( InputFileContent );
						}
						break;
					}
				}

				if ( _Ext == _OptionPage.CSSExt )
				{
					switch ( _OptionPage.CSSEngine )
					{
						case CSSEngineType.MicrosoftAjaxMinifier:
						{
							Minifier oMinifier = new Minifier( );
							CssSettings oSettings = new CssSettings( );

							oSettings.ColorNames = _OptionPage.CSSMsColorNames;
							oSettings.CommentMode = _OptionPage.CSSMsCommentMode;
							oSettings.CssType = _OptionPage.CSSMsCssType;
							oSettings.MinifyExpressions = _OptionPage.CSSMsMinifyExpressions;
							oSettings.OutputMode = _OptionPage.CSSMsOutputMode;

							OutputFileContent = oMinifier.MinifyStyleSheet( InputFileContent, oSettings );
						}
						break;

						case CSSEngineType.YUICompressor:
						{
							CssCompressor oCompressor = new CssCompressor( );

							oCompressor.CompressionType = CompressionType.Standard;

							oCompressor.RemoveComments = _OptionPage.CSSYRemoveComments;

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

		private OptionPage LoadOptions ( )
		{
			OptionPage oOptionPage = new OptionPage( );
			PropertyInfo[ ] oPropertyInfoArray = oOptionPage.GetType( ).GetProperties( );

			DTE oDTE = ( DTE )GetGlobalService( typeof( DTE ) );
			Properties oProperties = oDTE.get_Properties( "Custom Tools", "VSMinifier" );

			foreach ( PropertyInfo oPropertyInfo in oPropertyInfoArray )
			{
				if ( oPropertyInfo.ReflectedType == oPropertyInfo.DeclaringType )
				{
					oPropertyInfo.SetValue( oOptionPage, oProperties.Item( oPropertyInfo.Name ).Value, null );
				}
			}

			return ( oOptionPage );
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

			EnvDTE80.DTE2 Application = ( EnvDTE80.DTE2 )Package.GetGlobalService( typeof( EnvDTE.DTE ) );
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

				if (  oVsProject.AddItem( nItemId, VSADDITEMOPERATION.VSADDITEMOP_OPENFILE, szOutputFilePath, 1, new string[ ] { szOutputFilePath }, IntPtr.Zero, oAddResult ) == VSConstants.S_OK )
				{
					oVsHierarchy.ParseCanonicalName( szOutputFilePath, out nMinItemId );

					Microsoft.Build.Evaluation.ProjectItem oItem = oBuildProject.Items.Where( item => item.EvaluatedInclude.EndsWith( Path.GetFileName( InputFilePath ) ) ).Single( );
					Microsoft.Build.Evaluation.ProjectItem oMinItem = oBuildProject.Items.Where( item => item.EvaluatedInclude.EndsWith( Path.GetFileName( szOutputFilePath ) ) ).Single( );

					oVsBuildPropertyStorage.SetItemAttribute( nItemId, "LastGenOutput", Path.GetFileName( szOutputFilePath ) );

					oVsBuildPropertyStorage.SetItemAttribute( nMinItemId, "AutoGen", "True" );
					oVsBuildPropertyStorage.SetItemAttribute( nMinItemId, "DesignTime", "True" );
					oVsBuildPropertyStorage.SetItemAttribute( nMinItemId, "DependentUpon", Path.GetFileName( InputFilePath ) );

					//////////////////////
					switch (_OptionPage.CompileTargetType)
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
					
					switch(_OptionPage.BuildActionType)
					{
						case BuildActionType.Default:
						{
							oItem.ItemType = "Content";
							oMinItem.ItemType = "Content";
						}
						break;

						case BuildActionType.Copy:
						{
							oMinItem.ItemType = oItem.ItemType;
						}
						break;

						case BuildActionType.Custom:
						{
							oItem.ItemType = _OptionPage.OriginalBuildAction;
							oMinItem.ItemType = _OptionPage.MinifiedBuildAction;
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
