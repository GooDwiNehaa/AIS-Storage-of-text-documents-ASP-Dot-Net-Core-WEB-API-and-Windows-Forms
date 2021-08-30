using System.Linq;
using Microsoft.Extensions.Configuration;
using ServerDiplom.BusinessLogic;
using ServerDiplom.Models;

namespace ServerDiplom
{
    public class SampleData
    {
        public static IConfiguration Configuration{ get; set; }
        public static void Initialize(ApplicationContext db)
        {
            if (!db.TypeUsers.Any())
            {
                db.TypeUsers.AddRange
                (
                    new TypeUser { Name = "Администратор" },
                    new TypeUser { Name = "Обычный пользователь" }
                );

                db.SaveChanges();
            }
            if (!db.Users.Any())
            {
                db.Users.AddRange
                (
                    new User
                    {
                        UserLogin = "admin",
                        UserPassword = HashData.GetHash("superroot666"),
                        TypeUser = db.TypeUsers.ToList()[0]
                    }
                );

                db.SaveChanges();
            }
            if (!db.Categories.Any())
            {
                db.Categories.AddRange
                (
                    new Category { Name = "Медицина"},
                    new Category { Name = "Спорт"},
                    new Category { Name = "Книги"}
                );

                db.SaveChanges();
            }
        }
    }
}
