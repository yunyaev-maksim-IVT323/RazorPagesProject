using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesProject.Models;
using RazorPagesProject.Services;

namespace RazorPagesProjectGeneral.Pages.Images
{
    public class DeleteModel : PageModel
    {
        private readonly IImageRepository _imageRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DeleteModel(IImageRepository imageRepository, IWebHostEnvironment webHostEnvironment)
        {
            _imageRepository = imageRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        [BindProperty]
        public Image Image { get; set; }
        public IActionResult OnGet(int id)
        {
            Image = _imageRepository.GetImage(id);
            return Page();
        }
        public IActionResult OnPost() 
        {
            Image deletedImage = _imageRepository.DeleteImage(Image.Id);
            if (deletedImage.Path != null)
            {
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "all_images", deletedImage.Path);

                if (deletedImage.Path != "noimage.png")
                    System.IO.File.Delete(filePath);
            }
            return RedirectToPage("/Images/Images");
        }
    }
}
