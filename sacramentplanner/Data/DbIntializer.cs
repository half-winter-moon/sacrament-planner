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