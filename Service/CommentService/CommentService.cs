using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Domain;
using ServicePattern;

namespace Service.CommentService
{
    public class CommentService : Service<Domain.Comment>, ICommentService

    {


        static DatabaseFactory dbf = new DatabaseFactory();
        static IUnitOfWork UOW = new UnitOfWork(dbf);

        public CommentService() : base(UOW)
        {


        }
     
         
    }
}

