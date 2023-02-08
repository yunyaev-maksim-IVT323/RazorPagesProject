using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesProject.Models;
using RazorPagesProject.Services;

namespace RazorPagesProjectGeneral.Pages.Images
{
    public class AddModel : PageModel
    {
        private readonly IImageRepository _imageRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AddModel(IImageRepository imageRepository, IWebHostEnvironment webHostEnvironment)
        {
            _imageRepository = imageRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        [BindProperty]
        public Image Image { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; } // Файл отправленный с помощью Http запроса
        public IActionResult OnGet()
        {
            Image = new Image();
            return Page();
        }
        public IActionResult OnPost() 
        {
            if (Photo != null)
            {
                if (Image.Path != null)
                {
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "all_images", Image.Path);
                }
                Image.Path = ProcessUploadedFile();
                Image = _imageRepository.AddImage(Image);
                return RedirectToPage("Images");
            }
            return Page();
            //Image = _imageRepository.AddImage(Image);
            //return RedirectToPage("Images");
        }
        // Метод обработки фотографии
        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;
            if (Photo != null) 
            {
                // Организовали путь к папке сохранения
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "all_images");
                // Генерируем уникальное имя файла
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName + ".png";
                // Создание полного путя к файлу
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                // Организуем сохранение на сервер
                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fs);
                }
            }
            return uniqueFileName;
        }
    }
}
