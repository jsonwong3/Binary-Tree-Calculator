// Project Name: A3_LL_BT
// File Name: Node
// Author: Jason Wong
// Due Date: April 14 2017
// Modified Data: April 16 2017
// Program Description: Constructs a node for the binary tree
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Node
    {
        //Cargo Variable
        private string cargo;

        //Branch Variables
        private Node left;
        private Node right;

        /// <summary>
        /// Constructor for a node, branches will automatically be null
        /// </summary>
        /// <param name="cargo">A string with a single length of one</param>
        public Node(string cargo)
        {
            this.cargo = cargo;
        }

        /// <summary>
        /// Sets the current node's right branch
        /// </summary>
        /// <param name="node">A non null node</param>
        public void SetRight(Node node)
        {
            right = node;
        }

        /// <summary>
        /// Sets the current node's left branch
        /// </summary>
        /// <param name="node">A none Node branch</param>
        public void SetLeft(Node node)
        {
            left = node;
        }

        /// <summary>
        /// Gets the current node's cargo
        /// </summary>
        /// <returns>Current node's cargo as a string</returns>
        public string GetCargo()
        {
            return cargo;
        }

        /// <summary>
        /// Gets the current node's right child
        /// </summary>
        /// <returns>Right child as a node</returns>
        public Node GetNextR()
        {
            return right;
        }

        /// <summary>
        /// Gets the current node's left child
        /// </summary>
        /// <returns>Left child as a node</returns>
        public Node GetNextL()
        {
            return left;
        }
    }
}
