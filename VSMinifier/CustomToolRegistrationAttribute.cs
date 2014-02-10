using System;
using Microsoft.VisualStudio.Shell;
using VSLangProj80;

namespace VSMinifier
{
	[AttributeUsage( AttributeTargets.Class, AllowMultiple = false, Inherited = true )]
	class CustomToolRegistrationAttribute : RegistrationAttribute
	{
		private string _ToolName = null;

		private bool _GeneratesDesignTimeSource = true;

		public bool GeneratesDesignTimeSource
		{
			get
			{
				return _GeneratesDesignTimeSource;
			}
			set
			{
				_GeneratesDesignTimeSource = value;
			}
		}

		private bool _CSharp = true;

		public bool CSharp
		{
			get
			{
				return _CSharp;
			}
			set
			{
				_CSharp = value;
			}
		}

		private bool _VB = true;

		public bool VB
		{
			get
			{
				return _VB;
			}
			set
			{
				_VB = value;
			}
		}

		public CustomToolRegistrationAttribute ( string ToolName )
		{
			_ToolName = ToolName;
		}

		public override void Register ( RegistrationContext Context )
		{
			if ( _CSharp )
			{
				Key oCSKey = Context.CreateKey( string.Format( @"Generators\{0}\{1}", vsContextGuids.vsContextGuidVCSProject, _ToolName ) );

				oCSKey.SetValue( string.Empty, _ToolName );
				oCSKey.SetValue( "CLSID", new Guid( Consts.GUID ).ToString( "B" ) );
				oCSKey.SetValue( "GeneratesDesignTimeSource", _GeneratesDesignTimeSource ? 1 : 0 );
			}

			if ( _VB )
			{
				Key oVBKey = Context.CreateKey( string.Format( @"Generators\{0}\{1}", vsContextGuids.vsContextGuidVBProject, _ToolName ) );

				oVBKey.SetValue( string.Empty, _ToolName );
				oVBKey.SetValue( "CLSID", new Guid( Consts.GUID ).ToString( "B" ) );
				oVBKey.SetValue( "GeneratesDesignTimeSource", _GeneratesDesignTimeSource ? 1 : 0 );
			}
		}

		public override void Unregister ( RegistrationContext Context )
		{
			Context.RemoveKey( string.Format( @"Generators\{0}\{1}", vsContextGuids.vsContextGuidVCSProject, _ToolName ) );
			Context.RemoveKey( string.Format( @"Generators\{0}\{1}", vsContextGuids.vsContextGuidVBProject, _ToolName ) );
		}
	}
}
