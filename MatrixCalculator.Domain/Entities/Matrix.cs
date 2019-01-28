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
				return ValuesOneDimensional[j * Width + i];
			}
			set
			{
				CheckBounds(i, j);
				ValuesOneDimensional[j * Width + i] = value;
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

			Width = width;
			Height = height;
			ValuesOneDimensional = valuesOneDimensional;
		}

		public Matrix(int height, int width)
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