using System;

namespace MatrixCalculator.Domain.Entities
{
	public class ResultOrError<TResult, TError>
	{
		private TResult _result;
		private TError _error;
		public bool IsError { get; private set; }

		private ResultOrError()
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

		public static ResultOrError<TResult, TError> FromResult(TResult result)
		{
			return new ResultOrError<TResult, TError>
			{
				_result =  result,
				IsError = false
			};
		}

		public static ResultOrError<TResult, TError> FromError(TError error)
		{
			return new ResultOrError<TResult, TError>
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