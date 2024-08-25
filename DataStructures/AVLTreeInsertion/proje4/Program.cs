using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTreeInsertion
{
    //https://www.geeksforgeeks.org/insertion-in-an-avl-tree/ AVL tree insertion kaynakçası.
    class Node
    {
        public int key, height; //Key node'un değerini, height ise derinliğini tutuyor.
        public Node left, right; //Left mevcut node'un solundaki node'u tutuyor; Right ise mevcut node'un sağındaki node'u tutuyor.
        public Node(int d)
        {
            key = d;
            height = 1;
        }
    }

    public class AVLTree
    {

        Node root; // Ağacın kökünü tutuyor

        int height(Node N) // Verilen node'un derinliğini döndürüyor.
        {
            if (N == null)
                return 0;

            return N.height;
        }

        int max(int a, int b) // Verilen iki değerden büyük olanı bulup döndürüyor.
        {
            return (a > b) ? a : b;
        }

        Node rightRotate(Node y) //Sağa döndürme işlemi yapılıyor.
        {
            Node x = y.left;
            Node T2 = x.right;

            x.right = y;
            y.left = T2;

            y.height = max(height(y.left),
                        height(y.right)) + 1;
            x.height = max(height(x.left),
                        height(x.right)) + 1;
            return x;
        }

        Node leftRotate(Node x)  //Sola döndürme işlemi yapılıyor.
        {
            Node y = x.right;
            Node T2 = y.left;

            y.left = x;
            x.right = T2;

            x.height = max(height(x.left),
                        height(x.right)) + 1;
            y.height = max(height(y.left),
                        height(y.right)) + 1;

            return y;
        }

        int getBalance(Node N) //Verilen node için denge durumu kontrol ediliyor.
        {
            if (N == null)
                return 0;

            return height(N.left) - height(N.right);
        }

        Node insert(Node node, int key) //Ağaca node ekleme
        {
            //Node'un eklenmesi için sorgular
            if (node == null)
                return (new Node(key));

            if (key < node.key)
                node.left = insert(node.left, key);
            else if (key > node.key)
                node.right = insert(node.right, key);
            else  
                return node;

            node.height = 1 + max(height(node.left),
                                height(node.right));

            int balance = getBalance(node);

            if (balance > 1 && key < node.left.key)
                return rightRotate(node);

            if (balance < -1 && key > node.right.key)
                return leftRotate(node);

            if (balance > 1 && key > node.left.key)
            {
                node.left = leftRotate(node.left);
                return rightRotate(node);
            }

            if (balance < -1 && key < node.right.key)
            {
                node.right = rightRotate(node.right);
                return leftRotate(node);
            }

            return node;
        }
 
        void preOrder(Node node) //Ağacı preorder şeklinde yazdırma.
        {
            if (node != null)
            {
                Console.Write(node.key + " ");
                preOrder(node.left);
                preOrder(node.right);
            }
        }

        public static void Main(String[] args)
        {
            AVLTree tree = new AVLTree();

            tree.root = tree.insert(tree.root, 10);
            tree.root = tree.insert(tree.root, 20);
            tree.root = tree.insert(tree.root, 30);
            tree.root = tree.insert(tree.root, 40);
            tree.root = tree.insert(tree.root, 50);
            tree.root = tree.insert(tree.root, 25);

            /* Oluşacak ağaç 
                30  
                / \  
            20 40  
            / \ \  
            10 25 50  
            */
            Console.Write("Preorder traversal" +
                            " of constructed tree is : ");
            tree.preOrder(tree.root);

            Console.WriteLine();
         
        }

    }

}
