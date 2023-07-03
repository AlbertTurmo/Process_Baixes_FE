using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sql_Data
{
    public class SqlData_Users
    {

        public static List<Usuarios> GetUsers()
        {
            List<Usuarios> ListUsuarios = new List<Usuarios>();

            using (orior_production_entities db = new orior_production_entities())
            {
                ListUsuarios = (from Element in db.Usuarios select Element).ToList();
            }
            return ListUsuarios;
        }

        public static bool CheckUser(string WindowsId)
        {
            bool Exists = false;

            Usuarios Usuario = (from Element in GetUsers() where (Element.windowsid==WindowsId) select Element).FirstOrDefault();

            if(Usuario!=null)
            {
                Exists = true;
            }

            return Exists;

        }
    }
}
