using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTask.Service.DTOs
{
    public class UserForCreationDto
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }
        
        [Required, MaxLength(50)]
        public string Username { get; set; }

        [Required, MaxLength (30)]
        public string Password { get; set; }
    }
}
