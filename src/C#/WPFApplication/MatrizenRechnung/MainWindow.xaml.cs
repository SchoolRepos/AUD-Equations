using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatrizenRechnung
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[,] parsedQuery;

        int[,] resA;
        int[,] resB;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(toSolve.Document.ContentStart, toSolve.Document.ContentEnd);
            string[] rtbLines = textRange.Text.Split(Environment.NewLine);

            string[,] stringQuery = new string[rtbLines.Length, rtbLines.Length];
            for (int k = 0; k < rtbLines.GetLength(0); k++)
            {
                string[] lineElems = rtbLines[k].Split(" ");
                for (int j = 0; j < lineElems.GetLength(0); k++)
                {
                    stringQuery[k, j] = lineElems[j];
                }
            }

            if (EnsureCorrectInput(stringQuery))
            {
                parsedQuery = Parse(stringQuery);

                GetResults(parsedQuery);
            }
        }

        private void GetResults(int[,] query)
        {
            //TODO
            WriteResults();
        }

        private void WriteResults()
        {
            resAF.Text = resA.ToString();
            resBF.Text = resB.ToString();
        }

        private bool EnsureCorrectInput(string[,] input)
        {
            if (input.Length != input[0, 0].Length)
            {
                return false;
            }

            int tmp = 0;
            for(int j = 0; j < input.GetLength(0); j++)
            {
                for(int k = 0; k < input.GetLength(1); k++)
                {
                    if (!int.TryParse(input[j, k], out tmp))
                    {
                        return false;
                    }
                }
            }
            

            return true;
        }

        private int[,] Parse(string[,] query)
        {
            int[,] result = new int[query.Length, query[0, 0].Length];
            for (int k = 0; k < query.GetLength(0); k++)
                for (int l = 0; l < query.GetLength(1); l++)
                    result[k, l] = int.Parse(query[k, l]);

            return result;
        }
    }
}
