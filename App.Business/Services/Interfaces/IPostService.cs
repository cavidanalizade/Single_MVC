using App.Core.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Business.ViewModels.Manage;

namespace App.Business.Services.Interfaces
{
    public interface IPostService
    {
        Task<IQueryable<Post>> GetAllAsync();
        Task<ICollection<Post>> RecycleBin();
        Task<Post> GetById(int id);
        Task Create(CreatePostVM createPostVM);
        Task Delete(int id);
        Task deleteAll();
        Task Update(UpdatePostVM updatePostVM);
        Task Restore();
    }
}
