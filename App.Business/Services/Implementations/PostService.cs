using App.Business.Helper;
using App.Business.Services.Interfaces;
using App.Business.ViewModels.Manage;
using App.Core.Entities;
using App.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Services.Implementations
{
    public class PostService:IPostService
    {
        private readonly IPostRepository _repo;

        public async Task Create(CreatePostVM createPostVM)
        {
            if (!createPostVM.Image.CheckContent("image/"))
            {
                throw new Exception("Duzgun format daxil edin");
            }


            Post post = new Post()
            {
                Title = createPostVM.Title,
                ImageUrl = createPostVM.Image.UploadFile(folderName: "C:\\Users\\II novbe\\source\\repos\\App.DAL\\App.Mvc\\wwwroot\\Upload\\"),
                Description = createPostVM.Description,
                CreatedAt = DateTime.Now,
                IsDeleted = false
            };

             await _repo.Create(post);
            _repo.Save();
        }


        public async Task Delete(int id)
        {
            _repo.delete(id);
        }

        public async Task deleteAll()
        {
            _repo.deleteAll();
        }

        public async Task<IQueryable<Post>> GetAllAsync()
        {
            var posts =  _repo.GetAllAsync();
            return await posts;

        }

        public async Task<Post> GetById(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            return await _repo.GetById(id);
        }

        public async Task<ICollection<Post>> RecycleBin()
        {
            var posts = await _repo.RecycleBin();
            return await posts.ToListAsync();
        }

        public Task Restore()
        {
            throw new NotImplementedException();
        }

        public async Task Update(UpdatePostVM updatePostVM)
        {
            if(updatePostVM != null && _repo.Check(updatePostVM.Id))
            {
               var existingPost =await _repo.GetById(updatePostVM.Id);
                (existingPost).Title = updatePostVM.Title;
                existingPost.Description = updatePostVM.Description;
                existingPost = await _repo.GetById(updatePostVM.Id);
                existingPost.IsDeleted=false;
                if (updatePostVM.ImageUrl != null)
                {
                    existingPost.ImageUrl.RemoveFile("C:\\Users\\II novbe\\source\\repos\\App.DAL\\App.Mvc\\wwwroot\\Upload\\");

                    existingPost.ImageUrl = updatePostVM.Image.UploadFile(folderName: "C:\\Users\\II novbe\\source\\repos\\App.DAL\\App.Mvc\\wwwroot\\Upload\\");
                };
                _repo.Update(existingPost);
                _repo.Save();
 
            }
        }
       

    }
}
