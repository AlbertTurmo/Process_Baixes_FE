using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace Sql_Data
{
    public enum StatusProcess
    {
        programmed,
        to_process,
        no_process,
        processing,
        processed,
        error_process
    }


    public class Sql_Data_Utils
    {
        public static StatusProcess GetStatusByBoolean(bool BooleanStatus)
        {

            StatusProcess status = StatusProcess.programmed;
            if(BooleanStatus)
            {
                status = StatusProcess.to_process;
            }
            else
            if(!BooleanStatus)
            {
                status = StatusProcess.no_process;

            }

            return status;
        }
    }


    public class SqlData_Bajas
    {
       



        //Create

        public static LogPBajasA Create(LogPBajasA LogPBajasA)
        {
            LogPBajasA NewLogPBajasA = new LogPBajasA();
            using (orior_production_entities db = new orior_production_entities())
            {
                NewLogPBajasA = db.LogPBajasA.Add(LogPBajasA);
                db.SaveChanges();
            }
            return NewLogPBajasA;
        }



        private static List<LogPBajasA> GetTickets()
        {
            List<LogPBajasA> ListLogs = new List<LogPBajasA>();

            using (orior_production_entities db = new orior_production_entities())
            {
                ListLogs = (from Element in db.LogPBajasA select Element).ToList();

            }


            return ListLogs;
        }


        public static List<LogPBajasA> GetTicketsByStatus(StatusProcess StatusProcess)
        {
            List<LogPBajasA> ListLogs = GetTickets();

            ListLogs = (from Element in ListLogs where (Element.StatusProcess == StatusProcess.ToString().ToLower()) select Element).ToList();

            return ListLogs;
        }

        public static List<LogPBajasA> GetTicketsByMail(string Mail)
        {
            List<LogPBajasA> ListLogs = GetTickets();

            ListLogs = (from Element in ListLogs where (Element.Mail == Mail.ToLower().Trim()) select Element).ToList();

            return ListLogs;
        }



        public static List<LogPBajasA> GetTicketsIMInSql()
        {
            List<LogPBajasA> ListLogs = GetTickets();

            ListLogs = (from Element in ListLogs where (Element.Ticket.Contains("IM")) orderby Element.Ticket descending select Element).ToList();

            return ListLogs;
        }


        public static LogPBajasA GetLastTicketsIMInSql()
        {
            LogPBajasA LastTicket;

            LastTicket = (from Element in GetTickets() where (Element.Ticket.Contains("IM")) orderby Element.Ticket descending select Element).FirstOrDefault();

            return LastTicket;
        }


        public static LogPBajasA UpdateLogPBajas(LogPBajasA LogPBajasA)
        {

            using (orior_production_entities db = new orior_production_entities())
            {
                if (LogPBajasA != null)
                {
                    LogPBajasA.ChangeStatusP = DateTime.Now;
                    db.Entry(LogPBajasA).State = EntityState.Modified;
                    db.SaveChanges();
                }

            }


            return LogPBajasA;
        }

        /// <summary>
        /// Get One Log
        /// </summary>
        /// <returns></returns>
        public static LogPBajasA GetLogPBajasAById(int Id)
        {
            LogPBajasA LogPBajasA = new LogPBajasA();

            using (orior_production_entities db = new orior_production_entities())
            {
                LogPBajasA = (from Element in db.LogPBajasA where Element.LogBajasId == Id select Element).FirstOrDefault();
            }


            return LogPBajasA;
        }

        public static LogPBajasA GetLogPBajasAByTicket(string Ticket)
        {
            LogPBajasA LogPBajasA = new LogPBajasA();

            using (orior_production_entities db = new orior_production_entities())
            {
                LogPBajasA = (from Element in db.LogPBajasA where Element.Ticket == Ticket select Element).FirstOrDefault();
            }


            return LogPBajasA;
        }

        // 03 Creacio Ad
        public static LogPBajasA UpdateStatus(LogPBajasA LogPBajasA, StatusProcess StatusProcess)
        {

            using (orior_production_entities db = new orior_production_entities())
            {
                if (LogPBajasA != null)
                {
                    LogPBajasA.StatusProcess = StatusProcess.ToString().ToLower();
                    LogPBajasA.ChangeStatusP = DateTime.Now;
                    db.Entry(LogPBajasA).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return LogPBajasA;
        }


    }
}