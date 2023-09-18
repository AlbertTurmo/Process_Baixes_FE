using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baixes_Desktop
{
    class GrupForm_Ext
    {

        public enum TableType
        {
            Contacts,
            Servers,
            Transports,
            Horary
        }

        #region Load Sub Objects
        

        internal static DataTable LoadSubTable(Groups Group, TableType TableType)
        {
            DataTable DataTable = null;

            if(TableType==TableType.Contacts)
            {
                DataTable = LoadContacts(Group);
            }
            else
            if (TableType == TableType.Servers)
            {
                DataTable = LoadServers(Group);
            }
            else
            if (TableType == TableType.Transports)
            {
                DataTable = LoadTransports(Group);
            }
            else
            if (TableType == TableType.Horary)
            {
                DataTable = LoadHorary(Group);
            }
            
            return DataTable;
        }

        private static DataTable LoadHorary(Groups Group)
        {
            DataTable DataTable = WeekTools.GetDataTable(Group.Horari);
            return DataTable;
        }

        internal static DataTable LoadContacts(Groups Group)
        {
            DataTable Contacts = CreateContactsDataTable();

            foreach (Contactes Contacta in Group.Contactes)
            {
                DataRow DataRow = Contacts.Rows.Add();
                DataRow["Nom"] = Contacta.Nom;
                DataRow["Telefon"] = Contacta.Telefon;
            }

            return Contacts;
        }

        internal static DataTable LoadServers(Groups Group)
        {
            DataTable Servers = GrupForm_Ext.CreateServicesDataTable();

            foreach (Servidors Server in Group.Servidors)
            {
                DataRow DataRow = Servers.Rows.Add();
                DataRow["Nom"] = Server.nom;
                DataRow["Telefon"] = Server.telefon;
                DataRow["Servei"] = Server.servei;
            }

            return Servers;
        }


        internal static DataTable LoadTransports(Groups Group)
        {
            DataTable Transports = GrupForm_Ext.CreateTransportsDataTable();

            foreach (Transports Transport in Group.Transports)
            {
                DataRow Start = Transports.Rows.Add();
                Start["Tipus"] = Transport.Tipus;
                Start["Linia"] = Transport.Linia;
                Start["Estacio"] = Transport.Estacio;
                Start["Link"] = Transport.Link;


            }

            return Transports;
        }



        #endregion Load Sub Objects



        #region Create Tables
        internal static DataTable CreateContactsDataTable()
        {
            DataTable Contacts = new DataTable();
            Contacts.Columns.Add(new DataColumn("Nom", typeof(string)));
            Contacts.Columns.Add(new DataColumn("Telefon", typeof(string)));
            return Contacts;
        }


        internal static DataTable CreateServicesDataTable()
        {
            DataTable Contacts = new DataTable();
            Contacts.Columns.Add(new DataColumn("Nom", typeof(string)));
            Contacts.Columns.Add(new DataColumn("Telefon", typeof(string)));
            Contacts.Columns.Add(new DataColumn("Servei", typeof(string)));

            return Contacts;

        }


        internal static DataTable CreateTransportsDataTable()
        {
            DataTable Contacts = new DataTable();
            Contacts.Columns.Add(new DataColumn("Tipus", typeof(string)));
            Contacts.Columns.Add(new DataColumn("Linia", typeof(string)));
            Contacts.Columns.Add(new DataColumn("Estacio", typeof(string)));
            Contacts.Columns.Add(new DataColumn("Link", typeof(string)));

            return Contacts;

        }


        #endregion Create Tables




    }
}
