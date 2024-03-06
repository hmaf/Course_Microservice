using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Category.Application.Dtos.Pagging
{
    public record Filter(int Page, int Take)
    {
    }
}
