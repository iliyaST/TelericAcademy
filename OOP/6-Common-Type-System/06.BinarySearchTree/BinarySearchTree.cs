
namespace BinarySearchTree
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    //decided not to write this task, too difficult at the moment, better try the exam preparation :)
    struct BinarySearchTree<T> : IEnumerable<TreeNode<T>>, ICloneable
        where T : IComparable<T>
    {
        private TreeNode<T> root;

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<TreeNode<T>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
