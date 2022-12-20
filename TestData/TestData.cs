using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestData
{
    public class TestData
    {
        public static List<DataAccessUser> GetTestData()
        {
            List<DataAccessUser> listUsers = new List<DataAccessUser>();

            DataAccessUser u = new DataAccessUser
            {
                UserName = "zile",
                GUID = Guid.NewGuid(),
                Name = "Zivko Arsenov",
                Description = "Administrator",
                EmailAddress = "zivkoarsenov@yahoo.com"
            };
            listUsers.Add(u);

            DataAccessUser u1 = new DataAccessUser
            {
                UserName = "marko",
                GUID = Guid.NewGuid(),
                Name = "Marko Markovic",
                Description = "Korisnik",
                EmailAddress = "marko@yahoo.com"
            };
            listUsers.Add(u1);

            DataAccessUser u2 = new DataAccessUser
            {
                UserName = "janko",
                GUID = Guid.NewGuid(),
                Name = "Janko Jankovic",
                Description = "Korisnik",
                EmailAddress = "janko@yahoo.com"
            };
            listUsers.Add(u2);

            DataAccessUser u3 = new DataAccessUser
            {
                UserName = "milica",
                GUID = Guid.NewGuid(),
                Name = "Milica Milic",
                Description = "Korisnik",
                EmailAddress = "milica@yahoo.com"
            };
            listUsers.Add(u3);

            DataAccessUser u4 = new DataAccessUser
            {
                UserName = "Jelena",
                GUID = Guid.NewGuid(),
                Name = "Jelena Jankovic",
                Description = "Korisnik",
                EmailAddress = "jelena@yahoo.com"
            };
            listUsers.Add(u4);

            return listUsers;
        }
    }
}
