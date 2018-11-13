
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
namespace Domain
{
  

    public partial class CategoriePost
    {
       
        [Key]
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }


        public CategoriePost()
        {
        }
    }
}
