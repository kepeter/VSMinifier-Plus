using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Ajax.Utilities;
using Microsoft.VisualStudio.Shell;

namespace Company.VSMinifier
{
	[ComVisible( true )]
	public class OptionPage : DialogPage
	{
		#region JS

		#region Common

		private string _JSExt = Consts.JSMinExt;

		public string JSExt
		{
			get
			{
				return ( _JSExt );
			}
			set
			{
				_JSExt = value;
			}
		}

		private JSEngineType _JSEngine = JSEngineType.MicrosoftAjaxMinifier;

		public JSEngineType JSEngine
		{
			get
			{
				return ( _JSEngine );
			}
			set
			{
				_JSEngine = value;
			}
		}

		#endregion

		#region Microsoft

		private LocalRenaming _JSMsLocalRename = LocalRenaming.CrunchAll;

		public LocalRenaming JSMsLocalRename
		{
			get
			{
				return ( _JSMsLocalRename );
			}
			set
			{
				_JSMsLocalRename = value;
			}
		}

		private OutputMode _JSMsOutputMode = OutputMode.SingleLine;

		public OutputMode JSMsOutputMode
		{
			get
			{
				return ( _JSMsOutputMode );
			}
			set
			{
				_JSMsOutputMode = value;
			}
		}

		private bool _JSMsPreserveImportantComments = false;

		public bool JSMsPreserveImportantComments
		{
			get
			{
				return ( _JSMsPreserveImportantComments );
			}
			set
			{
				_JSMsPreserveImportantComments = value;
			}
		}

		private bool _JSMsRemoveUnneededCode = true;

		public bool JSMsRemoveUnneededCode
		{
			get
			{
				return ( _JSMsRemoveUnneededCode );
			}
			set
			{
				_JSMsRemoveUnneededCode = value;
			}
		}

		private bool _JSMsPreserveFunctionNames = false;

		public bool JSMsPreserveFunctionNames
		{
			get
			{
				return ( _JSMsPreserveFunctionNames );
			}
			set
			{
				_JSMsPreserveFunctionNames = value;
			}
		}

		private bool _JSMsRemoveFunctionExpressionNames = true;

		public bool JSMsRemoveFunctionExpressionNames
		{
			get
			{
				return ( _JSMsRemoveFunctionExpressionNames );
			}
			set
			{
				_JSMsRemoveFunctionExpressionNames = value;
			}
		}

		#endregion

		#region Yahoo

		private bool _JSYDisableOptimizations = false;

		public bool JSYDisableOptimizations
		{
			get
			{
				return ( _JSYDisableOptimizations );
			}
			set
			{
				_JSYDisableOptimizations = value;
			}
		}

		private bool _JSYPreserveAllSemicolons = false;

		public bool JSYPreserveAllSemicolons
		{
			get
			{
				return ( _JSYPreserveAllSemicolons );
			}
			set
			{
				_JSYPreserveAllSemicolons = value;
			}
		}

		private bool _JSYObfuscateJavascript = true;

		public bool JSYObfuscateJavascript
		{
			get
			{
				return ( _JSYObfuscateJavascript );
			}
			set
			{
				_JSYObfuscateJavascript = value;
			}
		}

		#endregion

		#region Google

		private CompilationLevel _JSGCompilationLevel = CompilationLevel.ADVANCED_OPTIMIZATIONS;

		public CompilationLevel JSGCompilationLevel
		{
			get
			{
				return ( _JSGCompilationLevel );
			}
			set
			{
				_JSGCompilationLevel = value;
			}
		}

		#endregion

		#endregion

		#region CSS

		#region Common

		private string _CSSExt = Consts.CSSMinExt;

		public string CSSExt
		{
			get
			{
				return ( _CSSExt );
			}
			set
			{
				_CSSExt = value;
			}
		}

		private CSSEngineType _CSSEngine = CSSEngineType.MicrosoftAjaxMinifier;

		public CSSEngineType CSSEngine
		{
			get
			{
				return ( _CSSEngine );
			}
			set
			{
				_CSSEngine = value;
			}
		}

		#endregion

		#region Microsoft

		private CssColor _CSSMsColorNames = CssColor.Hex;

		public CssColor CSSMsColorNames
		{
			get
			{
				return ( _CSSMsColorNames );
			}
			set
			{
				_CSSMsColorNames = value;
			}
		}

		private CssComment _CSSMsCommentMode = CssComment.None;

		public CssComment CSSMsCommentMode
		{
			get
			{
				return ( _CSSMsCommentMode );
			}
			set
			{
				_CSSMsCommentMode = value;
			}
		}

		private CssType _CSSMsCssType = CssType.FullStyleSheet;

		public CssType CSSMsCssType
		{
			get
			{
				return ( _CSSMsCssType );
			}
			set
			{
				_CSSMsCssType = value;
			}
		}

		private bool _CSSMsMinifyExpressions = true;

		public bool CSSMsMinifyExpressions
		{
			get
			{
				return ( _CSSMsMinifyExpressions );
			}
			set
			{
				_CSSMsMinifyExpressions = value;
			}
		}

		private OutputMode _CSSMsOutputMode = OutputMode.SingleLine;

		public OutputMode CSSMsOutputMode
		{
			get
			{
				return ( _CSSMsOutputMode );
			}
			set
			{
				_CSSMsOutputMode = value;
			}
		}

		#endregion

		#region Yahoo

		private bool _CSSYRemoveComments = true;

		public bool CSSYRemoveComments
		{
			get
			{
				return ( _CSSYRemoveComments );
			}
			set
			{
				_CSSYRemoveComments = value;
			}
		}

		#endregion

		#endregion

		protected override IWin32Window Window
		{
			get
			{
				OptionControl oCtrl = new OptionControl( this );

				return ( oCtrl );
			}
		}
	}
}
