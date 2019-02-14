namespace KeepHome.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class BlogPost
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
        
        public DateTime PublishedOn { get; set; }

        public DateTime? EditedOn { get; set; }
        public bool IsEdited { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public virtual ICollection<BlogComment> Comments { get; set; }

        public BlogPost()
        {
            this.PublishedOn = DateTime.UtcNow;
            this.IsEdited = false;
            this.Comments = new List<BlogComment>();
        }
    }
}
