using Newtonsoft.Json;

namespace FanCode_BE.Models
{
    public class TodoRequestModel
    {

        [JsonProperty(nameof(UserId), Order = 1)]
        public int UserId { get; set; }
        [JsonProperty("TaskId", Order = 0)]
        public int Id { get; set; }
        [JsonProperty("TaskTitle", Order = 3)]
        public string Title { get; set; } = string.Empty;
        [JsonProperty(Order = 4)]
        public bool Completed { get; set; } = false;
        [JsonProperty(Order = 2)]
        public string Name { get; set; }
    }
}
