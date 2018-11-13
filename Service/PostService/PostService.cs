using Data;
using Data.Infrastructure;
using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.CourseSer;

namespace Service.PostService
{
    public class PostService : Service<Domain.Post>, IPostService

    {


        static DatabaseFactory dbf = new DatabaseFactory();
        static IUnitOfWork UOW = new UnitOfWork(dbf);

        public PostService() : base(UOW)
        {


        }

        public List<Post> GetPosts()
        {
            return dbf.DataContext.Posts.ToList();
        }
        public Post GetPostsByid(int id)
        {
            return dbf.DataContext.Posts.Find(id);
        }
        public List<Post> GetPostsBycat(int? idcat)
        { 
            return dbf.DataContext.Posts.Where(x => x.categoriePost.Id == idcat).ToList(); 
        }
        public List<Post> GetPostsByrecherch(string recherch)
        {
            List<Post> lst = dbf.DataContext.Posts.Where(u => u.Titre.Contains(recherch)).ToList();
            return lst;
        }
        // If you want to implement both "*" and "?"

        public List<CategoriePost> GetCategoriePost()
        {
            return dbf.DataContext.CategoriePosts.ToList();
        }
        public List<Comment> GetComments()
        {
            return dbf.DataContext.Comments.ToList();
        }
        public void DelComments(Comment Comments)
        {
            dbf.DataContext.Comments.Remove(Comments);
            var SubComments = dbf.DataContext.SubComments.Where(b => b.Comment.ComID == Comments.ComID);
            foreach (var SubComment in SubComments)
            {
                dbf.DataContext.SubComments.Remove(SubComment);
            } 
            SaveChanges();
        }
        public List<SubComment> GetSubComments()
        {
            return dbf.DataContext.SubComments.ToList();
        }

        public List<User> GetUsers()
        {  
          return dbf.DataContext.Users.ToList();
        }
        public void SaveChanges()
        {
            dbf.DataContext.SaveChanges();
        }



    }
}
