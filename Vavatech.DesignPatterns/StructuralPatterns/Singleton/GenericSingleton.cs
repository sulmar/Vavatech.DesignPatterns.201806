namespace Vavatech.DesignPatterns.StructuralPatterns.Singleton
{
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




}
