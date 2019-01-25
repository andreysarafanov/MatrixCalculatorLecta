using System;

namespace MatrixCalculator.Domain.Entities
{
	public class Matrix
	{
		public int[] ValuesOneDimensional { get; }

		public int this[int i, int j]
		{
			get
			{
				CheckBounds(i, j);
				return ValuesOneDimensional[i * Width + j];
			}
			set
			{
				CheckBounds(i, j);
				ValuesOneDimensional[i * Width + j] = value;
			}
		}

		public int Width { get; set; }
		public int Height { get; set; }

		public Matrix(int width, int height, int[] valuesOneDimensional)
		{
			if (valuesOneDimensional.Length != width * height)
			{
				throw new ArgumentException("The number of elements in a matrix should be Width * Height");
			}

			Width = width;
			Height = height;
			ValuesOneDimensional = valuesOneDimensional;
		}

		public Matrix(int width, int height)
		{
			Width = width;
			Height = height;
			ValuesOneDimensional = new int[width * height];
		}

		private void CheckBounds(int i, int j)
		{
			if (i < 0 || i >= Width || j < 0 || j >= Height)
			{
				throw new IndexOutOfRangeException();
			}
		}
	}
}