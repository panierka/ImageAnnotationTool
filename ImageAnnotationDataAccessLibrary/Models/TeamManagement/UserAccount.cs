using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Models.TeamManagement
{
    public class UserAccount
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string Email { get; set; }


        protected virtual string PasswordHashed
        {
            get;
            set;
        }

        [NotMapped]
        public string Password
        {
            set { /*PasswordHashed = Encrypt(value)*/; }
        }
    }
}
