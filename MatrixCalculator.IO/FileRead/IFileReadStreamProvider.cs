using System.IO;

namespace MatrixCalculator.IO.FileRead
{
	public interface IFileReadStreamProvider
	{
		TextReader GetFileContent();
	}
}