// See https://aka.ms/new-console-template for more information

using ConsoleApplication;
using DefaultNamespace;

Calculator calculator = new Calculator();

while (true)
{
    var matrixC = CsvReader.readCSV(Console.ReadLine());
    var result = calculator.GetResult(matrixC);

    foreach (var matrix in result)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++) {
                Console.Write("{0:0.00} ", matrix[i, j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    
    }
}


