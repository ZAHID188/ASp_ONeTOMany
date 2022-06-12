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
        private readonly IBlog12M_repo _repo;

        public One2M(IBlog12M_repo repo, IMapper mapper)
        {

            _mapper = mapper;
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
        public async Task<ActionResult<Blog12M>> CreateBlog(Blog12M dto)
        {
            var blog = await _repo.SaveAsync(dto);
            return Ok(blog);




        }
    } 
}