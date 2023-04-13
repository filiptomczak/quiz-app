using Microsoft.EntityFrameworkCore;

namespace QuizTerenowyAPI.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                return;
                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User
                        {
                            Name = "filip",
                            Email = "flp.tomczak@gmail.com",
                            LastName = "tomczak",
                            Role = Role.Admin
                        },
                        new User
                        {
                            Name = "user",
                            Email = "user@user.com",
                            LastName = "user",
                            Role = Role.User
                        });
                }
                if (!context.Places.Any())
                {
                    context.Places.AddRange(
                        new Place
                        {
                            Name = "Kościół Świętego Krzyża",
                            Description = "Pierwsza kaplica na Lipówce powstała w XVII wieku i została ufundowana przez proboszczów wrzesińskich." +
                        "Jej powstanie w tym miejscu łączone jest z położonym w pobliżu źródełkiem, uważanym za cudowne.",
                            Lat = 52.333681003187756,
                            Lon = 17.55107142722498
                        },
                     new Place
                     {
                         Name = "Tama nad Zalewem Lipówka",
                         Description = "Zbiornik został zbudowany w latach 1965–1967 w celach rekreacyjno-sportowych oraz rolniczych. Zasilany jest rzeką Wrześnicą i czterema rowami melioracyjnymi.",
                        Lat = 52.33361481864327,
                         Lon = 17.552869488048245
                     },
                      new Place
                      {
                          Name = "Ratusz ",
                          Description = "Wybudowany w stylu neogotyckim w latach 1909-1910. Znajduje się przy ulicy Ratuszowej, przy Rynku. Obecnie po generalnym remoncie, który miał miejsce w 1992, jest siedzibą Urzędu Miasta i Gminy Września. ",
                      Lat = 52.32568481514093,
                          Lon = 17.56584563609518
                      });
                }
                if (!context.Questions.Any())
                {
                    context.Questions.AddRange(
                        new Question
                        {
                            Description = "W ktorych latach wybudowano tame: ",
                            Option1 = "1965–1967",
                            Option2 = "1955–1957",
                            Option3 = "1975–1977",
                            Answer = "1965–1967",
                            PlaceId = 11
                        },
                         new Question
                         {
                             Description = "W ktorych latach wybudowano ratusz: ",
                             Option1 = "1900-1902",
                             Option2 = "19018-1919",
                             Option3 = "1909-1910",
                             Answer = "1909-1910",
                             PlaceId = 12
                         },
                        new Question
                        {
                            Description = "W ktorym wieku powstal kosciol",
                            Option1 = "XVI w.",
                            Option2 = "XVII w.",
                            Option3 = "XVIII w.",
                            Answer = "XVII w.",
                            PlaceId = 10
                        });
                }
                context.SaveChanges();
            }
        }
    }
}
