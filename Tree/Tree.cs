using System;
using System.Collections;
using System.Collections.Generic;

namespace PracticeC_
{
    
    public class TreeNode
    {
        public TreeNode()
        {
            left = null;
            right = null;
            key = -1;
        }
        public int key;
        public TreeNode left;
        public TreeNode right;
    }

    public class Tree
    {
        public Tree()
        {

        }
        public static void BuildBST(ref TreeNode root, int key)
        {
            if (root == null)
            {
                var node = new TreeNode();
                node.key = key;
                root = node;
                return;
            }
            if (root.key < key)
            {
                BuildBST(ref root.right, key);
            }
            else
            {
                BuildBST(ref root.left, key);
            }
        }

        public static bool IsTreeHeightBalanced(TreeNode root)
        {
            return IsTreeHeightBalanced1(root).isBalanced;
            
        }
        public class TreeInfo
        {
            public bool isBalanced = false;
            public int height = 0;
        }
        
        public static TreeInfo IsTreeHeightBalanced1(TreeNode root)
        {
            if (root == null)
            {
                TreeInfo t = new TreeInfo();
                t.isBalanced = true;
                t.height = -1;
                return t;
            }

            TreeInfo leftTreeInfo  = IsTreeHeightBalanced1(root.left );
            if (!leftTreeInfo.isBalanced)
            {
                return leftTreeInfo;
            }
            TreeInfo rightTreeInfo = IsTreeHeightBalanced1(root.right);
            if (!rightTreeInfo.isBalanced)
            {
                return rightTreeInfo;
            }
            
            if (Math.Abs(leftTreeInfo.height - rightTreeInfo.height) <=1)
            {
                TreeInfo t = new TreeInfo();
                t.isBalanced = true;
                t.height = 1 + Math.Max(leftTreeInfo.height,rightTreeInfo.height);
                return t;
            }
            else
            {
                TreeInfo t = new TreeInfo();
                t.isBalanced = false;
                t.height = 1 + Math.Max(leftTreeInfo.height,rightTreeInfo.height);
                return t;
            }
        }

        public static int height(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            return Math.Max((1 + height(root.left)), (1 + height(root.right)));
        }


        public static void PrintInOrder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            PrintInOrder(root.left);
            Console.Write(root.key + ", ");
            PrintInOrder(root.right);
        }

        public static void PrintPreOrder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            Console.Write(root.key + ", ");
            PrintPreOrder(root.left);
            PrintPreOrder(root.right);
        }

        public static bool isAllChildrenNull(Queue<TreeNode> childrenQueue)
        {
            bool isAllNull = true;
            TreeNode[] arr = childrenQueue.ToArray();
            foreach(TreeNode node in arr)
            {
                if (node != null)
                {
                    isAllNull = false;
                    return isAllNull;
                }
            }
            return isAllNull;
        }
        public static void PrintLevelByLevel(TreeNode root, List<List<TreeNode>> levelNodeList)
        {
            Queue<TreeNode> parentQueue = new Queue<TreeNode>();
            Queue<TreeNode> childrenQueue = new Queue<TreeNode>();
            childrenQueue.Enqueue(root);
            do
            {
                while (childrenQueue.Count != 0 )
                {
                    parentQueue.Enqueue(childrenQueue.Dequeue());
                }

                List<TreeNode> nodeList = new List<TreeNode>();
                while (parentQueue.Count != 0)
                {
                    TreeNode node = parentQueue.Dequeue();
                    if (node == null)
                    {
                        nodeList.Add(node);
                        childrenQueue.Enqueue(node);
                        childrenQueue.Enqueue(node);
                        Console.Write("");
                    }
                    else
                    {
                        Console.Write(node.key +  "  ");
                        nodeList.Add(node);
                        childrenQueue.Enqueue(node.left);
                        childrenQueue.Enqueue(node.right);
                    }
                }
                levelNodeList.Add(nodeList);
                Console.WriteLine();
            } while (childrenQueue.Count !=0 && !isAllChildrenNull(childrenQueue));
        }

        public static TreeNode GetBST()
        {
            TreeNode root = null;
            List<int> list = new List<int>(){50,30,80,20,40,60,90,10,25,35,45,65,85,27,42};
            foreach(int key in list)
            {
                BuildBST(ref root,key);
            }
            return root;
        }
        public static int GetDiameter(TreeNode root)
        {
            return GetLeftSpan(root,-1) + GetRightSpan(root,-1);
        }

        public static int GetLeftSpan(TreeNode root, int leftSpan)
        {
            if (root == null)
            {
                return leftSpan;
            }
            int left = GetLeftSpan(root.left, leftSpan + 1);
            int right = GetLeftSpan(root.right, leftSpan - 1);
            return (Math.Max(left, right));

        }

        public static int GetRightSpan(TreeNode root, int rightSpan)
        {
            if (root == null)
            {
                return rightSpan;
            }
            int right = GetRightSpan(root.right, rightSpan + 1);
            int left = GetRightSpan(root.left, rightSpan - 1);
            return (Math.Max(left, right));
        }
        public static void PrintTree(TreeNode root)
        {
            int maxTreeSpan = Math.Max(GetLeftSpan(root,-1), GetRightSpan(root,-1));

            List<List<TreeNode>> levelNodeList = new List<List<TreeNode>>();
            Tree.PrintLevelByLevel(root,levelNodeList);
            
            int diameter =  ( 2 * levelNodeList[levelNodeList.Count-1].Count - 1) ;
            int noOfNodes = 0;
            foreach( List<TreeNode> list in levelNodeList)
            {
                noOfNodes = list.Count;
                int noOfSpacesBetweenNodes = diameter/noOfNodes;
                int spacesBeforeFirstNode = noOfSpacesBetweenNodes/2;
                for(int i = 0; i < spacesBeforeFirstNode; i++)
                {
                    Console.Write("  ");
                }
                foreach(TreeNode node in list)
                {
                    if (node == null)
                    {
                        Console.Write("()");
                    }
                    else
                    {
                        Console.Write(node.key);
                    }
                    for(int i = 0; i < noOfSpacesBetweenNodes; i++)
                    {
                        Console.Write("  ");
                    }                    
                }
                Console.WriteLine();
                Console.WriteLine();
            }

        }
    }
}

