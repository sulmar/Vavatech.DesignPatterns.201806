using System;

namespace Vavatech.DesignPatterns.StructuralPatterns.Singleton
{
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




}
