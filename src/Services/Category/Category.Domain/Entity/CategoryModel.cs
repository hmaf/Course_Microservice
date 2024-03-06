using Category.Domain.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Category.Domain.Entity
{
    public class CategoryModel : EntityBase
    {
        public string Title { get; set; }
        public string ShorDescription { get; set; }
        public string LongDescription { get; set; }
        public string Icon { get; set; } = string.Empty;
    }
}
