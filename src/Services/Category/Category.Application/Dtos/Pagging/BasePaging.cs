using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Category.Application.Dtos.Pagging
{
    public class BasePaging
    {
        public BasePaging()
        {
            Page = 1;
            Take = 5;
            HowManyShowAfterBefore = 4;
        }
        public int Page { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
        public int HowManyShowAfterBefore { get; set; }
        public int AllPageCount { get; set; }
        public int AllEntitiesCount { get; set; }
    }
}
