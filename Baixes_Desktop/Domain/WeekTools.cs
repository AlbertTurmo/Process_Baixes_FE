using Baixes_Desktop;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Baixes_Desktop
{ 
    // Mon, Tue, Wed, Thur, Fri, Sat, Sun.
    class WeekTools
    {
        public enum DaysOfWeek
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }


        internal static List<Horari> ConvertDataTableToList(DataTable DataTable, int groupId)
        {
            List<Horari> data = new List<Horari>();

            foreach (DataRow DataRow in DataTable.Rows)
            {
                int index = 0;
                foreach (object HourObject in DataRow.ItemArray)
                {
                    DaysOfWeek DayWeek = (DaysOfWeek)index;
                    string Day = DayWeek.ToString();

                    if (!string.IsNullOrEmpty(HourObject.ToString()))
                    {
                        TimeSpan timespan = (TimeSpan)HourObject;

                        Horari horari = new Horari
                        {
                            GroupsId = groupId,
                            WeekDay = Day,
                            Hour = timespan

                        };

                        data.Add(horari);

                    }

                    index++;
                }
            }
            return data;
        }

        internal static DataTable GetDataTable(ICollection<Horari> Horaris)
        {

            PrintHoraris(Horaris);

            DataTable DataTable = CreateWeekDataTable();

            DataRow Start = DataTable.Rows.Add();
            DataRow End = DataTable.Rows.Add();


            foreach(Horari Horari in Horaris)
            {

                TimeSpan? TimeSpanSaved = GetTimeSpan(Start[Horari.WeekDay] );

                if(TimeSpanSaved!=null)
                {
                    if(TimeSpanSaved>Horari.Hour)
                    {
                        Start[Horari.WeekDay] = Horari.Hour;
                        End[Horari.WeekDay] = TimeSpanSaved;

                    }
                    else
                    if (TimeSpanSaved < Horari.Hour)
                    {
                        End[Horari.WeekDay] = Horari.Hour;

                    }
                }
                else
                {
                    Start[Horari.WeekDay] = Horari.Hour;
                }

            }

            return DataTable;
        }

        private static TimeSpan? GetTimeSpan(object Value)
        {
            TimeSpan? ts = null;

            string Hora = Value.ToString();

            if(!string.IsNullOrEmpty(Hora))
            {
                Console.WriteLine(Hora);

                ts = TimeSpan.Parse(Hora);
            }



            return ts;
            
        }

        private static void PrintHoraris(ICollection<Horari> Horaris)
        {
            Console.WriteLine("***** Horari *******");

            foreach(Horari Day in Horaris)
            {
                Console.WriteLine($"{Day.WeekDay} {Day.Hour}");
            }

            Console.WriteLine("***** ******* *******");


        }


        private static void RemoveDuplicates(ICollection<Horari> Horaris)
        {

            // ICollection<Horari> newhorari = new ICollection<Horari>();



        }

        internal static DataTable CreateWeekDataTable()
        {
            DataTable Week = new DataTable();
            Type DataType = typeof(TimeSpan);
            foreach (object Day in Enum.GetValues(typeof(DaysOfWeek)))
            {
                AddColumnToDataTable(Week, Day.ToString(), DataType);
            }
            return Week;

        }

        private static void AddColumnToDataTable(DataTable Week, string Name, Type DataType)
        {
            DataColumn DataColumn = GetColumn(Name, DataType);
            Week.Columns.Add(DataColumn);
        }

        private static DataColumn GetColumn(string CN, Type t)
        {
            return new DataColumn(CN)
            {
                DataType = t
            };

        }

        
    }
}
