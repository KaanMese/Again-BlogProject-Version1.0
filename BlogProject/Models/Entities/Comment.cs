﻿using BlogProject.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Models.Entities
{
    public class Comment
    {

        public int ID { get; set; }
        [Required]
        public int UserID { get; set; }
        public virtual AppUser User { get; set; }

    
        public int? ContentID { get; set; }
        public virtual Content Content { get; set; }

        [Required]
        public string Text { get; set; }
        public DateTime CreDate { get; set; }

    }
}
