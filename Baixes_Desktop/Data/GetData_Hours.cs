using System;
using System.Data.Entity;
using System.Linq;

namespace Baixes_Desktop
{
    partial class GetData
    {
        public static class Hours
        {
            public enum RowAction
            {
                Add,
                Delete,
                Update
            }


            public static void Modify_Row_Hour(int Id, string WeekDay, TimeSpan TimeSpan_New, TimeSpan TimeSpan_Old, RowAction RowAction)
            {
                Horari Horary = GetHorary(Id, WeekDay, TimeSpan_Old);


                if (RowAction == RowAction.Add)
                {
                    AddHour(Id, WeekDay, TimeSpan_New);
                }
                else
                if (RowAction == RowAction.Delete)
                {
                    DeleteHour(Horary);
                }
                else
                if (RowAction == RowAction.Update)
                {
                    UpdateHour(TimeSpan_New, Horary);
                }
            }




            public static void AddHour(int Id, string WeekDay, TimeSpan TimeSpan_New)
            {
                using (Anonims_Entities Anomims_Context = new Anonims_Entities())
                {
                    Horari NewHorari = new Horari
                    {
                        GroupsId = Id,
                        WeekDay = WeekDay,
                        Hour = TimeSpan_New
                    };

                    Anomims_Context.Entry(NewHorari).State = EntityState.Added;
                    Anomims_Context.SaveChanges();

                }

            }

            public static void DeleteHour(Horari Horary)
            {
                using (Anonims_Entities Anomims_Context = new Anonims_Entities())
                {
                    Anomims_Context.Entry(Horary).State = System.Data.Entity.EntityState.Deleted;
                    Anomims_Context.SaveChanges();
                }
            }


            public static void UpdateHour(TimeSpan TimeSpan_New, Horari Horary)
            {

                using (Anonims_Entities Anomims_Context = new Anonims_Entities())
                {
                    Horary.Hour = TimeSpan_New;
                    Anomims_Context.Entry(Horary).State = System.Data.Entity.EntityState.Modified;
                    Anomims_Context.SaveChanges();

                }



            }

            public static Horari GetHorary(int Id, string Day, TimeSpan Time)
            {
                Horari Horari = null;


                using (Anonims_Entities db = new Anonims_Entities())
                {
                    Horari = (from Element in db.Horari where Element.Hour == Time && Element.WeekDay == Day select Element).Include(a => a.Groups).Where(e => e.GroupsId == Id).FirstOrDefault();
                }


                return Horari;
            }

        }


    }
}
