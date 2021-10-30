using BlogProject.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Models.Entities
{
    public class Content
    {
        
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        [ScaffoldColumn(false)] // scafolding template oluştururken view'da oluşmasını engeller
        public DateTime CreDate { get; set; }
        [ScaffoldColumn(false)]
        public int ViewCount { get; set; }
        [Required]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        [Required]
        [ScaffoldColumn(false)]
        public int UserID { get; set; }
        public virtual AppUser User { get; set; }

        public virtual List<Comment> Comments { get; set; }

    }
}
