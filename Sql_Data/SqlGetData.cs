using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sett = Sql_Data.Properties.Settings;


namespace Sql_Data
{

    public class Config
    {

        /* MODES */
        internal static string Mode = Sett.Default.Mode;
        internal static List<string> ValidModes = Sett.Default.ValidModes.Split(';').Select(E => E.Trim()).ToList();
    }

    public class SqlGetData
    {

        public static List<Empleado> GetEmployees()
        {
            List<Empleado> ListEmpleado = new List<Empleado>();

            using (orior_production_entities db = GetOrirorLogEntities())
            {
                ListEmpleado = (from Element in db.Empleado select Element).ToList();
            }
            return ListEmpleado;
        }


        public static List<Empleado> SearchEmployees(string Name)
        {
            List<Empleado> ListEmpleado = new List<Empleado>();

            using (orior_production_entities db = GetOrirorLogEntities())
            {
                ListEmpleado = (from Element in db.Empleado where (Element.nombreCompleto.Contains(Name)) && (Element.activo==true) select Element).ToList();
            }


            return ListEmpleado;
        }


        public static Empleado GetEmployeeByEmployeeId(int EmployeeId)
        {
            Empleado Empleado = new Empleado();

            using (orior_production_entities db = GetOrirorLogEntities())
            {
                Empleado = (from Element in db.Empleado where (Element.empleadoId == EmployeeId) select Element).FirstOrDefault();
            }

            return Empleado;
        }





        public static orior_production_entities GetOrirorLogEntities()
        {
            orior_production_entities OrirorlOGEntities = new orior_production_entities();

            string connectionString = OrirorlOGEntities.Database.Connection.ConnectionString;

            if (Config.Mode.ToLower() == "test")
            {
                OrirorlOGEntities.Database.Connection.ConnectionString = GetTestSqlConnection().ConnectionString;
            }
            return OrirorlOGEntities;
        }

        private static SqlConnection GetTestSqlConnection()
        {
            /* Test Connection String */
            // string TestStringConnection = @"data source=svsql02\orior;initial catalog = ORIOR_TEST;integrated security = True;MultipleActiveResultSets = True;App = EntityFramework";


            SqlConnectionStringBuilder Builder = new SqlConnectionStringBuilder()
            {
                DataSource = @"svsql02\orior",
                InitialCatalog = "orior_test",
                PersistSecurityInfo = true,
                IntegratedSecurity = true,
                MultipleActiveResultSets = true,
                ApplicationName = "EntityFramework",
                MaxPoolSize = 1000
            };

            SqlConnection Connection = new SqlConnection()
            {
                ConnectionString = Builder.ConnectionString
            };

            return Connection;
        }


    }
}
