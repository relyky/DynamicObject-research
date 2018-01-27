using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObjectLab
{
    public interface IBizService1
    {
        void TxnBehavior1();
    }

    public class BizService1 : IBizService1
    {
        public void TxnBehavior1()
        {
            Console.WriteLine("ON : BizBehavior1");
            DoAction1();
        }

        protected void DoAction1()
        {
            Console.WriteLine("ON : DoAction1");
        }
    }
}
