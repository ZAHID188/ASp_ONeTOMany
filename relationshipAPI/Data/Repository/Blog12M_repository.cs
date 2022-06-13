using Microsoft.EntityFrameworkCore;
using relationshipAPI.Data.Dtos.One_TO_Many;
using relationshipAPI.Interfaces;
using relationshipAPI.Model.One_TO_many;

namespace relationshipAPI.Data.Repository
{
    public class Blog12M_repository : IBlog12M_repo
    {
        private readonly DataContext _data;

        public Blog12M_repository(DataContext data)
        {
            _data = data;
        }

        public async Task<IEnumerable<Blog12M>> GetBlogAsync()
        {
            return await _data.Blog12Ms
                .Include(c=>c.Posts)
                .ToListAsync();
        }

        public async Task<Blog12M> GetBlogByBlogNameAsync(string Blogname)
        {
            return await _data.Blog12Ms.SingleOrDefaultAsync(x => x.Url == Blogname);
        }

        public async Task<Blog12M> GetBlogByIdAsync(int id)
        {
            return await _data.Blog12Ms.Where(x => x.BlogId == id)
                .Include(c => c.Posts)
                .FirstOrDefaultAsync();

            //return await _data.Blog12Ms.FindAsync(id);  
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _data.SaveChangesAsync() > 0; 
        }

        public async Task<bool> SaveAsync(BlogUpdateDto blog)
        {
            var newBlog = new Blog12M
            {
                Url = blog.Url,
            };
             
            _data.Blog12Ms.Add(newBlog);
           
            return await _data.SaveChangesAsync() > 0;
        }


      


        public void Update(Blog12M blog)
        {
            _data.Update(blog);
            SaveAllAsync();

            // _data.Entry(blog).State = EntityState.Modified;

        }
        public async Task<bool> UpdateSingle(Blog12M blog)
        {
             _data.Update(blog);
            return await SaveAllAsync();
        }

        public async Task<bool> DeleteBlog(Blog12M blog)
        {
            
            _data.Blog12Ms.Remove(blog);
            return await SaveAllAsync();

        }


        //post create

        //Getting all the posts
        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            return await _data.Posts.ToListAsync();

        }
        //get a post by ID
        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await _data.Posts.Where(x => x.PostId == id)
                .FirstOrDefaultAsync();
        }

        //adding a post
        public async Task<bool> SavePostAsync(PostUpdateDto pt)
        {
            var newPt = new Post
            {
                PostId = pt.PostId,
                Title = pt.Title,
                Content = pt.Content,
                BlogId = pt.BlogId,
            };
                
            
            _data.Posts.Add(newPt);

            return await _data.SaveChangesAsync() > 0;
        }

       
        //Updating the post
        public async Task<bool> UpdateSinglePost(Post pt)
        {
      //      _data.Posts.Update(pt);
            _data.Update(pt);

            return await SaveAllAsync();
        }


        //Delete the post
        public async Task<bool> DeletePost(Post pt)
        {
            _data.Posts.Remove(pt);
             return await SaveAllAsync();

        }



    }
}
