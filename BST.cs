using System;
using System.Collections.Generic;

namespace PracticeC_
{
    class Node{
        public int info;
        public Node left;
        public Node right;
        public Node(int info){
            this.info = info;
            left = right = null;
        }
    }
    class BST
    {
        private Node root = null;
        public void Add(int info){
            if (root == null){
                root = new Node(info);
                return;
            }
            Node currentNode = root;
            Node prevNode = currentNode;
            while(currentNode!=null){
                prevNode = currentNode;
                currentNode = currentNode.info >= info ? currentNode.left : currentNode.right; 
            }
            if (prevNode.info >= info){
                prevNode.left = new Node(info);
            }
            else {
                prevNode.right = new Node(info);
            }
        }

        public List<int>  preOrderTraversal(){
            List<int> nodeList = new List<int>();
            preOrder(root, ref nodeList);
            return nodeList;
        }
       
        private void preOrder(Node node, ref List<int> nodeList){
            if (node != null){
                nodeList.Add(node.info);
                preOrder(node.left, ref nodeList);
                preOrder(node.right, ref nodeList);
            }
        }
        public List<int>  inOrderTraversal(){
            List<int> nodeList = new List<int>();
            inOrder(root, ref nodeList);
            return nodeList;
        }
       
        private void inOrder(Node node, ref List<int> nodeList){
            if (node != null){
                inOrder(node.left, ref nodeList);
                nodeList.Add(node.info);
                inOrder(node.right, ref nodeList);
            }
        }
        public List<int>  postOrderTraversal(){
            List<int> nodeList = new List<int>();
            postOrder(root, ref nodeList);
            return nodeList;
        }
       
        private void postOrder(Node node, ref List<int> nodeList){
            if (node != null){
                postOrder(node.left, ref nodeList);
                postOrder(node.right, ref nodeList);
                nodeList.Add(node.info);
            }
        }

    }
}