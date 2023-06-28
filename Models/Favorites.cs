namespace API.Models
{
    public class Favorites
    {
        public int Id { get; set; }
        public long ChatID { get; set; }
        public string Name { get; set; }
        
        public int Rating { get; set; }
    }
}
