using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStLab7._1
{
    // Düğüm Sınıfı
    class TreeNode
    {
        public int data;
        public TreeNode leftChild;
        public TreeNode rightChild;
        public void displayNode() { Console.Write(" " + data + " "); }
    }

    // Agaç Sınıfı
    class Tree
    {
        private TreeNode root;

        public Tree() { root = null; }

        public TreeNode getRoot()
        { return root; }

        // Agacın preOrder Dolasılması
        public void preOrder(TreeNode localRoot)
        {
            if (localRoot != null)
            {
                localRoot.displayNode();
                preOrder(localRoot.leftChild);
                preOrder(localRoot.rightChild);
            }
        }

        // Agacın inOrder Dolasılması
        public void inOrder(TreeNode localRoot)
        {
            if (localRoot != null)
            {
                inOrder(localRoot.leftChild);
                localRoot.displayNode();
                inOrder(localRoot.rightChild);
            }
        }

        // Agacın postOrder Dolasılması
        public void postOrder(TreeNode localRoot)
        {
            if (localRoot != null)
            {
                postOrder(localRoot.leftChild);
                postOrder(localRoot.rightChild);
                localRoot.displayNode();
            }
        }

        // Agaca bir dügüm eklemeyi saglayan metot
        public void insert(int newdata)
        {
            TreeNode newNode = new TreeNode();
            newNode.data = newdata;
            if (root == null)
                root = newNode;
            else
            {
                TreeNode current = root;
                TreeNode parent;
                while (true)
                {
                    parent = current;
                    if (newdata < current.data)
                    {
                        current = current.leftChild;
                        if (current == null)
                        {
                            parent.leftChild = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.rightChild;
                        if (current == null)
                        {
                            parent.rightChild = newNode;
                            return;
                        }
                    }
                } // end while
            } // end else not root
        } // end insert()

    } // class Tree


    // Test Sınıfı
    class TreeTest
    {
        static Random r = new Random();
        static void Main(string[] args)
        {
            Tree agac = new Tree();

            // Ağaca 10 tane sayı yerleştirilmesi
            Console.WriteLine("Sayılar : ");
            for (int i = 0; i < 10; ++i)
            {
                int sayi = (int)(r.Next(100));
                Console.Write(sayi + " ");
                agac.insert(sayi);
            };

            Console.Write("\nAgacın InOrder Dolasılması : ");
            agac.inOrder(agac.getRoot());
            Console.Write("\nAgacın PreOrder Dolasılması : ");
            agac.preOrder(agac.getRoot());
            Console.Write("\nAgacın PostOrder Dolasılması : ");
            agac.postOrder(agac.getRoot());
            Console.ReadKey();
        }

        public static void TreeInfo(Tree agac){

            int maxDepth = 0;
            List<int> DepthElementCount = new List<int>();
            List<int> DepthElementSum = new List<int>();

            TraverselNode(agac.getRoot(),0,ref maxDepth,DepthElementCount,DepthElementSum);

        }

        public static void TraverselNode(TreeNode node, int depth,ref int maxDepth, List<int> DepthElementCount, List<int> DepthElementSum) {

            if(node == null)
            {
                return;
            }
            
            if(depth > maxDepth) 
            {
                maxDepth = depth;
                DepthElementCount.Add(0);
                DepthElementSum.Add(0);
            }
            DepthElementCount[depth] += 1;
            DepthElementSum[depth] += node.data;

            TraverselNode(node.leftChild, depth + 1, ref maxDepth, DepthElementCount, DepthElementSum);
            TraverselNode(node.rightChild, depth + 1, ref maxDepth, DepthElementCount, DepthElementSum);
        }
    }
}
