using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sql_Data;

namespace Excute_Sql_Data
{
    class Program
    {
        static void Main(string[] args)
        {

            int nnn = SqlData_Exports.CountExportsByStatus(StatusProcess.processing);

            List<Empleado> ListEmpleado = SqlGetData.SearchEmployees("albert");




        }
    }
}
