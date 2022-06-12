using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace relationshipAPI.Model.One_TO_many
{
    public class Blog12M
    {
        [Key]
        public int BlogId { get; set; }
        public string Url { get; set; }

      
        public List<Post> Posts { get; set; }
    }
}
