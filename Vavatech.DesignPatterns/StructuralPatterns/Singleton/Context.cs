using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.DesignPatterns.StructuralPatterns.Singleton
{
    class Connection
    {
        public bool IsOpen { get; set; }

    }
    
    class Context
    {
        public int Counter { get; set; }

        private static Context instance;
        private static object syncLock = new object();

        public static Context Instance
        {
            get
            {
                lock (syncLock)
                {
                    if (instance == null)
                    {
                        instance = new Context();
                    }
                }

                return instance;
            }
        }

       
    }


    public sealed class LazySingleton<T>
        where T : new()
    {
        private static readonly Lazy<T> lazy = new Lazy<T>(() => new T());

        public static T Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        private LazySingleton()
        {
        }
    }

    class Singleton<T>
        where T : new()
    {
        private static T instance;
        private static object syncLock = new object();

        public static T Instance
        {
            get
            {
                lock (syncLock)
                {
                    if (instance == null)
                    {
                        instance = new T();
                    }
                }

                return instance;
            }
        }

        protected Singleton()
        {

        }

    }


    class SingletonTests
    {
        public static void Test()
        {
            Context context1 = Context.Instance;
            context1.Counter++;

            Context context2 = Context.Instance;
            context2.Counter++;

        }

        public static void GenericTest()
        {
            Connection connection = Singleton<Connection>.Instance;

            Context context = Singleton<Context>.Instance;


            Lazy<Connection> lazy = new Lazy<Connection>();
            lazy.Value.IsOpen = true;


            lazy.Value.IsOpen = false;
        }
    }




}
