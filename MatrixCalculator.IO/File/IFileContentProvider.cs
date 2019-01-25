using System.IO;

namespace MatrixCalculator.IO.File
{
	public interface IFileContentProvider
	{
		TextReader GetFileContent();
	}
}