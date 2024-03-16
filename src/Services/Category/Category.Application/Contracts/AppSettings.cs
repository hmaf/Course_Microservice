using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Category.Application.Contracts
{
    public class AppSettings
    {
        public string AppAddress { get; set; }

        public File File { get; set; }
    }
}
