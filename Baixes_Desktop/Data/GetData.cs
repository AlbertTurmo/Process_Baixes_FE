using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.ComponentModel.Design;
using System.Data;
using static Baixes_Desktop.WeekTools;

namespace Baixes_Desktop
{
    partial class GetData
    {
        public static List<Groups> ListGroups;
        public static List<GroupDto> ListGroupsDto;
         
        public enum EstatGroup
        {
            Obert,
            Tancat,
            Tots
        }


        public static List<GroupDto> GetGroupsDto()
        {

            List<Groups> ListGroups = GetGroupsTots();

            List<GroupDto> ListGroupsDtos = MapGroups(ListGroups);

            return ListGroupsDtos;

        }

        public static void SetGroups(EstatGroup EstatGroup)
        {
            ListGroups = GetGroups(EstatGroup);
            ListGroupsDto = MapGroups(ListGroups);

        }

        private static List<Groups> GetGroups(EstatGroup EstatGroup)
        {
            List<Groups> ListGroups = null;

            if (EstatGroup==EstatGroup.Obert)
            {
                ListGroups = GetGroupsOberts(true);
            }
            else
            if (EstatGroup == EstatGroup.Tancat)
            {
                ListGroups = GetGroupsOberts(false);

            }
            else
            if (EstatGroup == EstatGroup.Tots)
            {
                ListGroups = GetGroupsTots();
            }


            return ListGroups;

        }




        private static List<Groups> GetGroupsOberts(bool Estat)
        {
            List<Groups> ListGroups = null;
            ListGroups = GetGroupsTots();
            ListGroups = (from Elemnt in ListGroups where Elemnt.Opened == Estat select Elemnt).ToList();
            return ListGroups;

        }




        private static List<Groups> GetGroupsTots()
        {
            List<Groups> ListGroups = null;


            using (Anonims_Entities db = new Anonims_Entities())
            {
                ListGroups = (from Element in db.Groups.Include(a => a.Adreces).Include(e => e.Locals).Include
                              (e => e.Sections).Include(e => e.Mails).Include(e => e.Horari).Include(e => e.Obertes).Include
                              (e => e.Festius).Include(a => a.Acces).Include(a => a.Adreces.LatLon).Include(a => a.Contactes).Include
                              (a => a.Servidors).Include(a => a.Transports) select Element).ToList();
            }


            return ListGroups;
        }


        public static Groups GetGroup(int Id)
        {
            Groups Group = null;


            using (Anonims_Entities db = new Anonims_Entities())
            {
                Group = (from Element in db.Groups where Element.GrupsId == Id select Element)
                    .Include(a => a.Adreces)
                    .Include(e => e.Locals)
                    .Include(e => e.Sections)
                    .Include(e => e.Mails)
                    .Include(e => e.Obertes)
                    .Include(e => e.Horari).FirstOrDefault();
            }


            return Group;
        }


        public static void SaveData(Groups Group)
        {
            bool Success = false;


            using (Anonims_Entities db = new Anonims_Entities())
            {

                Groups GroupToUpdate = GetGroup(Group.GrupsId);
                
                GroupToUpdate.NomGrup = Group.NomGrup;

                Success = UpdateAdreces(Group, GroupToUpdate);

                GroupToUpdate.Obertes = Group.Obertes;
                GroupToUpdate.Festius = Group.Festius;
                GroupToUpdate.Mails = Group.Mails;
              

                db.Entry(GroupToUpdate.Adreces).State = EntityState.Modified;
                db.Entry(GroupToUpdate.Obertes).State = EntityState.Modified;
                db.Entry(GroupToUpdate.Festius).State = EntityState.Modified;
                db.Entry(GroupToUpdate.Mails).State = EntityState.Modified;


                db.Horari.RemoveRange(GroupToUpdate.Horari);
                db.Horari.AddRange(Group.Horari);


                db.Contactes.RemoveRange(GroupToUpdate.Contactes);
                db.Contactes.AddRange(Group.Contactes);


                db.Entry(GroupToUpdate).State = EntityState.Modified;
                db.SaveChanges();


                
                //// db.Entry(GroupToUpdate.Horari).State = EntityState.Deleted;
                //db.SaveChanges();


                
                //// db.Entry(Groups.Horari).State = EntityState.Added;
                //db.SaveChanges();

            }



        }

        private static bool UpdateAdreces(Groups Groups, Groups GroupToUpdate)
        {
            bool Success = false;

            try
            {
                /* update adreça */
                GroupToUpdate.Adreces.tv = Groups.Adreces.tv;
                GroupToUpdate.Adreces.c = Groups.Adreces.c;
                GroupToUpdate.Adreces.num = Groups.Adreces.num;
                GroupToUpdate.Adreces.anum = Groups.Adreces.anum;
                GroupToUpdate.Adreces.pt = Groups.Adreces.pt;
                GroupToUpdate.Adreces.cp = Groups.Adreces.cp;
                GroupToUpdate.Adreces.poblacio = Groups.Adreces.poblacio;
                GroupToUpdate.Adreces.provincia = Groups.Adreces.provincia;
                Success = true;
            }
            catch(Exception Exception)
            {
                Success = false;
                throw Exception;
            }

            return Success;
          
        }

        public static void SaveData_old(Groups Groups)
        {
            List<Horari> NewHorari = new List<Horari>
            {
                new Horari()
                {
                    GroupsId = 8,
                    Hour = new TimeSpan(10, 10, 0),
                    WeekDay = DaysOfWeek.Thursday.ToString()
                },
                
                new Horari()
                {
                    GroupsId = 8,
                    Hour = new TimeSpan(11, 10, 0),
                    WeekDay = DaysOfWeek.Thursday.ToString()
                },

            };

            Horari H = new Horari()
            {
                GroupsId = 8,
                Hour = new TimeSpan(12, 50, 0),
                WeekDay = DaysOfWeek.Thursday.ToString()
            };

            using (Anonims_Entities db = new Anonims_Entities())
            {

                Groups GroupToUpdate = GetGroup(Groups.GrupsId);

                GroupToUpdate.NomGrup = Groups.NomGrup;

                GroupToUpdate.Adreces.tv = Groups.Adreces.tv;
                GroupToUpdate.Adreces.c = Groups.Adreces.c;
                GroupToUpdate.Adreces.num = Groups.Adreces.num;
                GroupToUpdate.Adreces.anum = Groups.Adreces.anum;
                GroupToUpdate.Adreces.pt = Groups.Adreces.pt;
                GroupToUpdate.Adreces.cp = Groups.Adreces.cp;
                GroupToUpdate.Adreces.poblacio = Groups.Adreces.poblacio;
                GroupToUpdate.Adreces.provincia = Groups.Adreces.provincia;


                db.Entry(GroupToUpdate.Adreces).State = EntityState.Modified;


                /* *********  ATENCIO   *************** */
                // db.Horari.RemoveRange(GroupToUpdate.Horari);
                // db.Horari.AddRange(NewHorari);

                List<Horari> HorariCollection = GroupToUpdate.Horari.ToList();


                foreach (Horari Horari in HorariCollection)
                {
                    Horari n = db.Entry(Horari).Entity;
                    db.Entry(n).State = EntityState.Deleted;
                }


                UpdateHoraris(db, HorariCollection);

                // db.Horari.Add(H);

                db.Entry(GroupToUpdate).State = EntityState.Modified;
                db.SaveChanges();

            }



        }

        private static void UpdateHoraris(Anonims_Entities db, ICollection<Horari> HorariCollection)
        {
            foreach (Horari Horari in HorariCollection)
            {
                Console.WriteLine(Horari.HorariId);

                Horari.Hour = new TimeSpan(17, 0, 0);

                Console.WriteLine(Horari.Hour);

                db.Entry(Horari).State = EntityState.Modified;
            }
        }

        public static void SaveData(Groups G, Horari newStart, Horari newEnd)
        {
            using (Anonims_Entities db = new Anonims_Entities())
            {

                Groups aa = db.Entry(G).Entity;


                aa.Horari.Add(newStart);
                db.Entry(aa.Horari).State = EntityState.Added;
                db.SaveChanges();
                


                
                

            }


           
        }



        public static List<GroupDto> MapGroups(List<Groups> ListGroups)
        {
            List<GroupDto> ListGroupsDtos = new List<GroupDto>();

            foreach(Groups Groups in ListGroups)
            {
                GroupDto groupDto = MapGroup(Groups);
                ListGroupsDtos.Add(groupDto);
            }

            return ListGroupsDtos;

        }



        public static GroupDto MapGroup(Groups Grup)
        {
            GroupDto GroupDto = new GroupDto();

            try
            {

                GroupDto = new GroupDto()
                {
                    GroupNumber = Grup.GrupsId,
                    Name = Grup.NomGrup,
                    Section = Grup.Sections.Section,
                    Adress = Grup.Adreces.Direccion,
                    Town = Grup.Adreces.poblacio,
                    PostalCode = Grup.Adreces.cp.Value.ToString("00000"),
                    Mail = Grup.Mails.EMail
                };
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return GroupDto;
        }

        private static string GetOpenedGroup(bool? Opened)
        {
            if((bool)Opened)
            {
                return "Si";
            }
            else
            {
                return "No";
            }
        }



    }




    public class GroupDto
    {

        public int GroupNumber { get; set; }
        public string Section { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Town { get; set; }
        public string PostalCode { get; set;}
        public string Mail { get; set; }


        public static void GetFields()
        {

            Type myType = typeof(ViewTechnology);

            // Get the fields of the specified class.
            FieldInfo[] myField = myType.GetFields();

            GroupDto g = new GroupDto();

            Type type = typeof(GroupDto);

            var fieldValues = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);


        }




    }
}
