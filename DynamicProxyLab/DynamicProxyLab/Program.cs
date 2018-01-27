using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObjectLab
{
    class Program
    {
        static void Main()
        {
            //var biz = new BizService1();
            IBizService1 biz = Log<BizService1>.AS<IBizService1>();

            biz.TxnBehavior1();
            biz.TxnBehavior1();

            Console.WriteLine(biz);

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
