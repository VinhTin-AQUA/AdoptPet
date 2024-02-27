namespace AdoptPet.Models
{
    public class Token
    {
        public string token_type { get; set; } = string.Empty;
        public string expires_in { get; set; } = string.Empty;
        public string access_token { get; set; } = string.Empty;
    }
}
