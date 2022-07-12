namespace sacramentplanner.Models 
{
    public class SacramentPlan 
    {
        public int SacramentPlanId { get; set; }
        
        public DateTime SacramentDate { get; set; }
        public string Presiding { get; set; }
        public string Conducting { get; set; }
        public string OpeningHymn { get; set; }
        public string Invocation { get; set; }
        public string SacramentHymn { get; set; }
        public ICollection<Talk> ?Talks { get; set; }
        public Boolean IsFastSunday { get; set; }
        public string ClosingHymn { get; set; }
        public string Benediction { get; set; }
    }
}