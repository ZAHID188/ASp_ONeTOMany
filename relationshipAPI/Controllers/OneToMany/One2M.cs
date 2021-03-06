using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using relationshipAPI.Data;
using relationshipAPI.Data.Dtos.One_TO_Many;
using relationshipAPI.Interfaces;
using relationshipAPI.Model.One_TO_many;

namespace relationshipAPI.Controllers.OneToMany
{
    [Route("api/[controller]")]
    [ApiController]
    public class One2M : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly DataContext _data;
        private readonly IBlog12M_repo _repo;

        public One2M(IBlog12M_repo repo, IMapper mapper,DataContext data)
        {

            _mapper = mapper;
            _data = data;
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blog12M_Dto>>> GetBlogs()
        {
            var blogs = await _repo.GetBlogAsync();
            var userToReturn=_mapper.Map<IEnumerable<Blog12M_Dto >> (blogs);   
            return Ok(userToReturn);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Blog12M_Dto>> GetBlog(int id)
        {
            var blog = await _repo.GetBlogByIdAsync(id);
            var blogToReturn=_mapper.Map<Blog12M_Dto> (blog);
            return Ok(blogToReturn);

        }

       [HttpPost]
        public async Task<ActionResult<Blog12M>> CreateBlog(BlogUpdateDto dto)
        {
            await _repo.SaveAsync(dto);

            //Below 2 line to show the list of blogs
            var blogs = await _repo.GetBlogAsync();
            var userToReturn = _mapper.Map<IEnumerable<Blog12M_Dto>>(blogs);


            return Ok(userToReturn);

        }

    

        [HttpPut]
        public  async Task<ActionResult> UpdateBlog(BlogUpdateDto blog)
        {
            var upadate_blog= await _repo.GetBlogByIdAsync(blog.BlogId);
            _mapper.Map(blog, upadate_blog);
            await _repo.UpdateSingle(upadate_blog);
            var blgtor = _mapper.Map<Blog12M_Dto>(upadate_blog);
            return Ok(blgtor);

        }

        [HttpDelete]
        public async Task<ActionResult> DelBlog(int id)
        {
            var Del_blog = await _repo.GetBlogByIdAsync(id);
            await _repo.DeleteBlog(Del_blog);
            var blogs = await _repo.GetBlogAsync();
            var blogToReturn = _mapper.Map<IEnumerable<Blog12M_Dto>>(blogs);
            return Ok(blogToReturn);

        }



        //post create

        [HttpGet("Posts")]
        public async Task<ActionResult<IEnumerable<Post_Dto>>> GetPosts()
        {
            var posts = await _repo.GetPostsAsync();
            return Ok(posts);
        }

        [HttpGet("Posts/{id}")]
        public async Task<ActionResult<IEnumerable<Post_Dto>>> GetPost(int id)
        {
            var posts = await _repo.GetPostByIdAsync(id);
            return Ok(posts);
        }



        [HttpPost("Posts")]
        public async Task<ActionResult<Post>> CreatePost(PostUpdateDto pt)
        {
            await _repo.SavePostAsync(pt);
            //Below 2 line to show the list of blogs
            var blogs = await _repo.GetBlogAsync();
            var userToReturn = _mapper.Map<IEnumerable<Blog12M_Dto>>(blogs);
            return Ok(userToReturn);

        }

        [HttpPut("Posts")]
        public async Task<ActionResult> UpdatePost(PostUpdateDto pt)
        {
            var Selected_post = await _repo.GetPostByIdAsync(pt.PostId);
            _mapper.Map(pt, Selected_post);
            await _repo.UpdateSinglePost(Selected_post);
            var blgtor = _mapper.Map<Post_Dto>(Selected_post);
            return Ok(blgtor);

        }

        [HttpDelete("Posts")]
        public async Task<ActionResult> DeletePost(int id)
        {
            var Select_post=await _repo.GetPostByIdAsync(id);

            await _repo.DeletePost(Select_post);
            var posts = await _repo.GetPostsAsync();
            return Ok(posts);


        }



    } 
}