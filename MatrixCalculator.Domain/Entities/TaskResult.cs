using System;

namespace MatrixCalculator.Domain.Entities
{
	public class TaskResult<TResult, TError>
	{
		private TResult _result;
		private TError _error;
		public bool IsError { get; private set; }

		private TaskResult()
		{
		}

		public void Match(Action<TResult> resultAction, Action<TError> errorAction)
		{
			if (IsError)
			{
				errorAction(Error);
			}
			else
			{
				resultAction(Result);
			}
		}

		public static TaskResult<TResult, TError> FromResult(TResult result)
		{
			return new TaskResult<TResult, TError>
			{
				_result =  result,
				IsError = false
			};
		}

		public static TaskResult<TResult, TError> FromError(TError error)
		{
			return new TaskResult<TResult, TError>
			{
				_error = error,
				IsError = true
			};
		}

		// ReSharper disable once MemberCanBePrivate.Global
		public TResult Result
		{
			get
			{
				if (IsError)
				{
					throw new Exception("Attempt to access result when an error occured");
				}

				return _result;
			}
		}
		// ReSharper disable once MemberCanBePrivate.Global
		public TError Error
		{
			get
			{
				if (!IsError)
				{
					throw new Exception("Attempt to access error when no error occured");
				}

				return _error;
			}
		}
	}
}