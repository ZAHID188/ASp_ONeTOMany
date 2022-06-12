using relationshipAPI.Model.One_TO_many;

namespace relationshipAPI.Interfaces
{
    public interface IBlog12M_repo
    {
        void Update(Blog12M blog);
        Task<bool> SaveAllAsync();
        Task<bool> UpdateSingle(Blog12M blog);
        Task<bool> DeleteBlog(Blog12M blog);


        Task<bool> SaveAsync(Blog12M blog);

        Task<IEnumerable<Blog12M>> GetBlogAsync();
        Task<Blog12M> GetBlogByIdAsync(int id);
        Task<Blog12M> GetBlogByBlogNameAsync(String Blogname);


    }
}
