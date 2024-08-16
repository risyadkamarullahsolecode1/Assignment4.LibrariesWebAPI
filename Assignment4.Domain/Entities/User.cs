using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.Domain.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(1)]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(1), MaxLength(20)]
        public int NoHp { get; set; }
    }
}
