using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using VSLangProj80;
using VSMinifier;

namespace VSMinifier
{
	[Guid( Consts.GUID )]
	[CodeGeneratorRegistration( typeof( VSMinifier ), Consts.Me, vsContextGuids.vsContextGuidVCSProject )]
	[CodeGeneratorRegistration( typeof( VSMinifier ), Consts.Me, vsContextGuids.vsContextGuidVBProject )]
	[ProvideObject( typeof( VSMinifier ) )]
	[PackageRegistration( UseManagedResourcesOnly = true )]
	[InstalledProductRegistration("#110", "#112", "1.13.5", IconResourceID = 400)]
	[ProvideOptionPage( typeof( OptionPage ), "Custom Tools", Consts.Me, 0, 0, true )]
	[ProvideMenuResource( "VSCT", 1 )]
	public sealed class VSMinifier : Package
	{
		public VSMinifier ( )
		{
		}

		#region Package Members

		protected override void Initialize()
		{
			base.Initialize();
		}

		#endregion
	}
}
