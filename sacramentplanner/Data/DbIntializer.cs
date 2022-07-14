using sacramentplanner.Models;
using Microsoft.EntityFrameworkCore;

namespace sacramentplanner.Data
{
    public class DbInitializer
    {
    public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SacramentPlannerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SacramentPlannerContext>>()))
            {
            // Look for any students.
           if (context.Members.Any())
            {
                return;   // DB has been seeded
            }

             if (context.Hymns.Any())
            {
                return;   // DB has been seeded
            }

             if (context.Bishoprics.Any())
            {
                return;   // DB has been seeded
            }

            var Members = new Member[]
            {
                new Member { FullName = "Carson Davis"},
                new Member { FullName = "Marvis Davis"},
                new Member { FullName = "Phil Wilson"},
                new Member { FullName = "Debra Jones"},
                new Member { FullName = "John Doe"},
              
            };

            foreach (Member m in Members)
            {
                context.Members.Add(m);
            }
            context.SaveChanges();

            var Bishoprics = new Bishopric[]
            {
                new Bishopric { BishopName= "Kevin Castro", FirstCounselorName= "Ben Smith", SecondCounselorName="Lakeram Narine"  },
               
            };

            foreach (Bishopric b in Bishoprics)
            {
                context.Bishoprics.Add(b);
            }
            context.SaveChanges();

            var sacramentPlan = new SacramentPlan[]
            {
                new SacramentPlan { 
                SacramentDate=DateTime.Now, 
                Presiding="John Doe",
                Conducting="Lakeram Narine",
                OpeningHymnNumber=2, 
                OpeningHymnName="The Spirit of God",
                Invocation="Jane Smith", 
                SacramentHymnNumber=301, 
                SacramentHymnName="I am a Child of God",
                Talks=new Talk[] {new Talk {Speaker="Carson Davis", Topic="The Word of God"},
                                   new Talk {Speaker="Marvis Davis", Topic="The Book of Mormon"},
                                   new Talk {Speaker="Phil Wilson", Topic="The Holy Ghost"}},
                IsFastSunday=false, 
                ClosingHymnNumber=304, 
                ClosingHymnName="Teach Me to Walk in the Light",
                Benediction="Jacob Smith" }  ,

                new SacramentPlan { 
                SacramentDate=DateTime.Now, 
                Presiding="Jim Doe",
                Conducting="Kevin Castro",
                OpeningHymnNumber=2, 
                OpeningHymnName="The Spirit of God",
                Invocation="Jill Smith", 
                SacramentHymnNumber=303, 
                SacramentHymnName="I am a Child of God",
                Talks=new Talk[] {
                                   new Talk {Speaker="Debra Jones", Topic="The Atonement"},
                                   new Talk {Speaker="John Doe", Topic="Humility"}},
                IsFastSunday=false, 
                ClosingHymnNumber=239, 
                ClosingHymnName="Called to Serve",
                Benediction="Jonathon Smith" },

                new SacramentPlan { 
                SacramentDate=DateTime.Now, 
                Presiding="William Taylor",
                Conducting="Samuel Smith",
                OpeningHymnNumber=2, 
                OpeningHymnName="The Spirit of God",
                Invocation="Jennie Handy", 
                SacramentHymnNumber=303, 
                SacramentHymnName="I am a Child of God",
                Talks=new Talk[] {new Talk {Speaker="Jimmy Smith", Topic="Charity"},
                                   new Talk {Speaker="Matthew Roe", Topic="Ministering"},
                                   new Talk {Speaker="Winsten Bartholomew", Topic="Patience"}},
                IsFastSunday=false, 
                ClosingHymnNumber=239, 
                ClosingHymnName="Called to Serve",
                Benediction="Tim Thayne" }
               
            };
            foreach (SacramentPlan s in sacramentPlan)
            {
                context.SacramentPlans.Add(s);
            }

            var hymns = new Hymn[]
            {
                new Hymn {HymnName="The Spirit of God", HymnNumber= "2"},
                new Hymn {HymnName="I am a Child of God", HymnNumber= "301"},
                new Hymn {HymnName="Teach me to walk in the Light", HymnNumber= "304"},
                new Hymn {HymnName="Keep the Commandment", HymnNumber= "303"},
                 new Hymn {HymnName="Choose the Right", HymnNumber= "239"}
            };

            foreach (Hymn h in hymns)
            {
                context.Hymns.Add(h);
            }
            context.SaveChanges();  
        }
        }
    }
}