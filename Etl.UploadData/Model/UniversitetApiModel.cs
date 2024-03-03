using Etl.DataAccess.Postgres.Model;
using System.Text.Json.Serialization;


namespace Etl.UploadData.Model
{
    public class UniversitetApiModel
    {
        [JsonPropertyName("alpha_two_code")]
        public string AphaTwoCode { get; set; } = string.Empty;

        [JsonPropertyName("web_pages")]
        public List<string> webPages { get; set; } = [];

        [JsonPropertyName("state-province")]
        public string StateProvince { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;


        [JsonPropertyName("domains")]
        public List<string> domains { get; set; } = [];

        [JsonPropertyName("country")]
        public string Country { get; set; } = string.Empty;
    }
}
