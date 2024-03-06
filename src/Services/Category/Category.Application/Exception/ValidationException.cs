using Category.Application.Core.ApplicationError;
using FluentValidation.Results;
using System.Collections.Concurrent;

namespace Category.Application.Exception
{
    public class ValidationException : ApplicationException
    {
        public IDictionary<string, string[]> Errors { get; set; }

        public ValidationException() : base("Validation failed. One or more validation failures have occurred.")
        {
            Errors = new ConcurrentDictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            PopulateErrors(failures);
        }

        private void PopulateErrors(IEnumerable<ValidationFailure> failures)
        {
            Errors = failures
                .GroupBy(failure => failure.PropertyName, failure => failure.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());

        }
    }
}
