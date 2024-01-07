using Microsoft.AspNetCore.Http;

namespace App.Business.ViewModels.Manage
{
    public class UpdatePostVM
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }

        public string? Description { get; set; }
        public IFormFile? Image { get; set; }
    }
}
