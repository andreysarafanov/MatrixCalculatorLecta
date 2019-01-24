using MatrixCalculator.Domain.Entities;

namespace MatrixCalculator.Domain.Interfaces
{
	public interface IMatrixCalculator
	{
		TaskResult<Matrix, string> AddMatrices(Matrix leftOp, Matrix rightOp);
		TaskResult<Matrix, string> SubtractMatrices(Matrix leftOp, Matrix rightOp);
		TaskResult<Matrix, string> MultiplyMatrices(Matrix leftOp, Matrix rightOp);
		TaskResult<Matrix, string> TransposeMatrix(Matrix matrix);
	}
}