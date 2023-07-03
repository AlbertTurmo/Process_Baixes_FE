using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sql_Data
{
    public class SqlData_Exports
    {

        public static List<Exports> GetExports()
        {
            List<Exports> ListExport = new List<Exports>();

            using (orior_production_entities db = new orior_production_entities())
            {
                ListExport = (from Element in db.Exports select Element).ToList();
            }

            return ListExport;
        }

        public static List<Exports> GetExportsByStatus(StatusProcess StatusProcess)
        {
            List<Exports> ListExport = new List<Exports>();

            using (orior_production_entities db = new orior_production_entities())
            {
                ListExport = (from Element in db.Exports where (Element.StatusProcess==StatusProcess.ToString().ToLower()) select Element).ToList();
            }

            return ListExport;
        }

        public static int CountExportsByStatus(StatusProcess StatusProcess)
        {
            int Counter = GetExportsByStatus(StatusProcess).Count();

            return Counter;
        }





        public static Exports Create(Exports Export)
        {
            Exports NewExport = new Exports();
            using (orior_production_entities db = new orior_production_entities())
            {
                NewExport = db.Exports.Add(Export);
                db.SaveChanges();
            }
            return NewExport;
        }

        public static Exports GetExportsAByTicket(string Ticket)
        {
            Exports Export = new Exports();

            using (orior_production_entities db = new orior_production_entities())
            {
                Export = (from Element in db.Exports where Element.IssueKey == Ticket select Element).FirstOrDefault();
            }


            return Export;
        }

        public static Exports UpdateExports(Exports Export)
        {

            using (orior_production_entities db = new orior_production_entities())
            {
                if (Export != null)
                {
                    Export.UpdateProcess = DateTime.Now;
                    db.Entry(Export).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }

            return Export;
        }

        public static Exports UpdateStatus(Exports Export, StatusProcess StatusProcess)
        {

            using (orior_production_entities db = new orior_production_entities())
            {
                if (Export != null)
                {
                    Export.StatusProcess = StatusProcess.ToString().ToLower();
                    Export.UpdateProcess = DateTime.Now;
                    db.Entry(Export).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return Export;
        }


    }
}
