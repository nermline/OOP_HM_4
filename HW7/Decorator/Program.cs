using System;
using System.Text;

namespace TreeDecorator
{
    interface ITree
    {
        void Display();
        void Shine();
    }

    class ChristmasTree : ITree
    {
        public void Display()
        {
            Console.WriteLine("Звичайна ялинка.");
        }

        public void Shine()
        {
            Console.WriteLine("Ялинка поки що не світиться.");
        }
    }

    abstract class TreeDecorator : ITree
    {
        protected ITree tree;
        protected TreeDecorator(ITree tree) { this.tree = tree; }
        public virtual void Display() => tree.Display();
        public virtual void Shine() => tree.Shine();
    }

    class ToysDecorator : TreeDecorator
    {
        private readonly string toys;
        public ToysDecorator(ITree tree, string toys)
            : base(tree)
        {
            this.toys = toys;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("Прикрашена іграшками: " + toys);
        }
    }

    class LightsDecorator : TreeDecorator
    {
        public LightsDecorator(ITree tree) : base(tree) { }

        public override void Shine()
        {
            Console.WriteLine("Ялинка яскраво світиться гірляндами!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            
            ITree tree = new ChristmasTree();

            tree = new ToysDecorator(tree, "червоні кулі, зірка, дощик");

            tree = new LightsDecorator(tree);

            tree.Display();
            tree.Shine();

            Console.ReadKey();
        }
    }
}
