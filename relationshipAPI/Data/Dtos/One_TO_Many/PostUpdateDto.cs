namespace relationshipAPI.Data.Dtos.One_TO_Many
{
    public class PostUpdateDto
    {

        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
    }
}
