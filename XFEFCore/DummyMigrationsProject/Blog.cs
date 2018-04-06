using System.ComponentModel.DataAnnotations;

namespace XFEFCore
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }
    }
}
