namespace sacramentplanner.Models
{
    public class Bishopric
    {
        public int BishopricId { get; set; }
        public string BishopName { get; set; }
        public string FirstCounselorName { get; set; }
        public string SecondCounselorName { get; set; }
        public Boolean ?IsValid { get; set; }
        public DateTime ?ServiceDate { get; set; }
    }
}