namespace DefaultNamespace;

public class Calculator
{
    public List<Double[][]> GetResult(Double[][] matrixC)
    {
        Double[][] matrixA = new Double[matrixC.Length][];
        Double[][] matrixB = new Double[matrixC.Length][];
        
        //fill zeros
        for (int i = 0; i < matrixC.Length; i++)
        {
            for (int j = 0; j < matrixC.Length; j++)
            {
                matrixA[i][j] = 0;
                matrixB[i][j] = 0;
            }
        }

        //fill ones
        for (int i = 0; i < matrixC.Length; i++)
        {
            matrixA[i][i] = 1;
        }
        
        //fill first B row
        for (int i = 0; i < matrixC.Length; i++)
        {
            matrixB[i][i] = matrixC[i][i];
        }
        
        //second row
        for (int i = 1; i < matrixC.Length; i++)
        {
            matrixA[i][0] = matrixC[i][0] / matrixB[0][0];
            for (int j = 0; j < i; j++)
            {
                
            }
        }
        
        var result = new List<Double[][]>();
        result.Add(matrixA);
        result.Add(matrixB);
        return result;
    }
    
    
}