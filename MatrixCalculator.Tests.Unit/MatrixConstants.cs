using System;
using System.Linq;
using MatrixCalculator.Domain.Entities;

namespace MatrixCalculator.Tests.Unit
{
	public class MatrixConstants
	{
		public const string CorrectFileExampleOne = @"multiply
1 2 3 4 5 6 7

2
4
5
6
7
8
141";

		public const string CorrectFileExampleTwo = @"transpose
1 2 3 4
5 6 7 8
9 10 11 12
13 14 15 16

2 3 5 7 11
13 17 19 23 29
31 37 41 43 47

2 3 5 7 11
13 17 19 23 29
31 37 41 43 47
";

		public const string IncorrectFileExampleOne = @"almost_transpose
1 2 3 4
5 6 7 8
9 10 11 12
13 14 15 16

2 3 5 7 11
13 17 19 23 29
31 37 41 43 47
";

		public const string IncorrectFileExampleTwo = @"multiply
1 2 3 4
5 6 7 8
9 10 11 12
13 14 15 16

1 2 3 4
5 6 7 8
9 10 11 12
13 14 15 16

2 3 5 7 11
13 17 19 23 29 31 52
31 37 41 43 47
";

		public const string IncorrectFileExampleThree = @"transpose
1 2 3 4
5 6 7 8
9 10
13 14 15 16

2 3 5 7 11
13 17 19 23 29
31 37 41 43 47
";

		public const string IncorrectFileExampleFour = @"transpose
1 2 3 4
5 6 7 8
9 10 11 12a
13 14 15 16

2 3 5 7 11
13 17 19 23 29
31 37 41 43 47
";


	}
}