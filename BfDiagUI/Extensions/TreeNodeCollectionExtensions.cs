using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BfDiagUI
{
    public static class TreeNodeCollectionExtensions
    {
        public static void ExpandToLevel(this TreeNodeCollection nodes, int level)
        {
            if (level > 0)
            {
                foreach (TreeNode node in nodes)
                {
                    node.Expand();
                    ExpandToLevel(node.Nodes, level - 1);
                }
            }
        }

        public static TreeNode AddWithImage(this TreeNodeCollection nodes, string text, string imageKey)
        {
            TreeNode node = nodes.Add(text);
            node.ImageKey = imageKey;
            node.SelectedImageKey = imageKey;

            return node;
        }
    }
}
