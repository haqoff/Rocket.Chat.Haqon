using Newtonsoft.Json;

namespace Rocket.Chat.Haqon.Models.RestResults
{
    public class RestResult
    {
        [JsonConstructor]
        public RestResult(string status)
        {
            if (status == "success")
                Success = true;
            else
                Success = false;
        }

        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }

        public bool Success { get; set; }

        public string Error { get; set; }
    }

    public class RestResult<T> : RestResult
    {
        public RestResult(string status) : base(status)
        {
        }

        public T Data { get; set; }
    }
}