// See https://aka.ms/new-console-template for more information

using ConsoleApplication;
using DefaultNamespace;

Calculator calculator = new Calculator();

//var matrixC = new Double[4, 4] { {2.0, 7.0, 1.0, 8.0}, {3.0, -2.0, 8.0, 13.0}, {1.0, 5.0, 2.82, 12.88}, {12.2, 37.7, 18.0, 80.4} };
var matrixC = new Double[3, 3] { {2.0, 7.0, 1.0}, {3.0, -2.0, 8.0}, {1.0, 5.0, 3.0} };
var result = calculator.GetResult(matrixC);

foreach (var matrix in result)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++) {
            Console.Write("{0} ", matrix[i, j]);
        }
        Console.WriteLine();
    }
    Console.WriteLine();
    
}

