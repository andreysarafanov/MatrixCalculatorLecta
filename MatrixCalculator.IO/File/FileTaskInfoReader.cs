using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using MatrixCalculator.Domain.Entities;
using MatrixCalculator.Domain.Interfaces;

namespace MatrixCalculator.IO.File
{
	public class FileTaskInfoReader: ITaskInfoReader
	{
		private const string MultiplyString = "multiply";
		private const string AddString = "add";
		private const string SubtractString = "subtract";
		private const string TransposeString = "transpose";

		private static readonly IReadOnlyCollection<Operation> TwoOperandsOperations = new[]
		{
			Operation.Add, Operation.Multiply, Operation.Subtract
		};

		private readonly IFileContentProvider _fileContentProvider;

		public FileTaskInfoReader(IFileContentProvider fileContentProvider)
		{
			_fileContentProvider = fileContentProvider;
		}

		public ResultOrError<CalculationTask, string> GetTaskDetails()
		{
			using (var streamReader = _fileContentProvider.GetFileContent())
			{
				var text = streamReader.ReadToEnd();
				var parts = text.Split(new[] {Environment.NewLine + Environment.NewLine},
					StringSplitOptions.RemoveEmptyEntries);
				if (parts.Length < 2)
				{
					return ResultOrError<CalculationTask, string>.FromError("Некорректный формат");
				}

				var operation = ParseOperation(parts.First());
				if (operation == null)
				{
					return ResultOrError<CalculationTask, string>.FromError($"Неизвестная операция {parts.First()}");
				}

				if (TwoOperandsOperations.Contains(operation.Value) && parts.Length < 3)
				{
					return ResultOrError<CalculationTask, string>.FromError("Для сложения/вычитания/умножения нужно как минимум две матрицы");
				}

				Matrix[] matrices = new Matrix[parts.Length - 1];
				for (var i = 1; i < parts.Length; i++)
				{
					var matrixOrError = ParseMatrix(parts[i]);
					if (matrixOrError.IsError)
					{
						return ResultOrError<CalculationTask, string>.FromError($"Ошибка в матрице #{i - 1}: {matrixOrError.Error}");
					}

					matrices[i - 1] = matrixOrError.Result;
				}

				return ResultOrError<CalculationTask, string>.FromResult(new CalculationTask
				{
					Matrices = matrices,
					Operation = operation.Value
				});
			}
		}

		private Operation? ParseOperation(string s)
		{
			switch (s)
			{
				case MultiplyString:
					return Operation.Multiply;
				case AddString:
					return Operation.Add;
				case SubtractString:
					return Operation.Subtract;
				case TransposeString:
					return Operation.Transpose;
				default:
					return null;
			}
		}

		private ResultOrError<Matrix, string> ParseMatrix(string s)
		{
			var lines = s.Split(new[] {Environment.NewLine}, StringSplitOptions.None).ToArray();
			var firstLineWidth = 0;
			Matrix result = null;
			for (var i = 0; i < lines.Length; i++)
			{
				var line = lines[i].Split(' ')
					.Select(intString => Int32.TryParse(intString, out var x)
						? ResultOrError<int, string>.FromResult(x)
						: ResultOrError<int, string>.FromError($"{intString} не является валидным числом"))
					.ToArray();

				if (!line.Any())
				{
					return ResultOrError<Matrix, string>.FromError("В матрице не могут быть пустые строки");
				}
				if (line.Any(n => n.IsError))
				{
					return ResultOrError<Matrix, string>.FromError(line.First(n => n.IsError).Error);
				}

				if (i == 0)
				{
					firstLineWidth = line.Length;
					result = new Matrix(lines.Length, line.Length);
				}

				if (line.Length != firstLineWidth)
				{
					return ResultOrError<Matrix, string>.FromError($"Число элементов в строке #{i+1} отличается от первой строки");
				}

				for (var j = 0; j < firstLineWidth; j++)
				{
					// ReSharper disable once PossibleNullReferenceException
					result.ValuesOneDimensional[i * firstLineWidth + j] = line[j].Result;
				}
			}
			return ResultOrError<Matrix, string>.FromResult(result);
		}
	}
}