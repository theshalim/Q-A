﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QA.Models
{
    public class qa
    {
        
        public int qaId { get; set; }
        [Required ]
        
        public string Question { get; set; }
        [Required]
        public string Answer { get; set; }

        public qa()
        {

        }
    }
}
