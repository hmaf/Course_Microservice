using Category.Api.Infrastructure;
using ErrorOr;

namespace Category.Api.Exception
{
    public class ErrorProcessor
    {
        public static HashSet<Result> ProcessErrors(List<Error> errors)
        {
            var results = new HashSet<Result>();

            foreach (var error in errors)
            {
                var result = CreateResultFromError(error);
                results.Add(result);
            }

            return results;
        }

        private static Result CreateResultFromError(Error error)
        {
            var result = new Result();
            var descriptions = error.Description.Split(",").ToList();

            string? firstDescription = descriptions.FirstOrDefault();
            string? lastDescription = descriptions.LastOrDefault();

            result.Code = error.Code;
            result.Description = new ResultDetail(firstDescription, lastDescription);

            return result;
        }


        
    }
    public record Result
    {
        public string Code { get; set; }
        public ResultDetail Description { get; set; }
    }

    public record ResultDetail(string Code, string Description) { }

}
