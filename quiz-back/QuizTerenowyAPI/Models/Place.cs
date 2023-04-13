namespace QuizTerenowyAPI.Models
{
    public class Place
    {
        public Place()
        {
            Questions = new List<Question>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Lon { get; set; }
        public double? Lat { get; set; }
        public List<Question>? Questions { get; set; }
    }
}
