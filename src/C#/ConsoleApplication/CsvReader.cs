namespace ConsoleApplication;

public class CsvReader
{
    public static Double[,] readCSV(string path)
    {
        var lines = File.ReadAllLines(path);
        var result = new Double[lines.Length,lines.Length];
        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            var values = line.Split(';');
            for (int j = 0; j < values.Length-1; j++)
            {
                result[i,j] = Double.Parse(values[j]);
            }
        }
        return result;
    }
}