using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesProject.Services;
using RazorPagesProject.Models;

namespace RazorPagesProjectGeneral.Pages.Images
{
    public class ImagesModel : PageModel
    {
        private IImageRepository _db;
        public ImagesModel(IImageRepository db) 
        {
            _db = db;
        }
        public IEnumerable<Image> Images { get; set; }
        public void OnGet()
        {
            Images = _db.GetAllImages();
        }
    }
}
