using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Console.Models
{
    internal static class Helper
    {
        private static Models.LibraryBaseEntitiess s_LibrararyEntities;

        public static Models.LibraryBaseEntitiess GetContext()
        {
            if (s_LibrararyEntities == null)
            {
                s_LibrararyEntities = new Models.LibraryBaseEntitiess();
            }
            return s_LibrararyEntities;
        }

        public static void CreateUsers(Models.Users users)
        {
            GetContext().Users.Add(users);
            GetContext().SaveChanges();
        }

        public static void UpdateUsers(Models.Users users)
        {
            s_LibrararyEntities.Entry(users).State = EntityState.Modified;
            s_LibrararyEntities.SaveChanges();
        }
        public static void RemoveUsers(int idUsers)
        {
            var users = s_LibrararyEntities.Users.Find(idUsers);
            s_LibrararyEntities.Users.Remove(users);
            s_LibrararyEntities.SaveChanges();
        }
        public static void FiltrUsers()
        {
            var users = s_LibrararyEntities.list_employees.Where(x => x.imya.StartsWith("M") || x.imya.StartsWith("A"));
        }
        public static void SortUsers()
        {
            var users = s_LibrararyEntities.list_employees.OrderBy(x => x.imya);
        }
    }
}

 