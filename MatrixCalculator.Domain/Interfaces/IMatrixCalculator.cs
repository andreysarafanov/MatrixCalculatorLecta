using MatrixCalculator.Domain.Entities;

namespace MatrixCalculator.Domain.Interfaces
{
	public interface IMatrixCalculator
	{
		ResultOrError<Matrix, string> AddMatrices(Matrix leftOp, Matrix rightOp);
		ResultOrError<Matrix, string> SubtractMatrices(Matrix leftOp, Matrix rightOp);
		ResultOrError<Matrix, string> MultiplyMatrices(Matrix leftOp, Matrix rightOp);
		Matrix TransposeMatrix(Matrix matrix);
	}
}