using System;
using System.Collections.Generic;
using System.Text;

namespace Week7
{
    public class TreeNode
    {
        public int data;
        public TreeNode parent;
        public TreeNode left;
        public TreeNode right;

        /// We could put the child nodes in a list instead. 
        /// This would allow the nodes to be dynamic in structure.
        /// public List<TreeNode> children;

        public TreeNode()
        {
            data = 0;
            parent = null;
            left = null;
            right = null;
        }
        public TreeNode(TreeNode parent) : this()
        {
            this.parent = parent;
        }
        public TreeNode(TreeNode parent, int num) : this(parent)
        {
            data = num;
        }
        public TreeNode(int num) : this()
        {
            data = num;
        }
    }

    public class Tree
    {
        public TreeNode root;
        public int maxDepth;
        public int size;

        public Tree()
        {
            root = null;
            maxDepth = 0;
            size = 0;
        }

        public void Add(int data)
        {
            Add(new TreeNode(data));
        }

        public void Add(TreeNode node)
        {
            AddNode(node, root, true, 0);
        }

        private void AddNode(TreeNode newNode, TreeNode travNode, bool isLeft, int depth)
        {
            if (root == null)
            {
                root = newNode;
                maxDepth = 0;
                size = 1;
                return;
            }

            if (newNode.data <= travNode.data)
            {
                if (travNode.left == null)
                {
                    travNode.left = newNode;
                    maxDepth = depth > maxDepth ? depth : maxDepth;
                    size++;
                }
                else
                {
                    AddNode(newNode, travNode.left, true, depth + 1);
                }
            }
            else
            {
                if (travNode.right == null)
                {
                    travNode.right = newNode;
                    newNode.parent = travNode;
                    maxDepth = depth > maxDepth ? depth : maxDepth;
                    size++;
                }
                else
                {
                    AddNode(newNode, travNode.right, false, depth + 1);
                }
            }
        }

        public void Remove(int value)
        {
            Remove(value, root);
        }

        private void Remove(int value, TreeNode node)
        {
            if (node == null)
            {
                // data doesn't exist
                throw new ArgumentException("value not found in tree");
            }
            // traverse to next subtree
            if (value < node.data)
                Remove(value, node.left);
            else if (value > node.data)
                Remove(value, node.right);
            else // found the node to replace
            {
                // if no children, replace with nothing
                if (node.left == null && node.right == null)
                {
                    ReplaceParent(node, null);
                    size--;
                }
                else if (node.left == null) // only a right child, use it
                {
                    ReplaceParent(node, node.right);
                    size--;
                }
                else if (node.right == null) // only a left child, use it
                {
                    ReplaceParent(node, node.left);
                    size--;
                }
                else // both children exist. Grab the next highest value and use it
                {
                    TreeNode nextSmallest = GetSmallest(node.right);
                    node.data = nextSmallest.data;
                    Remove(nextSmallest.data, nextSmallest);
                }
            }
        }

        private void ReplaceParent(TreeNode node, TreeNode replacementNode)
        {
            if (node.parent == null)
            {
                root = replacementNode;
            }
            else
            {
                if (node.parent.left == node)
                    node.parent.left = replacementNode;
                else
                    node.parent.right = replacementNode;
            }

            if (replacementNode != null)
                replacementNode.parent = node.parent;
        }

        public List<TreeNode> Traverse()
        {
            List<TreeNode> nodes = new List<TreeNode>();
            TraversePreOrder(root, nodes);
            return nodes;
        }

        /// <summary>
        /// Traversal method for returning the tree as a list of nodes.
        /// Pre-order traversal
        /// </summary>
        /// <param name="node"></param>
        /// <param name="nodes"></param>
        public void TraversePreOrder(TreeNode node, List<TreeNode> nodes)
        {
            if (node != null)
            {
                nodes.Add(node);

                TraversePreOrder(node.left, nodes);
                TraversePreOrder(node.right, nodes);
            }
        }

        /// <summary>
        /// Traversal method for returning the tree as a list of nodes.
        /// In-order traversal
        /// </summary>
        /// <param name="node"></param>
        /// <param name="nodes"></param>
        public void TraverseInOrder(TreeNode node, List<TreeNode> nodes)
        {
            if (node != null)
            {
                TraverseInOrder(node.left, nodes);
                nodes.Add(node);
                TraverseInOrder(node.right, nodes);
            }
        }

        /// <summary>
        /// Traversal method for returning the tree as a list of nodes.
        /// Post-order traversal
        /// </summary>
        /// <param name="node"></param>
        /// <param name="nodes"></param>
        public void TraversePostOrder(TreeNode node, List<TreeNode> nodes)
        {
            if (node != null)
            {
                TraversePostOrder(node.left, nodes);
                TraversePostOrder(node.right, nodes);
                nodes.Add(node);
            }
        }

        /// <summary>
        /// Return a string of the tree nodes in pre-order
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string treeString = "";
            string indent = "";
            PrintTree(root, ref treeString, indent, true);
            return treeString;
        }
        /// <summary>
        /// traversal method for the ToString functionality
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="result"></param>
        /// <param name="indent"></param>
        /// <param name="last"></param>
        public void PrintTree(TreeNode tree, ref string result, string indent, bool last)
        {
            if (tree != null)
            {
                result += (indent + "+- " + tree.data.ToString() + "\n");
                indent += last ? "   " : "|  ";

                PrintTree(tree.left, ref result, indent, false);
                PrintTree(tree.right, ref result, indent, true);
            }
        }

        public bool Contains(int value)
        {
            TreeNode node = root;
            while (node != null)
            {
                if (node.data == value)
                    return true;
                else if (node.data <= value)
                    node = node.left;
                else
                    node = node.right;
            }
            return false;
        }

        private TreeNode GetSmallest(TreeNode node)
        {
            while (node.left != null)
                node = node.left;
            return node;
        }

        private TreeNode GetLargest(TreeNode node)
        {
            while (node.right != null)
                node = node.right;
            return node;
        }
    }
}
