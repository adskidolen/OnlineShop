namespace KeepHome.Models
{
    using System.Collections.Generic;

    public class ParentCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ChildCategory> ChildCategories { get; set; }

        public ParentCategory()
        {
            this.ChildCategories = new HashSet<ChildCategory>();
        }
    }
}