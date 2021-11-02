using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUOF.Data.Models
{
   public class User:ModelBase
    {
        public User()
        {
            this.Articles = new List<Article>();
        }

        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }


        public virtual ICollection<Article> Articles { get; set; }
    }
}
