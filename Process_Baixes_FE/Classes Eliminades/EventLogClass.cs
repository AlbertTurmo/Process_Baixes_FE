//using System;
//using System.Diagnostics;

//namespace UnsubscribeR
//{
//    class EventLogClass
//    {
//        string LogName = "NewFail"; // Es una categoria de entradas de log especifica.
//        static string Sourcename; // Es la font que envia els logs, programa, aplicacions, etc....

//        public static void CreateEventLogSource()
//        {
//            Sourcename = "URequestWeb";

//            if (!EventLog.SourceExists(Sourcename))
//            {
//                EventLog.CreateEventSource(Sourcename, "Portal de Bajas");
//            }
//        }

//        public static void WriteLogStarting()
//        {
//            EventLog EventLog = new EventLog
//            {
//                Source = Sourcename
//            };
//            EventLog.WriteEntry($"{DateTime.Now} Starting Portal de Bajas ...", EventLogEntryType.Information);
//        }

//        public static void WriteLog(string log, EventLogEntryType eventLogEntryType = EventLogEntryType.Error)
//        {
//            EventLog EventLog = new EventLog();
//            EventLog.Source = Sourcename;
//            EventLog.WriteEntry($"{DateTime.Now} {log}...", eventLogEntryType);
//        }

//    }
//}
