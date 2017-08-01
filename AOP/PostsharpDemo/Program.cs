using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostsharpDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var instance = new Sample();
            instance.Print();
            Console.ReadLine();
        }
    }

    class Sample
    {
        [UseAopAspect]
        public void Print()
        {
            Console.WriteLine("Hello World!!!");
        }
    }

    [Serializable]
    class UseAopAspect: OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            Console.WriteLine("Method enters.....");
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            Console.WriteLine("Method exit....");
        }
    }
}
