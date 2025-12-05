using DesignliTest.Core.Domain;

namespace DesignliTest.Infrastructure.InitialData
{
    /// <summary>
    /// Provides initial employee records for the in-memory database.
    /// </summary>
    public static class SeedData
    {
        /// <summary>
        /// Inserts predefined employees if the data store is empty.
        /// </summary>
        public static void Initialize(AppDbContext db)
        {
            if (!db.Employees.Any())
            {
                db.Employees.AddRange(
                    new Employee { Name = "Luis Marroquín", Birthdate = new DateTime(1990, 1, 10), IdentityNumber = "A123"},
                    new Employee { Name = "Enrique Orellana", Birthdate = new DateTime(1985, 6, 20), IdentityNumber = "B456"},
                    new Employee { Name = "Michelle Rodríguez", Birthdate = new DateTime(1992, 11, 5), IdentityNumber = "C789" }
                );

                db.SaveChanges();
            }

            if (!db.UserApp.Any())
            {
                db.UserApp.AddRange(
                    new UserApp { Username = "admin", Password = "1234" },
                    new UserApp { Username = "test1", Password = "1234" },
                    new UserApp { Username = "luis", Password = "1234" }
                );

                db.SaveChanges();
            }
        }
    }

}
