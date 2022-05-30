namespace ConsoleApplication;

public class CsvReader
{
    public static Double[][] readCSV(string path)
    {
        var lines = File.ReadAllLines(path);
        var result = new Double[lines.Length][];
        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            var values = line.Split(';');
            result[i] = new Double[values.Length];
            for (int j = 0; j < values.Length; j++)
            {
                result[i][j] = Double.Parse(values[j]);
            }
        }
        return result;
    }
}