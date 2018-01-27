using ImpromptuInterface;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace DynamicObjectLab
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

            return new Log<T>(new T()).ActLike<I>();
        }

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

                //return base.TryInvokeMember(binder, args, out result);
                result = _instance.GetType().GetMethod(binder.Name).Invoke(_instance, args);
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

