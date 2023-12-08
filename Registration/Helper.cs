using Registration.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Registration
{
    internal class Helper
    {
        private static CompBaseEntities s_firstDBEntities;
        public static CompBaseEntities GetContext()
        {
            if (s_firstDBEntities == null)
            {
                s_firstDBEntities = new CompBaseEntities();
            }
            return s_firstDBEntities;
        }
        public void CreateUser(Models.Users users)
        {
            GetContext().Users.Add(users);
            GetContext().SaveChanges();
        }
        public void UpdateUser(Models.Users users)
        {
            s_firstDBEntities.Entry(users).State = EntityState.Modified;
            s_firstDBEntities.SaveChanges();
        }
        public void RemoveUser(int idUsers)
        {
            var users = s_firstDBEntities.Users.Find(idUsers);
            s_firstDBEntities.Users.Remove(users);
            s_firstDBEntities.SaveChanges();
        }
        public void FiltrUser()
        {
            var users = s_firstDBEntities.Employeey.Where(x => x.Name.StartsWith("М") || x.Name.StartsWith("А"));
        }
        public void SortUser()
        {
            var users = s_firstDBEntities.Employeey.OrderBy(x => x.Name);
        }
    }
}
