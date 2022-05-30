namespace DefaultNamespace;

public class Calculator
{
    public List<Double[,]> GetResult(Double[,] matrixC)
    {
        Double[,] matrixA = new Double[matrixC.GetLength(1), matrixC.GetLength(1)];
        Double[,] matrixB = new Double[matrixC.GetLength(1), matrixC.GetLength(1)];
        
        //fill zeros
        for (int i = 0; i < matrixC.GetLength(1); i++)
        {
            for (int j = 0; j < matrixC.GetLength(1); j++)
            {
                matrixA[i,j] = 0;
                matrixB[i,j] = 0;
            }
        }

        //fill ones
        for (int i = 0; i < matrixC.GetLength(1); i++)
        {
            matrixA[i,i] = 1;
        }
        
        //fill first B row
        for (int i = 0; i < matrixC.GetLength(1); i++)
        {
            matrixB[0,i] = matrixC[0,i];
        }
        
        //second row
        for (int i = 1; i < matrixC.GetLength(1); i++)
        {
            matrixA[i,0] = matrixC[i,0] / matrixB[0,0];
            //fill A of row
            for (int j = 1; j < i; j++)
            {
                // 𝒂43 = (𝑐43 − 𝑎42 ⋅ 𝑏13)/𝑏33 
                matrixA[i,j] = (matrixC[i,j] - matrixA[i,j-1] * matrixB[0,j] ) / matrixB[i-1,j];
            }
            
            //fill B of row
            for (int j = i; j < matrixC.GetLength(1); j++)
            {
                var number = 0.0;
                
                for (int k = 0; k < i; k++)
                {
                    number += matrixA[i,k] * matrixB[k,j];
                }
                
                matrixB[i,j] = matrixC[i,j] - number;
            }
        }
        
        var result = new List<Double[,]>();
        result.Add(matrixA);
        result.Add(matrixB);
        return result;
    }
    
    
}