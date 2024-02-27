namespace AdoptPet.Models
{
    public class Animals
    {
        public List<Animal> animals { get; set; } = [];
    }

    public class AnimalSearch
    {
        public Animal animal { get; set; } = null!;
    }

    public class Animal
    {
        public long id { get; set; }
        public string organization_id { get; set; } = string.Empty;
        public string url { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
        public string species { get; set; } = string.Empty;
        public string age { get; set; } = string.Empty;
        public string gender { get; set; } = string.Empty;
        public string size { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public List<Photo> photos { get; set; } = [];

        public string status { get; set; } = string.Empty;
        public DateTime status_changed_at { get; set; }
        public DateTime published_at { get; set; }
        public Contact contact { get; set; } = null!;
    }

    public class Photo
    {
        public string small { get; set; } = string.Empty;
        public string medium { get; set; } = string.Empty;
        public string large { get; set; } = string.Empty;
        public string full { get; set; } = string.Empty;
    }

    public class Contact
    {
        public string email { get; set; } = string.Empty;
        public string phone { get; set; } = string.Empty;
        public Address address { get; set; } = null!;
    }

    public class Address
    {
        public string address1 { get; set; } = string.Empty;
        public string address2 { get; set; } = string.Empty;
        public string city { get; set; } = string.Empty;
        public string state { get; set; } = string.Empty;
        public string postcode { get; set; } = string.Empty;
        public string country { get; set; } = string.Empty;
    }

}
