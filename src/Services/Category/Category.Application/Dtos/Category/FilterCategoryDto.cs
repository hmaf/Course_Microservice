using Category.Application.Dtos.Pagging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Category.Application.Dtos.Category
{
    public class FilterCategoryDto : BasePaging
    {
        public List<CategoryDto> Categories { get; set; }

        public FilterCategoryDto SetPaging(BasePaging paging)
        {
            Page = paging.Page;
            Take = paging.Take;
            Skip = paging.Skip;
            AllEntitiesCount = paging.AllEntitiesCount;
            AllPageCount = paging.AllPageCount;
            StartPage = paging.StartPage;
            EndPage = paging.EndPage;
            HowManyShowAfterBefore = paging.HowManyShowAfterBefore;

            return this;
        }
    }
}
