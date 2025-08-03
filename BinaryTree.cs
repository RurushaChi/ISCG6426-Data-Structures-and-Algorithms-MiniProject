using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{
    internal class BinaryTree
    {

        static Random random = new Random();

        // THIS METHOD GENERATES A BINARY TREE
        public static int[] GenerateBinaryTreeArray(int size)
        {
            int[] treeArray = new int[size];
            for (int i = 0; i < treeArray.Length;i++)
            {
                treeArray[i] = -1; // fill array with -1 to represent empty nodes
            }
            
            // make sure root is present
            treeArray[0] = random.Next(1, 100);

            for (int i = 1; i < size; i++)
            {
                // Randomly decide if a node should exist at this position
                if (random.Next(0, 2) == 1)
                {
                    // Add a node only if its parent exists
                    int parentIndex = (i - 1) / 2;
                    if (treeArray[parentIndex] != -1)
                    {
                        treeArray[i] = random.Next(1, 100); // Assign a random value
                    }
                }
            }
            

            return treeArray;
        }
        
       
        //THIS METHOD CALLS A TRAVERSAL BASED ON THE USERS SELCTION
        public static int[] generateTraversalIndexes(int selection, int[] binaryTree)
        {
            int[] traversalType;
            
            
            if (selection == 1)
            {
                traversalType = inorder_GenerateTraversal(binaryTree);
               
            }
            else if (selection == 2)
            {
                traversalType = preorder_GenerateTraversal(binaryTree);
            }
            else 
            {
                traversalType = postorder_GenerateTraversal(binaryTree);
            }
            return traversalType;
        }


        //THIS METHOD GENERATES A INORDER TRAVERSAL ORDER FOR BINARY TREE THAT WAS CREATED
        public static int[] inorder_GenerateTraversal(int[] binaryTree)
        {
            //InOrder Traversal
            int[] inOrderTraversal = new int[] { 7, 3, 8, 1, 9, 4, 10, 0, 11, 5, 12, 2, 13, 6, 14 };
            
            int customInorderTraversalCount = 0;

            for (int i = 0; i < binaryTree.Length; i++)
            {
                if (binaryTree[i] != -1)
                { 
                    customInorderTraversalCount++;
                }
            }

           
            int[] customInorderTraversal= new int[customInorderTraversalCount];

            int b = 0;

            for ( int i=0;i < binaryTree.Length; i++)
            {
                int checker = inOrderTraversal[i];
                if (binaryTree[checker] != -1)
                {
                    customInorderTraversal[b] = inOrderTraversal[i];
                    b++;
                }
                
            }

            return customInorderTraversal;
            
            

        }

        //THIS METHOD GENERATES A PREORDER TRAVERSAL ORDER FOR BINARY TREE THAT WAS CREATED
        public static int[] preorder_GenerateTraversal(int[] binaryTree)
        {
            //InOrder Traversal
            int[] preorderTraversal = [0, 1, 3, 7, 8, 4, 9, 10, 2, 5, 11, 12, 6, 13, 14];

            int customPreorderTraversalCount = 0;


            for (int i = 0; i < binaryTree.Length; i++)
            {
                if (binaryTree[i] != -1)
                {
                    customPreorderTraversalCount++;
                }
            }


            int[] customPreorderTraversal = new int[customPreorderTraversalCount];
            int b = 0;
            for (int i = 0; i < binaryTree.Length; i++)
            {

                int checker = preorderTraversal[i];
                if (binaryTree[checker] != -1)
                {
                    customPreorderTraversal[b] = preorderTraversal[i];
                    b++;
                }


            }

            return customPreorderTraversal;

        }

        //THIS METHOD GENERATES A POSTORDER TRAVERSAL ORDER FOR BINARY TREE THAT WAS CREATED
        public static int[] postorder_GenerateTraversal(int[] binaryTree)
        {
            //InOrder Traversal
            int[] postorderTraversal = [7, 8, 3, 9, 10, 4, 1, 11, 12, 5, 13, 14, 6, 2, 0];

            int customPostorderTraversalCount = 0;

            for (int i = 0; i < binaryTree.Length; i++)
            {
                if (binaryTree[i] != -1)
                {
                    customPostorderTraversalCount++;
                }
            }


            int[] customPostorderTraversal = new int[customPostorderTraversalCount];
            int b = 0;
            for (int i = 0; i < binaryTree.Length; i++)
            {

                int checker = postorderTraversal[i];
                if (binaryTree[checker] != -1)
                {
                    customPostorderTraversal[b] = postorderTraversal[i];
                    b++;
                }
            }

            return customPostorderTraversal;

        }
    }
}
