using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Models.TeamManagement
{
    public class UserAccount
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

        public string Login { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string Email { get; set; }


        protected virtual string PasswordHashed
        {
            get;
            private set;
        }

        [NotMapped]
        public string Password
        {
            set { /*PasswordHashed = Encrypt(value)*/; }
        }

        public virtual ICollection<TeamMemberSeat> TeamMemberSeats { get; set; }
    }
}
