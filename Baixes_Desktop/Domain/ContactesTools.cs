using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baixes_Desktop
{
    class ContactesTools
    {
        internal static List<Contactes> ConvertDataTableToListContactes(DataTable DataTable, int GroupId)
        {
            List<Contactes> ListContactes = new List<Contactes>();

            foreach (DataRow DataRow in DataTable.Rows)
            {
                Contactes Contacta = new Contactes()
                {
                    GroupsId = GroupId,
                    Nom = DataRow["Nom"].ToString(),
                    Telefon = int.Parse(DataRow["Telefon"].ToString())
                };

                ListContactes.Add(Contacta);

            }
            return ListContactes;
        }


    }
}
