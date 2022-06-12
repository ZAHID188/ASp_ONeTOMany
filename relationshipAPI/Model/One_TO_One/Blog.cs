using System.Text.Json.Serialization;

namespace relationshipAPI.Model.One_TO_One
{
    public class Blog
    {
       
            public int BlogId { get; set; }
            public string Url { get; set; }
          
            public Blogtype Blogtypes { get; set; }
        

       
    }
}
