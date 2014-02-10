using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using EnvDTE;
using Microsoft.Ajax.Utilities;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Yahoo.Yui.Compressor;

namespace Company.VSMinifier
{
	[Guid( Consts.GUID )]
	[CustomToolRegistration( "VSMinifier" )]
	[ProvideObject( typeof( VSMinifier ) )]
	[ProvideOptionPage( typeof( OptionPage ), "Custom Tools", "VSMinifier", 0, 0, true )]
	[InstalledProductRegistration( "VSMinifier", "VSMinifier", "1.12", IconResourceID = 4000 )]
	public sealed class VSMinifier : Package, IVsSingleFileGenerator
	{
		private string _InputFilePath = null;
		private string _InputFileNamespace = null;
		IVsGeneratorProgress _GenerateProgress = null;
		private string _Ext = null;

		private byte[ ] GenerateCode ( string InputFileContent )
		{
			bool bDo = false;
			string OutputFileContent = InputFileContent;
			OptionPage oOptionPage = LoadOptions( );

			_Ext = Path.GetExtension( _InputFilePath );

			if ( _Ext.Equals( Consts.CSSExt ) )
			{
				_Ext = oOptionPage.CSSExt;
				bDo = true;
			}

			if ( _Ext.Equals( Consts.JSExt ) )
			{
				_Ext = oOptionPage.JSExt;
				bDo = true;
			}

			if ( bDo )
			{
				if ( _Ext == oOptionPage.JSExt )
				{
					switch ( oOptionPage.JSEngine )
					{
						case JSEngineType.MicrosoftAjaxMinifier:
						{
							Minifier oMinifier = new Minifier( );
							CodeSettings oSettings = new CodeSettings( );

							oSettings.LocalRenaming = oOptionPage.JSMsLocalRename;
							oSettings.OutputMode = oOptionPage.JSMsOutputMode;
							oSettings.PreserveImportantComments = oOptionPage.JSMsPreserveImportantComments;
							oSettings.RemoveUnneededCode = oOptionPage.JSMsRemoveUnneededCode;
							oSettings.PreserveFunctionNames = oOptionPage.JSMsPreserveFunctionNames;
							oSettings.RemoveFunctionExpressionNames = oOptionPage.JSMsRemoveFunctionExpressionNames;

							OutputFileContent = oMinifier.MinifyJavaScript( InputFileContent, oSettings );
						}
						break;

						case JSEngineType.GoogleClosureCompiler:
						{
							GoogleClosure oCompiler = new GoogleClosure( );

							OutputFileContent = oCompiler.Compress( InputFileContent, oOptionPage.JSGCompilationLevel );
						}
						break;

						case JSEngineType.YUICompressor:
						{
							JavaScriptCompressor oCompressor = new JavaScriptCompressor( );

							oCompressor.CompressionType = CompressionType.Standard;

							oCompressor.DisableOptimizations = oOptionPage.JSYDisableOptimizations;
							oCompressor.PreserveAllSemicolons = oOptionPage.JSYPreserveAllSemicolons;
							oCompressor.ObfuscateJavascript = oOptionPage.JSYObfuscateJavascript;

							OutputFileContent = oCompressor.Compress( InputFileContent );
						}
						break;
					}
				}

				if ( _Ext == oOptionPage.CSSExt )
				{
					switch ( oOptionPage.CSSEngine )
					{
						case CSSEngineType.MicrosoftAjaxMinifier:
						{
							Minifier oMinifier = new Minifier( );
							CssSettings oSettings = new CssSettings( );

							oSettings.ColorNames = oOptionPage.CSSMsColorNames;
							oSettings.CommentMode = oOptionPage.CSSMsCommentMode;
							oSettings.CssType = oOptionPage.CSSMsCssType;
							oSettings.MinifyExpressions = oOptionPage.CSSMsMinifyExpressions;
							oSettings.OutputMode = oOptionPage.CSSMsOutputMode;

							OutputFileContent = oMinifier.MinifyStyleSheet( InputFileContent, oSettings );
						}
						break;

						case CSSEngineType.YUICompressor:
						{
							CssCompressor oCompressor = new CssCompressor( );

							oCompressor.CompressionType = CompressionType.Standard;

							oCompressor.RemoveComments = oOptionPage.CSSYRemoveComments;

							OutputFileContent = oCompressor.Compress( InputFileContent );
						}
						break;
					}
				}

				return ( Encoding.UTF8.GetBytes( OutputFileContent ) );
			}
			else
			{
				_GenerateProgress.GeneratorError( 1, 1, "VSMinifier can handle only js and css files...", 0, 0 );

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
			_InputFilePath = InputFilePath;
			_InputFileNamespace = DefaultNamespace;
			_GenerateProgress = GenerateProgress;

			byte[ ] bOutputFileContents = GenerateCode( InputFileContents );

			if ( bOutputFileContents == null )
			{
				Output = 0;

				return ( VSConstants.E_FAIL );
			}
			else
			{
				Output = ( uint )bOutputFileContents.Length;

				OutputFileContents[ 0 ] = Marshal.AllocCoTaskMem( bOutputFileContents.Length );
				Marshal.Copy( bOutputFileContents, 0, OutputFileContents[ 0 ], bOutputFileContents.Length );

				return ( VSConstants.S_OK );
			}
		}

		#endregion
	}
}
