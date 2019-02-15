namespace KeepHome.Web.Areas.Blog.ViewModels.BlogComment.Output
{
    using KeepHome.Common;

    using System;
    using System.ComponentModel.DataAnnotations;

    public class BlogCommentViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string UserUserName { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = GlobalConstants.DateFormat)]
        public DateTime CommentedOn { get; set; }

        public string ShowCommentDetails => $"{this.UserUserName}   - {this.CommentedOn}";
    }
}