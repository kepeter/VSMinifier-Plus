using System;
namespace VSMinifier
{
	public class Consts
	{
		public const string Me = "VSMinifier";

		public const string GUID = "4CC31BE6-1F86-416C-962F-2DBAA8B5F1B4";

		public static readonly Guid MenuGUID = new Guid( "E6315A3D-320F-4B5E-B626-63D1FB730B94" );

		public const uint CompileTargetCommand = 0x100;
		public const uint CompileTargetCommandList = 0x110;

		public const string JSExt = ".js";
		public const string JSMinExt = ".min.js";

		public const string CSSExt = ".css";
		public const string CSSMinExt = ".min.css";
	}

	public enum BuildActionType
	{
		Default,
		Copy,
		Custom
	}

	public enum CompileTargetType
	{
		Default,
		Mixed
	}

	public enum JSEngineType
	{
		YUICompressor,
		MicrosoftAjaxMinifier,
		GoogleClosureCompiler
	}

	public enum CSSEngineType
	{
		YUICompressor,
		MicrosoftAjaxMinifier,
	}
}
