using System.Collections.Generic;
using System.Linq;
using MatrixCalculator.Domain.Entities;

namespace MatrixCalculator.Tests.Unit
{
	public class MatrixEqualityComparer: IEqualityComparer<Matrix>
	{
		public bool Equals(Matrix x, Matrix y)
		{
			if (x == null && y == null)
			{
				return true;
			}
			return x != null && y != null && x.Width == y.Width && x.Height == y.Height &&
					x.ValuesOneDimensional.SequenceEqual(y.ValuesOneDimensional);
		}

		public int GetHashCode(Matrix obj)
		{
			return obj.GetHashCode();
		}
	}
}