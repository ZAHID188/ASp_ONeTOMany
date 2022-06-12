namespace relationshipAPI.Model.One_TO_One
{
    public class Blogtype
    {
        public int Id { get; set; }
    
        public string type { get; set; }

        public Blog Blogs { get; set; }
        public int BlogId { get; set; }
       
    }
}
