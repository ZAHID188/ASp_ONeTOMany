namespace relationshipAPI.Model.One_TO_many
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

       
        public Blog12M Blog { get; set; }
        public int BlogId { get; set; }
    }
}
