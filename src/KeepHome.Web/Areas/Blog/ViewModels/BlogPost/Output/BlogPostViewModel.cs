namespace KeepHome.Web.Areas.Blog.ViewModels.BlogPost.Output
{
    using KeepHome.Common;

    using System;
    using System.ComponentModel.DataAnnotations;

    public class BlogPostViewModel
    {
        private const string DateFormatMessage = "--Публикувано на: {0}";
        private const string EditDateFormatMessage = "--Променено на: {0}";

        public int Id { get; set; }
        public string Title { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = GlobalConstants.DateFormat)]
        public DateTime PublishedOn { get; set; }
        public string ShowDate => string.Format(DateFormatMessage, this.PublishedOn);

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = GlobalConstants.DateFormat)]
        public DateTime EditedOn { get; set; }
        public string ShowEditedOn => string.Format(EditDateFormatMessage, this.EditedOn);

        public bool IsEdited { get; set; }
    }
}