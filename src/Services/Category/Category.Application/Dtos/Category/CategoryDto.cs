using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Category.Application.Dtos.Category
{
    public class CategoryDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ShorDescription { get; set; }
        public string LongDescription { get; set; }
        public string Icon { get; set; } = string.Empty;
    }
}
