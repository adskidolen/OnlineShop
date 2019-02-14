namespace KeepHome.Web.Areas.Blog.ViewModels.BlogPost.Output
{
    using System;

    public class BlogPostViewModel
    {
        private const string DateFormatMessage = "--Публикувано на: {0}";
        private const string EditDateFormatMessage = "--Променено на: {0}";

        public int Id { get; set; }
        public string Title { get; set; }

        public DateTime PublishedOn { get; set; }
        public string ShowDate => string.Format(DateFormatMessage, this.PublishedOn.ToLongDateString());

        public DateTime EditedOn { get; set; }
        public string ShowEditedOn => string.Format(EditDateFormatMessage, this.EditedOn.ToLongDateString());

        public bool IsEdited { get; set; }
    }
}