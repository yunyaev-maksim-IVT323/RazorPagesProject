using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesProject.Models;
using RazorPagesProject.Services;

namespace RazorPagesProjectGeneral.Pages.Images
{
    public class DeleteModel : PageModel
    {
        private readonly IImageRepository _imageRepository;

        public DeleteModel(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
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
            return RedirectToPage("/Images/Images");
        }
    }
}
