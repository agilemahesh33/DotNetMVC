using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDP
{
    internal class Singleton
    {
        private Singleton() { }
        private static Singleton instance;
        // if used = new Singleton(); then always initializes the instance even
        // though not called i.e. not lazy

        private static object instanceLock = new object(); //To Create lock
        public static Singleton getInstance()
        {
            if (instance == null) //First check to avoid multi thread waiting for lock release
            {
                lock (instanceLock)
                {
                    if (instance == null) //if null only then create
                    {
                        instance = new Singleton();
                    }
                }
            }
            return instance;            
        }
    }
}
