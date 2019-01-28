using System.IO;

namespace MatrixCalculator.IO.FileWrite
{
	public interface IFileWriteStreamProvider
	{
		TextWriter GetWriteStream();
	}
}