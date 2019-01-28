using System;
using System.Collections.Generic;
using MatrixCalculator.Domain.Entities;
using MatrixCalculator.Domain.Interfaces;

namespace MatrixCalculator.Domain.Services
{
	public class TaskRunner : ITaskRunner
	{
		private readonly ITaskInfoReader _infoReader;
		private readonly ITaskResultSaver _resultSaver;
		private readonly IMatricesCalculationService _calculationService;

		public TaskRunner(
			ITaskInfoReader infoReader,
			ITaskResultSaver resultSaver,
			IMatricesCalculationService calculationService)
		{
			_infoReader = infoReader;
			_resultSaver = resultSaver;
			_calculationService = calculationService;
		}

		public void Run()
		{
			_infoReader.GetTaskDetails().Match(PerformTask, _resultSaver.SaveErrorText);
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

		private void Add(Matrix[] matrices)
		{
			var result = _calculationService.SumAllMatrices(matrices);
			result.Match(_resultSaver.SaveResult, _resultSaver.SaveErrorText);
		}

		private void Subtract(Matrix[] matrices)
		{
			var result = _calculationService.SubtractAllMatrices(matrices);
			result.Match(_resultSaver.SaveResult, _resultSaver.SaveErrorText);
		}

		private void Multiply(Matrix[] matrices)
		{
			var result = _calculationService.MultiplyAllMatrices(matrices);
			result.Match(_resultSaver.SaveResult, _resultSaver.SaveErrorText);
		}

		private void Transpose(Matrix[] matrices)
		{
			var result = _calculationService.TransposeAllMatrices(matrices);
			result.Match(_resultSaver.SaveResult, _resultSaver.SaveErrorText);
		}
	}
}