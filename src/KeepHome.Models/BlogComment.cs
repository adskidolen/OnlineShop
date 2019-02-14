namespace KeepHome.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BlogComment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int BlogPostId { get; set; }

        public virtual BlogPost BlogPost { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual KeepHomeUser User { get; set; }
        
        public DateTime CommentedOn { get; set; }

        public BlogComment()
        {
            this.CommentedOn = DateTime.UtcNow;
        }
    }
}
