namespace relationshipAPI.Data.Dtos.One_TO_Many
{
    public class Blog12M_Dto
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post_Dto> Posts { get; set; }
    }
}
