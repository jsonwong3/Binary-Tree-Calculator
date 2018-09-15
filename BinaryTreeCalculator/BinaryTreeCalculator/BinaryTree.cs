// Project Name: A3_LL_BT
// File Name: BinaryTree
// Author: Jason Wong
// Due Date: April 14 2017
// Modified Data: April 18 2017
// Program Description: Constructs a binary tree for a prefix equation
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class BinaryTree
    {
        //Constructor Variable
        private Node root;
        private string prefix;
        private int count = 0;

        //Calculation Variable
        private double answer = 0;

        /// <summary>
        /// Constructor for an equations binary tree
        /// </summary>
        /// <param name="Prefix">A single lined prefix input from the text file</param>
        public BinaryTree(string Prefix)
        {
            this.prefix = Prefix;

            //Tries to take the first character from the string to create the root
            //Catches the exception that the prefix has a length of zero
            try
            {
                //Creates a new node for the root of the binary tree to be set to
                Node newNode = new Node(Prefix.Substring(count, 1));
                root = newNode;
                count++;

                //Only continues building the tree if the root is an operation
                if (root.GetCargo() == "+" || root.GetCargo() == "-" || root.GetCargo() == "*" || root.GetCargo() == "/" || root.GetCargo() == "^")
                {
                    TreeBuilder(root, Prefix);
                }
            }
            catch (Exception exp)
            {
                //Give the root an arbitrary value
                //Set up the count counter to trigger CalculateTree's first vadility check
                Node newNode = new Node("");
                root = newNode;
                count = -1;
            }
        }

        /// <summary>
        /// Gets the root of the binary tree
        /// </summary>
        /// <returns>The root of the binary tree</returns>
        public Node GetRoot()
        {
            return root;
        }

        /// <summary>
        /// Sets the left and right nodes of our curNode to the first two letters of our prefix accordingly
        /// Uses recursives methods if certain conditions are met
        /// </summary>
        /// <param name="curNode">Either the root of the equation or a branch</param>
        /// <param name="Prefix">Prefix input from the text file</param>
        public void TreeBuilder(Node curNode, string Prefix)
        {
            //Create a new node for the current nodes left branch to 
            Node leftNode = new Node(Prefix.Substring(count, 1));
            curNode.SetLeft(leftNode);
            count++;

            //Call TreeBuilder again if the left branch is an operation
            //Sets the TreeBuilder parameter to the current node's left branch asa well as the same prefix
            if (leftNode.GetCargo() == "+" || leftNode.GetCargo() == "-" || leftNode.GetCargo() == "*" || leftNode.GetCargo() == "/" || leftNode.GetCargo() == "^")
            {
                TreeBuilder(curNode.GetNextL(), Prefix);
            }

            //Create a new node for the current nodes right branch to 
            Node rightNode = new Node(Prefix.Substring(count, 1));
            curNode.SetRight(rightNode);
            count++;

            //Call TreeBuilder again if the right branch is an operation
            //Sets the TreeBuilder parameter to the current node's right branch asa well as the same prefix
            if (rightNode.GetCargo() == "+" || rightNode.GetCargo() == "-" || rightNode.GetCargo() == "*" || rightNode.GetCargo() == "/" || rightNode.GetCargo() == "^")
            {
                TreeBuilder(curNode.GetNextR(), Prefix);
            }
        }

        /// <summary>
        /// Converts the binary tree of the prefix equation into an infix equation
        /// </summary>
        /// <param name="curNode">Either the root of the equation or the branch</param>
        /// <returns>The infix equation of the binary tree</returns>
        public string InfixDisplay(Node curNode)
        {
            //Calls InfixDisplay on both left and right branches if the current node is an operation
            //Otherwise, return the current nodes cargo with the appropriate spacing
            if (curNode.GetCargo() == "+" || curNode.GetCargo() == "-" || curNode.GetCargo() == "*" || curNode.GetCargo() == "/" || curNode.GetCargo() == "^")
            {
                return "(" + InfixDisplay(curNode.GetNextL()) + " " + curNode.GetCargo() + " " + InfixDisplay(curNode.GetNextR()) + ")";
            }
            else
            {
                return " " + curNode.GetCargo() + " ";
            }
        }

        /// <summary>
        /// Calculates the value of the binary tree
        /// </summary>
        /// <param name="curNode">Either the root of the equation or the branch</param>
        /// <returns>double.Nan if the expression is invalid. Otherwise returns the value of the expression</returns>
        public double CalculateTree(Node curNode)
        {
            //For the binary tree to be properly constructed, all of the prefix characters should be used
            //If the count counter does not equal to the lenght of our prefix string, it proves that the binary tree was not properly built      
            if (count != prefix.Count())
            {
                return double.NaN;
            }

            //Catches any errors within the equation such as;
            //Dividing by zero
            //Converting non numeric values; Example: "a", " ", "$"
            try
            {
                //Executes all calculations here
                //Calls CalculateTree until it returns the default scenario
                //Default scenario converts the string into a double, operators would have been already be dealt with
                //Anything other than a numberic value would mean the binary tree was not construction properly
                switch (curNode.GetCargo())
                {
                    case ("+"):
                        answer = +CalculateTree(curNode.GetNextL()) + CalculateTree(curNode.GetNextR());
                        return answer;
                    case ("-"):
                        answer = +CalculateTree(curNode.GetNextL()) - CalculateTree(curNode.GetNextR());
                        return answer;
                    case ("/"):
                        answer = +CalculateTree(curNode.GetNextL()) / CalculateTree(curNode.GetNextR());
                        return answer;
                    case ("*"):
                        answer = +CalculateTree(curNode.GetNextL()) * CalculateTree(curNode.GetNextR());
                        return answer;
                    case ("^"):
                        answer = +Math.Pow(CalculateTree(curNode.GetNextL()), CalculateTree(curNode.GetNextR()));
                        return answer;
                    default:
                        return Convert.ToDouble(curNode.GetCargo());
                }
            }
            catch (Exception exp)
            {
                return double.NaN;
            }
        }
    }
}