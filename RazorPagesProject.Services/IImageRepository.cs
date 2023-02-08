using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RazorPagesProject.Models;

namespace RazorPagesProject.Services
{
    public interface IImageRepository
    {
        public IEnumerable<Image> GetAllImages();
        public Image GetImage(int id);
        public Image AddImage(Image newImage);
    }
}
