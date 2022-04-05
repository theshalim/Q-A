using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QA.Areas.MasterData.Models
{
    public class MasterData
    {
        [Key]
        public int mdId { get; set; }
        [Required]
        public string landing_firstTitle { get; set; }
        [Required, MaxLength(200)]
        public string landing_titleContent { get; set; }
        public String PhotoPath { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

       

    }
}
