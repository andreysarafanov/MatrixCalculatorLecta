using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MatrixCalculator.Domain.Entities;
using MatrixCalculator.IO.File;
using Moq;
using NUnit.Framework;

namespace MatrixCalculator.Tests.Unit
{
	[TestFixture]
	public class FileTaskInfoProviderTests
	{

		private IFileContentProvider PrepareFileContentProvider(string text)
		{
			var fileContentProvider = new Mock<IFileContentProvider>();
			fileContentProvider.Setup(p => p.GetFileContent()).Returns(new StringReader(text));
			return fileContentProvider.Object;
		}

		[TestCaseSource(nameof(CorrectTestCases))]
		public void FileTaskInfoProvider_WhenProvidedWithCorrectText_ReturnsCorrectData((string text, CalculationTask correctTask) param)
		{
			var contentProvider = PrepareFileContentProvider(param.text);
			var taskInfoProvider = new FileTaskInfoProvider(contentProvider);
			var calculationResult = taskInfoProvider.GetTaskDetails();
			Assert.False(calculationResult.IsError);
			Assert.True(TasksAreEqual(param.correctTask, calculationResult.Result));
		}

		[TestCase(MatrixConstants.IncorrectFileExampleOne)]
		[TestCase(MatrixConstants.IncorrectFileExampleTwo)]
		[TestCase(MatrixConstants.IncorrectFileExampleThree)]
		[TestCase(MatrixConstants.IncorrectFileExampleFour)]
		[TestCase(MatrixConstants.IncorrectFileExampleFive)]
		public void FileTaskInfoProvider_WhenProvidedWithIncorrectText_ReturnsError(string text)
		{
			var contentProvider = PrepareFileContentProvider(text);
			var taskInfoProvider = new FileTaskInfoProvider(contentProvider);
			var calculationResult = taskInfoProvider.GetTaskDetails();
			Assert.True(calculationResult.IsError);
		}

		private bool TasksAreEqual(CalculationTask left, CalculationTask right)
		{
			return left.Operation == right.Operation
					&& left.Matrices.Count == right.Matrices.Count
					&& left.Matrices.SequenceEqual(right.Matrices, new MatrixEqualityComparer());
		}

		private static IEnumerable<(string text, CalculationTask task)> CorrectTestCases()
		{
			yield return (
				MatrixConstants.CorrectFileExampleOne,
				new CalculationTask
				{
					Operation = Operation.Multiply, Matrices = new[]
					{
						new Matrix(1, 7, new[] {1, 2, 3, 4, 5, 6, 7}),
						new Matrix(7, 1, new[] {-2, -4, -5, -6, -7, -8, 141}),
					}
				}
			);

			yield return (
				MatrixConstants.CorrectFileExampleTwo,
				new CalculationTask
				{
					Operation = Operation.Transpose, Matrices = new[]
					{
						new Matrix(4, 4, new[] {1, 2, 3, -4, 5, 6, -7, 8, 9, -10, 11, 12, 13, 14, 15, 16}),
						new Matrix(3, 5, new[] {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47}),
						new Matrix(3, 5, new[] {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47}),
					}
				}
			);
		}
	};
}