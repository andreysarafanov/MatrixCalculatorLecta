using System;
using System.Collections.Generic;
using MatrixCalculator.Domain.Entities;
using MatrixCalculator.Domain.Interfaces;

namespace MatrixCalculator.Domain
{
	public class TaskRunner : ITaskRunner
	{
		private readonly ITaskInfoProvider _infoProvider;
		private readonly ITaskResultSaver _resultSaver;
		private readonly IMatricesCalculationService _calculationService;

		public TaskRunner(
			ITaskInfoProvider infoProvider,
			ITaskResultSaver resultSaver,
			IMatricesCalculationService calculationService)
		{
			_infoProvider = infoProvider;
			_resultSaver = resultSaver;
			_calculationService = calculationService;
		}

		public void Run()
		{
			_infoProvider.GetTaskDetails().Match(PerformTask, _resultSaver.SaveErrorText);
		}

		private void PerformTask(CalculationTask task)
		{
			switch (task.Operation)
			{
				case Operation.Add:
					Add(task.Matrices);
					break;
				case Operation.Subtract:
					Subtract(task.Matrices);
					break;
				case Operation.Multiply:
					Multiply(task.Matrices);
					break;
				case Operation.Transpose:
					Transpose(task.Matrices);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private void Add(IReadOnlyCollection<Matrix> matrices)
		{
			var result = _calculationService.SumAllMatrices(matrices);
			result.Match(_resultSaver.SaveResult, _resultSaver.SaveErrorText);
		}

		private void Subtract(IReadOnlyCollection<Matrix> matrices)
		{
			var result = _calculationService.SubtractAllMatrices(matrices);
			result.Match(_resultSaver.SaveResult, _resultSaver.SaveErrorText);
		}

		private void Multiply(IReadOnlyCollection<Matrix> matrices)
		{
			var result = _calculationService.MultiplyAllMatrices(matrices);
			result.Match(_resultSaver.SaveResult, _resultSaver.SaveErrorText);
		}

		private void Transpose(IReadOnlyCollection<Matrix> matrices)
		{
			var result = _calculationService.TransposeAllMatrices(matrices);
			result.Match(_resultSaver.SaveResult, _resultSaver.SaveErrorText);
		}
	}
}