using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Search
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProgramLogic programLogic = new ProgramLogic();
            intSet testIntSet = new nonEmpty(3, new empty(), new empty());
            intSet testIntSet2 = new nonEmpty(19, new empty(), new empty()).incl(20).incl(21);
            intSet newTestIntSet = testIntSet.incl(5).incl(7).incl(21).incl(1);
            intSet newUnionTestIntSet = newTestIntSet.union(testIntSet2);
            Console.WriteLine(newTestIntSet);
            Console.WriteLine("newTestIntSet.contains(7) = {0}",newTestIntSet.contains(7));
            Console.WriteLine("newTestIntSet.contains(12) = {0}", newTestIntSet.contains(12));
            Console.WriteLine("newTestIntSet.contains(71) = {0}", newTestIntSet.contains(71));
            Console.WriteLine("newTestIntSet.contains(5) = {0}", newTestIntSet.contains(5));
            Console.WriteLine("newTestIntSet.incl(-3) returns {0}", newTestIntSet.incl(-3));
            Console.WriteLine("Binary search works well with objects and characters as well.  For objects you need to identify which property the binary search will sort by.");
            Console.WriteLine("testing union of 19,20,21 returns:");
            Console.WriteLine(newUnionTestIntSet);
            Console.ReadKey();
        }
    }

    public class ProgramLogic
    {
        public void execute()
        {

        }
    }

    abstract public class intSet
    {
        public abstract intSet incl(int number);
        public abstract bool contains(int number);
        public abstract intSet union(intSet that);
    }

    public class nonEmpty : intSet
    {
        public nonEmpty(int elem, intSet left, intSet right)
        {
            this.elem = elem;
            this.left = left;
            this.right = right;
        }
        
        override public intSet incl(int number)
        {
            if (number < elem)
                return new nonEmpty(elem, left.incl(number), right);
            if (number > elem)
                return new nonEmpty(elem, left, right.incl(number));
            return this;
        }

        public override bool contains(int number)
        {
            if (number < elem)
                return left.contains(number);
            if (number > elem)
                return right.contains(number);
            return true;
        }

        public override intSet union(intSet that)
        {
            return left.union(right).union(that).incl(elem);
        }

        public override string ToString()
        {
            return "{" + left + " " + elem + " " + right + "}";
        }

        private readonly int elem;
        private readonly intSet left;
        private readonly intSet right;
    }

    public class empty : intSet
    {
        public int element
        {
            get;
            set;
        }

        override public intSet incl(int number)
        {
            return new nonEmpty(number, new empty(), new empty());
        }

        public override bool contains(int number)
        {
            return false;
        }

        public override intSet union(intSet that)
        {
            return that;
        }

        public override string ToString()
        {
            return ".";
        }

    }
}