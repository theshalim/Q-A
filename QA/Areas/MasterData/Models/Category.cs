using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QA.Areas.MasterData.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required, MaxLength(50)]
        public String CategoryName { get; set; }
        public virtual ICollection<MasterData> MasterData { get; set; }

    }
}
