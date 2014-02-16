using System.Net;
using System.Web;
using System;

namespace VSMinifier
{
	public enum CompilationLevel
	{
		WHITESPACE_ONLY = 0,
		SIMPLE_OPTIMIZATIONS = 1,
		ADVANCED_OPTIMIZATIONS = 2
	}

	public class GoogleClosure
	{
		private const string _ApiEndpoint = "http://closure-compiler.appspot.com/compile";
		private const string _PostData = "js_code={0}&compilation_level={1}&output_format=text&output_info=compiled_code";

		public string Compress ( string Input, CompilationLevel CompilationLevel )
		{
			WebClient oClient = new WebClient( );

			oClient.Headers.Add( "content-type", "application/x-www-form-urlencoded" );

			string szPostData = string.Format( _PostData, HttpUtility.UrlEncode( Input ), Enum.GetName( typeof( CompilationLevel ), CompilationLevel ) );
			string szResult = oClient.UploadString( _ApiEndpoint, szPostData );

			return ( szResult );
		}
	}
}
