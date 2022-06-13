using relationshipAPI.Data.Dtos.One_TO_Many;
using relationshipAPI.Model.One_TO_many;

namespace relationshipAPI.Interfaces
{
    public interface IBlog12M_repo
    {
        void Update(Blog12M blog);
        Task<bool> SaveAllAsync();
        Task<bool> UpdateSingle(Blog12M blog);
        Task<bool> UpdateSinglePost(Post blog);

        Task<bool> DeleteBlog(Blog12M blog);
        Task<bool> DeletePost(Post pt);



        Task<bool> SaveAsync(BlogUpdateDto blog);
        Task<bool> SavePostAsync(PostUpdateDto blog);


        Task<IEnumerable<Blog12M>> GetBlogAsync();
        Task<IEnumerable<Post>> GetPostsAsync();


        Task<Blog12M> GetBlogByIdAsync(int id);
        Task<Post> GetPostByIdAsync(int id);

        Task<Blog12M> GetBlogByBlogNameAsync(String Blogname);


    }
}
