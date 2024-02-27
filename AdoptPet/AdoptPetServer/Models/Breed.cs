namespace AdoptPet.Models
{

    public class Breeds
    {
        public List<Breed> breeds { get; set; }
}

    public class Breed
    {
        public string name { get; set; } = string.Empty;
        public Link _links { get; set; } = null!;
    }

    public class Link
    {
        public LinkType type { get; set; } = null!;
    }

    public class LinkType
    {
        public string href { get; set; } = string.Empty;
    }
}
