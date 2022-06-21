// See https://aka.ms/new-console-template for more information

using ConsoleApplication;
using DefaultNamespace;

Calculator calculator = new Calculator();

/*
  ____            _  _     _     __    ___            _____ 
 |___ \          | || |   | |   /_ |  / _ \          | ____|
   __) |   __ _  | || |_  | |_   | | | | | |  _ __   | |__  
  |__ <   / _` | |__   _| | __|  | | | | | | | '_ \  |___ \ 
  ___) | | (_| |    | |   | |_   | | | |_| | | | | |  ___) |
 |____/   \__, |    |_|    \__|  |_|  \___/  |_| |_| |____/ 
             | |                                            
             |_|                                            
*/

Console.WriteLine("  ____            _  _     _     __    ___            _____ \n |___ \\          | || |   | |   /_ |  / _ \\          | ____|\n   __) |   __ _  | || |_  | |_   | | | | | |  _ __   | |__  \n  |__ <   / _` | |__   _| | __|  | | | | | | | '_ \\  |___ \\ \n  ___) | | (_| |    | |   | |_   | | | |_| | | | | |  ___) |\n |____/   \\__, |    |_|    \\__|  |_|  \\___/  |_| |_| |____/ \n             | |                                            \n             |_|");
Console.WriteLine("The input is a matrix in the file format .csv\nPlease make sure to use a semicolon (;) to separate the numbers and to put a semicolon at the end of each line.");

while (true)
{
    Console.Write("Enter the path of the .csv matrix file: ");
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


