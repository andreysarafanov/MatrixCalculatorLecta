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

		public Matrix(int height, int width, int[] valuesOneDimensional)
		{
			if (valuesOneDimensional.Length != width * height)
			{
				throw new ArgumentException("The number of elements in a matrix should be Width * Height");
			}

			Height = height;
			Width = width;
			ValuesOneDimensional = valuesOneDimensional;
		}

		public Matrix(int height, int width)
		{
			Height = height;
			Width = width;
			ValuesOneDimensional = new int[width * height];
		}

		private void CheckBounds(int i, int j)
		{
			if (i < 0 || i >= Height || j < 0 || j >= Width)
			{
				throw new IndexOutOfRangeException();
			}
		}
	}
}