using System;

namespace PracticeC_
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] treeNode = {500, 300, 800, 150, 400, 600, 900, 100, 200, 350, 450};
            BST bstObj = new BST();
            foreach(int info in treeNode){
                bstObj.Add(info);
            }

            Console.Write("Pre Order Traveral: ");
            foreach(int info in bstObj.preOrderTraversal()){
                Console.Write(info + ", ");
            }
            Console.WriteLine();

            Console.Write("In Order Traveral: ");
            foreach(int info in bstObj.inOrderTraversal()){
                Console.Write(info + ", ");
            }
            Console.WriteLine();

            Console.Write("Post Order Traveral: ");
            foreach(int info in bstObj.postOrderTraversal()){
                Console.Write(info + ", ");
            }
        }
    }
}
