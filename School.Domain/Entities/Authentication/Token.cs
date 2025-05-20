using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Entities.Authentication
{
    public class Token
    {
        public int Id { get; set; }
        public string TokenLetters { get; set; }
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
