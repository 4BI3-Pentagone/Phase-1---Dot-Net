﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public enum Gender { male, female }

    public enum EAccountType
    {
        Patient,
        Doctor,
        Administrator
    }
    public class User:IdentityUser
    {
        public String FirstName { get; set; }
        public String lastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime? birthDate { get; set; }
        public String adress { get; set; }
        //  public String Email { get; set; }
        //  public String Password { get; set; }
        //   public Gender? gender { get; set; }
        public String ImageName { get; set; }


        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<SubComment> SubComments { get; set; }

        public User()
        {
            this.Comments = new HashSet<Comment>();
            this.SubComments = new HashSet<SubComment>();
        }
    }
}
