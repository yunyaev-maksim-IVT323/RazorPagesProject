using RazorPagesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPagesProject.Services
{
    public class SQLImageRepository : IImageRepository
    {
        private readonly AppDbContext _context;
        public SQLImageRepository(AppDbContext context)
        {
            _context = context;
        }

        public AppDbContext Context { get; }

        public Image AddImage(Image newImage)
        {
            _context.Images.Add(newImage);
            _context.SaveChanges();
            return newImage;
        }

        public Image DeleteImage(int id)
        {
            var _imageToDelete = _context.Images.Find(id);
            if (_imageToDelete != null) 
            {
                _context.Images.Remove(_imageToDelete);
                _context.SaveChanges();
            }
            
            return _imageToDelete;
        }

        public IEnumerable<Image> GetAllImages()
        {
            return _context.Images;
        }

        public Image GetImage(int id)
        {
            return _context.Images.Find(id);
        }
    }
}
