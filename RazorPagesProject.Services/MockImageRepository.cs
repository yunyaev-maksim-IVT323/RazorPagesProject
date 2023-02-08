using RazorPagesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPagesProject.Services
{
    public class MockImageRepository : IImageRepository
    {
        private List<Image> _imageList;
        public MockImageRepository() 
        {
            _imageList = new List<Image>()
            {
                new Image() { Id = 0, Path = "truba1.png"},
                new Image() { Id = 1, Path = "truba2.jpg" },
            };
        }

        public IEnumerable<Image> GetAllImages()
        {
            return _imageList;
        }
        public Image GetImage(int id)
        {
            return _imageList.FirstOrDefault(i => i.Id == id);
        }

        // Метод добавления картинки
        public Image AddImage(Image newImage)
        {
            if (_imageList.Count > 0)
            {
                newImage.Id = _imageList.Max(i => i.Id) + 1;
            }
            else newImage.Id = 0; //?

            _imageList.Add(newImage);
            return newImage;
        }

        // Метод удаления картинки
        public Image DeleteImage(int id)
        {
            Image imageDelete = _imageList.FirstOrDefault(x => x.Id == id);
            if (imageDelete != null)
            {
                _imageList.Remove(imageDelete);
            }
            return imageDelete;
        }
    }
}
