using System;
using System.Collections.Generic;
using System.Text;
using MatrixCalculator.Domain.Entities;
using MatrixCalculator.Domain.Interfaces;

namespace MatrixCalculator.IO.FileWrite
{
	public class FileResultWriter: ITaskResultSaver
	{
		private readonly IFileWriteStreamProvider _fileWriteStreamProvider;

		public FileResultWriter(IFileWriteStreamProvider fileWriteStreamProvider)
		{
			_fileWriteStreamProvider = fileWriteStreamProvider;
		}

		public void SaveResult(IReadOnlyList<Matrix> matrices)
		{
			using (var writer = _fileWriteStreamProvider.GetWriteStream())
			{
				writer.Write(GetMatrixRepresentation(matrices));
			}
		}

		public void SaveResult(Matrix matrix)
		{
			using (var writer = _fileWriteStreamProvider.GetWriteStream())
			{
				writer.Write(GetMatrixRepresentation(new[] {matrix}));
			}
		}

		public void SaveErrorText(string text)
		{
			using (var writer = _fileWriteStreamProvider.GetWriteStream())
			{
				writer.Write(text);
			}
		}

		private string GetMatrixRepresentation(IReadOnlyList<Matrix> matrices)
		{
			StringBuilder sb = new StringBuilder();
			for (var m = 0; m < matrices.Count; m++)
			{
				if (m > 0)
				{
					sb.Append(Environment.NewLine);
					sb.Append(Environment.NewLine);
				}
				for (var i = 0; i < matrices[m].Height; i++)
				{
					if (i > 0)
					{
						sb.Append(Environment.NewLine);
					}

					for (var j = 0; j < matrices[m].Width; j++)
					{
						if (j > 0)
						{
							sb.Append(" ");
						}

						sb.Append(matrices[m][i, j]);
					}
				}
			}

			return sb.ToString();
		}
	}
}