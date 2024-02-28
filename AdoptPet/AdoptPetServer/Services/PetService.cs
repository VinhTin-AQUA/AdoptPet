using AdoptPet.Models;
using Newtonsoft.Json;
using System.Text;

namespace AdoptPet.Services
{
    public class PetService
    {
        private async Task<Token> GetAccessToken()
        {
            var url = "https://api.petfinder.com/v2/oauth2/token";
            var data = new
            {
                grant_type = "client_credentials",
                client_id = "uehjuaxCWm5xM0cjeePkkWPIufyBxu27Goiew6uWQk0wlLVmSp",
                client_secret = "rLhA90HKevqAaMjkQfMGQq4r7ooELZmjgBjtV55z"
            };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            using (var http = new HttpClient())
            {

                var res = await http.PostAsync(url, jsonContent);
                var content = await res.Content.ReadAsStringAsync();
                var token = JsonConvert.DeserializeObject<Token>(content);
                return token!;
            }
        }

        public async Task<Breeds> GetBreeds(string type)
        {
            var token = await GetAccessToken();
            string url = $"https://api.petfinder.com/v2/types/{type}/breeds";

            using (var http = new HttpClient())
            {
                http.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.access_token);
                var res = await http.GetAsync(url);
                if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return new Breeds();
                }
                var content = await res.Content.ReadAsStringAsync();
                var breeds = JsonConvert.DeserializeObject<Breeds>(content);
                return breeds!;
            }
        }

        public async Task<Animals> GetAnimals(string type = "", string breed = "", string age = "", string size = "", string gender = "", string color = "", int page = 1, int limit = 10)
        {
            string url = $"https://api.petfinder.com/v2/animals?type={type}&breed={breed}&age={age}&size={size}&gender={gender}&color={color}&page={page}&limit={limit}";

            var token =await GetAccessToken();

            using (var http = new HttpClient())
            {
                http.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.access_token);
                var res = await http.GetAsync(url);
                if(res.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    return new Animals();
                }
                string content = await res.Content.ReadAsStringAsync();
                var animals = JsonConvert.DeserializeObject<Animals>(content);
                return animals!;
            }
        }

        public async Task<AnimalSearch> GetOne(string id)
        {
            string url = $"https://api.petfinder.com/v2/animals/{id}";
            var token = await GetAccessToken();

            using (var http = new HttpClient())
            {
                http.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.access_token);
                var res = await http.GetAsync(url);

                if(res.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return new AnimalSearch();
                }
                var content = await res.Content.ReadAsStringAsync();
                var animal = JsonConvert.DeserializeObject<AnimalSearch>(content);
                return animal!;
            }
        }
    }
}
