using System;
using System.Collections.Generic;
using System.Collections;


namespace PracticeC_
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = Tree.GetBST();
            Tree.PrintInOrder(root);
            Console.WriteLine();
            Tree.PrintPreOrder(root);
            Console.WriteLine();
            List<List<TreeNode>> levelNodeList = new List<List<TreeNode>>();
            Tree.PrintLevelByLevel(root,levelNodeList);
            int leftSpan = Tree.GetDiameter(root);
            Tree.PrintTree(root);
            Console.WriteLine();

        }

    }
}
