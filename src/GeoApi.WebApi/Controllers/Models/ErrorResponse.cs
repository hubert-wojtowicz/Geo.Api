namespace Geo.Api.Controllers.Models
{
    public class ErrorResponse
    {
        public ErrorResponse()
        {
            Messages = new List<string>();
        }
        public IEnumerable<string> Messages { get; set; }
    }
}