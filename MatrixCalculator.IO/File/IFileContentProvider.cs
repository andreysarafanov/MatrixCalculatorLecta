using System.IO;

namespace MatrixCalculator.IO.File
{
	public interface IFileContentProvider
	{
		StreamReader GetFileContent();
	}
}