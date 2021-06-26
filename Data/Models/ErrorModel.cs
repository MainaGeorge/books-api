using Newtonsoft.Json;

namespace my_books.Data.Models
{
    public class ErrorModel
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public string Path { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
