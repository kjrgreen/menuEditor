using System.Collections.Generic;

namespace menuEditor.Data.Models
{
    public partial class MenuItem
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string URL { get; set; }
        public int? ParentId { get; set; }
        public virtual List<MenuItem> Children { get; set; }
    }
}
