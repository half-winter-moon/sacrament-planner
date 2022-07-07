namespace sacramentplanner.Models 
{
    public class Talk
    {
        public int TalkId { get; set; }
        public int ?SacramentPlanId { get; set; }
        public string Speaker { get; set; }
        public string Topic { get; set; }
        public SacramentPlan SacramentPlan { get; set; }
    }  
}