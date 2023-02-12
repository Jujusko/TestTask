using DBLay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Helpers
{
    public class SingletonDB
    {
        private static SingletonDB _instance;

        public AppDbContext db;
        private SingletonDB()
        {
            //db = new();
        }
        public SingletonDB GetInstance()
        {
            if (_instance == null)
            {
                return new SingletonDB();
            }
            return _instance;
        }
    }
}
