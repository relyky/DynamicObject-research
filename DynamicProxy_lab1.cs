///
/// DynamicProxy Lab
/// ref→https://www.youtube.com/watch?v=1rjQC6ftC4k
///
using ImpromptuInterface; // for "ActLike<I>()"
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace DynamicProxy-Lab
{
    public class Log<T> : DynamicObject
        where T : class, new()
    {
        private readonly T _instance;
        private Dictionary<string, int> methodCallCount
            = new Dictionary<string, int>();

        public Log(T instance)
        {
            _instance = instance;
        }

        public static I AS<I>() where I : class
        {
            if (!typeof(I).IsInterface)
                throw new ArgumentException("I muse be an interface type!");

            return new Log<T>(new T()).ActLike<I>(); //※ 關鍵之一：取回 wave 完成的 dynamic proxy
        }

        //※ 關鍵之二： wave 動作在 Try.. 等 override 成員函成實作。
        public override bool TryInvokeMember(InvokeMemberBinder binder,
            object[] args, out object result)
        {
            try
            {
                Console.WriteLine($"Invoking {_instance.GetType().Name}.{binder.Name} with arguments [{string.Join(",", args)}]");
                
                if (methodCallCount.ContainsKey(binder.Name))
                    methodCallCount[binder.Name]++;
                else
                    methodCallCount.Add(binder.Name, 1);                                    
                
                //# BEFORE
                //return base.TryInvokeMember(binder, args, out result);
                result = _instance.GetType().GetMethod(binder.Name).Invoke(_instance, args);
                //# AFTER
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }

        public string Info
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var kv in methodCallCount)
                    sb.AppendLine($"{kv.Key} called {kv.Value} time(s)");
                return sb.ToString();
            }
        }

        public override string ToString()
        {
            return $"{Info}\r\n{_instance}";
        }
    }
}
