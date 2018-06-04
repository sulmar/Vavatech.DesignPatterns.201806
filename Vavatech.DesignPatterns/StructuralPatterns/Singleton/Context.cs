using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.DesignPatterns.StructuralPatterns.Singleton
{

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
        }

        public static void LazyTest()
        {
            Connection connection = LazySingleton<Connection>.Instance;

            Context context = LazySingleton<Context>.Instance;
        }
    }




}
