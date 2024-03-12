using AdoptPet.Models;
using Newtonsoft.Json;
using System.Text;

namespace AdoptPet.Services
{
    public class PetService
    {

        // gọi API lấy access token
        private async Task<Token> GetAccessToken()
        {
            // api của thú cưng
            var url = "https://api.petfinder.com/v2/oauth2/token";

            // tạo dữ liệu gửi kèm theo lên server
            var data = new
            {
                grant_type = "client_credentials",
                client_id = "uehjuaxCWm5xM0cjeePkkWPIufyBxu27Goiew6uWQk0wlLVmSp",
                client_secret = "rLhA90HKevqAaMjkQfMGQq4r7ooELZmjgBjtV55z"
            };

            // tạo dữ liệu dạng json
            var jsonContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            // đối với c#, sử dụng HttpClient để gọi API của thú cưng
            using (var http = new HttpClient())
            {
                // tiến hành gửi API lên server, kèm theo dữ liệu json
                var res = await http.PostAsync(url, jsonContent);

                // lấy dữ liệu json trả về ở dạng chuỗi thuần túy hay còn gọi là văn bản
                var content = await res.Content.ReadAsStringAsync();

                // chuyển văn bản trả về sang dạng đối tượng Token
                var token = JsonConvert.DeserializeObject<Token>(content);
                return token!;
            }
        }


        // gọi API lấy tất cả loại giống của animal
        // tham số: type: là tên animal như cat, dog, rabbit,...
        // API này lấy breeds của cat, để biết được cat gồm những giống cat nào
        public async Task<Breeds> GetBreeds(string type)
        {
            // lấy token
            var token = await GetAccessToken();

            // với type truyền tới, thì điều URL cho phù hợp
            string url = $"https://api.petfinder.com/v2/types/{type}/breeds";

            // sử dụng HttpClient 
            using (var http = new HttpClient())
            {
                // đính kèm access_token vào header
                // Authorization là tên header
                // Bearer là kiểu token
                http.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.access_token);

                // GỌI API
                var res = await http.GetAsync(url);

                // kiểm tra status code trả về sau khi gọi API
                // ở đây System.Net.HttpStatusCode.NotFound là phòng trường hợp con vật k có breeds nào
                // System.Net.HttpStatusCode.NotFound tương ứng với 404
                if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // trả về đối tượng rỗng
                    return new Breeds();
                }

                // lấy dữ liệu trả về ở dạng chuỗi
                var content = await res.Content.ReadAsStringAsync();

                // chuyển chuỗi content về đối tượng Breeds
                var breeds = JsonConvert.DeserializeObject<Breeds>(content);
                return breeds!;
            }
        }


        // các tham số trong hàm là các tiêu chí để GetAnimals
        // mặc định các tiêu chí là rỗng, khi đó API sẽ trả về toàn bộ Animals
        public async Task<Animals> GetAnimals(string type = "", string breed = "", string age = "", string size = "", string gender = "", string color = "", int page = 1, int limit = 10)
        {
            // thêm các tiêu chí đó vào url theo dạng query string
            string url = $"https://api.petfinder.com/v2/animals?type={type}&breed={breed}&age={age}&size={size}&gender={gender}&color={color}&page={page}&limit={limit}";

            // lấy access token
            var token =await GetAccessToken();

            // sử dụng HttpCLient để gọi API
            using (var http = new HttpClient())
            {
                // đính kèm access token vào header
                http.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.access_token);

                // gọi API
                var res = await http.GetAsync(url);

                // kiểm tra status code
                // System.Net.HttpStatusCode.BadRequest tương ứng với 400
                // nếu APi trả về System.Net.HttpStatusCode.BadRequest, thì có lỗi gì đó
                if(res.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    return new Animals();
                }

                // lấy dữ liệu trả về ở dạng chuỗi thuần túy
                string content = await res.Content.ReadAsStringAsync();

                // chuyển chuỗi content sang đối tượng Animals
                var animals = JsonConvert.DeserializeObject<Animals>(content);
                return animals!;
            }
        }

        // lấy thông tin của 1 animal theo id
        public async Task<AnimalSearch> GetOne(string id)
        {
            // tùy chỉnh url phù hợp
            string url = $"https://api.petfinder.com/v2/animals/{id}";

            // lấy access token
            var token = await GetAccessToken();

            // sử dụng http client để gọi API
            using (var http = new HttpClient())
            {
                // đính kèm access token để thêm vào header
                http.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.access_token);

                // gọi API
                var res = await http.GetAsync(url);

                // kiểm tra status code sau khi gọi API
                // System.Net.HttpStatusCode.NotFound tương ứng với 404
                // nếu status code là System.Net.HttpStatusCode.NotFound thì không tìm thấy animal
                if(res.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return new AnimalSearch();
                }

                // lấy dữ liệu trả về ở dạng chuỗi thuần túy
                var content = await res.Content.ReadAsStringAsync();

                // chuyển chuỗi content sang đối tượng AnimalSearch
                var animal = JsonConvert.DeserializeObject<AnimalSearch>(content);
                return animal!;
            }
        }
    }
}
