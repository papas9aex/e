using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28
{
  public class BSTNode
    {
        public int key;
        public BSTNode left;
        public BSTNode right;

        public BSTNode(int key)
        {
            this.key = key;
            this.left = null;
            this.right = null;
        }
    }
}
