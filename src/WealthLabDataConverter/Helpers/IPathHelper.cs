// =================================================
// File:
// WealthLabDataConverter/WealthLabDataConverter.Library/IPathHelper.cs
// 
// Last updated:
// 2013-08-21 4:24 PM
// =================================================

namespace WealthLabDataConverter.Library.Helpers
{
	public interface IPathHelper
	{
		bool CreateDirectory(string folder);

		bool IsValidPath(string folder);
	}
}
