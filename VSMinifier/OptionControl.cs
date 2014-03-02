using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Ajax.Utilities;

namespace VSMinifier
{
	public partial class OptionControl : UserControl
	{
		private OptionPage _OptionPage = null;

		public OptionControl ( OptionPage OptionPage )
		{
			_OptionPage = OptionPage;

			InitializeComponent( );
		}

		private void ShowEngineOptions ( )
		{
			// JS
			JSGoogle.Visible = ( JSEngine.SelectedIndex == Convert.ToInt32( JSEngineType.GoogleClosureCompiler ) );
			JSMsMinifier.Visible = ( JSEngine.SelectedIndex == Convert.ToInt32( JSEngineType.MicrosoftAjaxMinifier ) );
			JSYUI.Visible = ( JSEngine.SelectedIndex == Convert.ToInt32( JSEngineType.YUICompressor ) );

			// CSS
			CSSMsMinifier.Visible = ( CSSEngine.SelectedIndex == Convert.ToInt32( CSSEngineType.MicrosoftAjaxMinifier ) );
			CSSYUI.Visible = ( CSSEngine.SelectedIndex == Convert.ToInt32( CSSEngineType.YUICompressor ) );
		}

		private void OptionControl_Load ( object sender, EventArgs e )
		{
			// Common - Build Action
			BADefault.Checked = _OptionPage.BuildActionType == BuildActionType.Default;
			BACopy.Checked = _OptionPage.BuildActionType == BuildActionType.Copy;
			BACustom.Checked = _OptionPage.BuildActionType == BuildActionType.Custom;

			BACustomOriginal.Text = _OptionPage.OriginalBuildAction;
			BACustomMinified.Text = _OptionPage.MinifiedBuildAction;

			BACustomOriginal.Enabled = _OptionPage.BuildActionType == BuildActionType.Custom;
			BACustomMinified.Enabled = _OptionPage.BuildActionType == BuildActionType.Custom;

			// Common - Compile Target
			CTDefault.Checked = _OptionPage.CompileTargetType == CompileTargetType.Default;
			CTMixed.Checked = _OptionPage.CompileTargetType == CompileTargetType.Mixed;

			CTManual.Checked = _OptionPage.EnableManual;

			// JS
			JSExt.Text = _OptionPage.JSExt;
			JSEngine.SelectedIndex = Convert.ToInt32( _OptionPage.JSEngine );

			// Ms - JS
			JSMsLocalRename.SelectedIndex = Convert.ToInt32( _OptionPage.JSMsLocalRename );
			JSMsOutputMode.SelectedIndex = Convert.ToInt32( _OptionPage.JSMsOutputMode );
			JSMsPreserveFunctionNames.Checked = _OptionPage.JSMsPreserveFunctionNames;
			JSMsPreserveImportantComments.Checked = _OptionPage.JSMsPreserveImportantComments;
			JSMsRemoveFunctionExpressionNames.Checked = _OptionPage.JSMsRemoveFunctionExpressionNames;
			JSMsRemoveUnneededCode.Checked = _OptionPage.JSMsRemoveUnneededCode;

			// Yahoo - JS
			JSYDisableOptimizations.Checked = _OptionPage.JSYDisableOptimizations;
			JSYObfuscateJavascript.Checked = _OptionPage.JSYObfuscateJavascript;
			JSYPreserveAllSemicolons.Checked = _OptionPage.JSYPreserveAllSemicolons;

			// Google - JS
			JSGCompilationLevel.SelectedIndex = Convert.ToInt32( _OptionPage.JSGCompilationLevel );

			// CSS
			CSSExt.Text = _OptionPage.CSSExt;
			CSSEngine.SelectedIndex = Convert.ToInt32( _OptionPage.CSSEngine );

			// Ms - CSS
			CSSMsColorNames.SelectedIndex = Convert.ToInt32( _OptionPage.CSSMsColorNames );
			CSSMsCommentMode.SelectedIndex = Convert.ToInt32( _OptionPage.CSSMsCommentMode );
			CSSMsCssType.SelectedIndex = Convert.ToInt32( _OptionPage.CSSMsCssType );
			CSSMsOutputMode.SelectedIndex = Convert.ToInt32( _OptionPage.CSSMsOutputMode );
			CSSMsMinifyExpressions.Checked = _OptionPage.CSSMsMinifyExpressions;

			// Yahoo - CSS
			CSSYRemoveComments.Checked = _OptionPage.CSSYRemoveComments;

			ShowEngineOptions( );

			// Help
			Assembly oAssembly = Assembly.GetExecutingAssembly( );
			Stream oStream = oAssembly.GetManifestResourceStream( "VSMinifier.Resources.Help.rtf" );

			HelpText.LoadFile( oStream, RichTextBoxStreamType.RichText );
		}

		private void Tab_Resize ( object sender, EventArgs e )
		{
			// JS
			JSGoogle.Height = JSMsMinifier.Height = JSYUI.Height = JSTab.ClientSize.Height - 68;
			JSGoogle.Top = JSMsMinifier.Top = JSYUI.Top = 68;

			JSGoogle.Dock = JSMsMinifier.Dock = JSYUI.Dock = DockStyle.Bottom;

			// CSS
			CSSMsMinifier.Height = CSSYUI.Height = CSSTab.ClientSize.Height - 68;
			CSSMsMinifier.Top = CSSYUI.Top = 68;

			CSSMsMinifier.Dock = CSSYUI.Dock = DockStyle.Bottom;
		}

		#region Common

		#region Build Action

		private void BADefault_Click ( object sender, EventArgs e )
		{
			_OptionPage.BuildActionType = BuildActionType.Default;

			BACustomOriginal.Enabled = false;
			BACustomMinified.Enabled = false;

		}

		private void BACopy_Click ( object sender, EventArgs e )
		{
			_OptionPage.BuildActionType = BuildActionType.Copy;

			BACustomOriginal.Enabled = false;
			BACustomMinified.Enabled = false;
		}

		private void BACustom_Click ( object sender, EventArgs e )
		{
			_OptionPage.BuildActionType = BuildActionType.Custom;

			BACustomOriginal.Enabled = true;
			BACustomMinified.Enabled = true;
		}

		private void BACustomOriginal_SelectedIndexChanged ( object sender, EventArgs e )
		{
			_OptionPage.OriginalBuildAction = BACustomOriginal.Text;
		}

		private void BACustomMinified_SelectedIndexChanged ( object sender, EventArgs e )
		{
			_OptionPage.MinifiedBuildAction = BACustomMinified.Text;
		}

		#endregion

		#region Compile Target

		private void CTDefault_Click ( object sender, EventArgs e )
		{
			_OptionPage.CompileTargetType = CompileTargetType.Default;
		}

		private void CTMixed_Click ( object sender, EventArgs e )
		{
			_OptionPage.CompileTargetType = CompileTargetType.Mixed;
		}

		private void CTManual_Click ( object sender, EventArgs e )
		{
			_OptionPage.EnableManual = CTManual.Checked;
		}

		#endregion

		#endregion

		#region JS

		private void JSExt_TextChanged ( object sender, EventArgs e )
		{
			_OptionPage.JSExt = JSExt.Text;
		}

		private void JSEngine_SelectedIndexChanged ( object sender, EventArgs e )
		{
			ShowEngineOptions( );

			_OptionPage.JSEngine = ( JSEngineType )JSEngine.SelectedIndex;
		}

		private void JSMsLocalRename_SelectedIndexChanged ( object sender, EventArgs e )
		{
			_OptionPage.JSMsLocalRename = ( LocalRenaming )JSMsLocalRename.SelectedIndex;
		}

		private void JSMsOutputMode_SelectedIndexChanged ( object sender, EventArgs e )
		{
			_OptionPage.JSMsOutputMode = ( OutputMode )JSMsOutputMode.SelectedIndex;
		}

		private void JSMsPreserveImportantComments_CheckedChanged ( object sender, EventArgs e )
		{
			_OptionPage.JSMsPreserveImportantComments = JSMsPreserveImportantComments.Checked;
		}

		private void JSMsRemoveUnneededCode_CheckedChanged ( object sender, EventArgs e )
		{
			_OptionPage.JSMsRemoveUnneededCode = JSMsRemoveUnneededCode.Checked;
		}

		private void JSMsPreserveFunctionNames_CheckedChanged ( object sender, EventArgs e )
		{
			_OptionPage.JSMsPreserveFunctionNames = JSMsPreserveFunctionNames.Checked;
		}

		private void JSMsRemoveFunctionExpressionNames_CheckedChanged ( object sender, EventArgs e )
		{
			_OptionPage.JSMsRemoveFunctionExpressionNames = JSMsRemoveFunctionExpressionNames.Checked;
		}

		private void JSYDisableOptimizations_CheckedChanged ( object sender, EventArgs e )
		{
			_OptionPage.JSYDisableOptimizations = JSYDisableOptimizations.Checked;
		}

		private void JSYPreserveAllSemicolons_CheckedChanged ( object sender, EventArgs e )
		{
			_OptionPage.JSYPreserveAllSemicolons = JSYPreserveAllSemicolons.Checked;
		}

		private void JSYObfuscateJavascript_CheckedChanged ( object sender, EventArgs e )
		{
			_OptionPage.JSYObfuscateJavascript = JSYObfuscateJavascript.Checked;
		}

		private void JSGCompilationLevel_SelectedIndexChanged ( object sender, EventArgs e )
		{
			_OptionPage.JSGCompilationLevel = ( CompilationLevel )JSGCompilationLevel.SelectedIndex;
		}

		#endregion

		#region CSS

		private void CSSExt_TextChanged ( object sender, EventArgs e )
		{
			_OptionPage.CSSExt = CSSExt.Text;
		}

		private void CSSEngine_SelectedIndexChanged ( object sender, EventArgs e )
		{
			ShowEngineOptions( );

			_OptionPage.CSSEngine = ( CSSEngineType )CSSEngine.SelectedIndex;
		}

		private void CSSYRemoveComments_CheckedChanged ( object sender, EventArgs e )
		{
			_OptionPage.CSSYRemoveComments = CSSYRemoveComments.Checked;
		}

		#endregion
	}
}
