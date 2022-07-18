namespace sacramentplanner.Models
{
    public class SacramentFake
    {
         public int SacramentFakeId { get; set; }
        
        public DateTime ?SacramentDate { get; set; }
        public string Presiding { get; set; }
        public string Conducting { get; set; }
        public string OpeningHymnName { get; set; }
        public int OpeningHymnNumber { get; set; }
        public string Invocation { get; set; }
        public string SacramentHymnName { get; set; }
        public int SacramentHymnNumber { get; set; }
        public ICollection<string>? Talks { get; set; }
        public Boolean ?IsFastSunday { get; set; }
        public string ClosingHymnName { get; set; }
        public int ClosingHymnNumber { get; set; }
        public string Benediction { get; set; }
    }
}