using Data.Infrastructure;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePattern
{
   public class ServiceUser :Service<User> ,IServiceUser
    
    {
        //   MyfinanceContex context = new MyfinanceContex();

        static DatabaseFactory DBF = new DatabaseFactory();

        //  IRepositoryBase<Product> RBP = new RepositoryBase<Product>(DBF);
        static IUnitOfWork UOW = new UnitOfWork(DBF);
        public ServiceUser() : base(UOW)
        {

        }

      
        public Boolean verif(String Log , String pswd)
        {
            Boolean v = true;
            var req = from p in GetMany()
                      where p.Email == Log
                      || p.Password == pswd
                      select p;
            if (req != null)
                v = false;
            return v;
        }
    
   
    }
}
