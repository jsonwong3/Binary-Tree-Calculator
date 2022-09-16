// Project Name: A3_LL_BT
// File Name: BinaryTreeCalculator
// Author: Jason Wong
// Due Date: April 14 2017
// Modified Data: April 18 2017
// Program Description: Performs a mathematical problem given in prefix form and converts prefix equation into infix form
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Output Variables
            string output;
            double result;  
            int count = 0;

            //File IO Variable
            StreamWriter WriteFile;

            //Increase buffer size for a neater output display
            Console.SetBufferSize(100, 100);

            if (File.Exists("input.txt"))
            {
                //Reads the given input.txt file and clears the solution text file
                string[] prefix = File.ReadAllLines("input.txt");
                File.WriteAllText("WongJ.txt", string.Empty);

                foreach (string line in prefix)
                {
                    WriteFile = File.AppendText("WongJ.txt");

                    //Creates a new binary tree for each line
                    BinaryTree function = new BinaryTree(line);

                    //Calculates the result of the binary tree
                    result = function.CalculateTree(function.GetRoot());

                    //Tracks the expression which is currently being solved
                    count++;

                    //If the result returns a NaN, it is treated as an invalid expression and displays error in the following format;
                    //"Expresstion [Expression Number] [Prefix Equation] : Invaild Expression"
                    //Otherwise, display all the information necessary in the following format;
                    //"Expresstion [Expression Number] [Prefix Equation] : [Infix Equation] = [Result of Equation]"
                    if (double.IsNaN(result))
                    {
                        output = "Expresstion " + count + " (" + line + "): Invalid Expression";
                    }
                    else
                    {
                        output = "Expresstion " + count + " (" + line + "): " + function.InfixDisplay(function.GetRoot()) + " = " + result;
                    }

                    //Writes the output in the console as well as in the solution file
                    Console.WriteLine(output);
                    WriteFile.WriteLine(output);
                    WriteFile.Close();
                }
            }
            else
            {
                Console.WriteLine("The input.txt file could not be found");
            }

            Console.ReadLine();
        }
    }
}
