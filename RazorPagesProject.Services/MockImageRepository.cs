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
        private List<Image> ImageList;
        public MockImageRepository() 
        {
            ImageList = new List<Image>()
            {
                new Image() { Id = 0, Path = "dsaf"},
                new Image() { Id = 1, Path = "qwer" },
                new Image() { Id = 2, Path = "xcvz" },
            };
        }
        public IEnumerable<Image> GetAllImages()
        {
            return ImageList;
        }
    }
}
