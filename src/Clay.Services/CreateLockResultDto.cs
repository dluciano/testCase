using System.Collections.Generic;

namespace Clay.WebApi
{
    public class ResultDto
    {
        public IDictionary<string, string> Errors { get; } = new Dictionary<string, string>();
        public string StatusMessage { get; set; }
        public ResultType ResultType { get; }
        public object Value { get; set; }

        private ResultDto(ResultType resultType)
        {
            ResultType = resultType;
        }

        private ResultDto(ResultType resultType, object value)
            : this(resultType)
        {
            ResultType = resultType;
        }

        public static ResultDto NotFound(string message) =>
            new ResultDto(ResultType.EntityNotFounded)
            {
                StatusMessage = message,
            };

        public static ResultDto Ok(object value, string message = "") =>
            new ResultDto(ResultType.Sucessful, value)
            {
                StatusMessage = message,
                Value = value
            };
    }
}