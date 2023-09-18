using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;

namespace CommonTools
{
    public static class GetTranslateExports
    {
       
            public static Dictionary<string, string> ExportsTranslate = new Dictionary<string, string>()
            {
                {"programed", "Programado"},
                {"to_process", "Procesar"},
                {"processing", "Procesado"},
                {"no_process", "No Procesar"},
                {"processed", "Procesado"},
                {"in_progress", "En Progreso"},
                {"waiting", "Esperando"},
                {"started", "Iniciado"},
                {"completed", "Completado"},
                {"downloaded", "Descargado"},
                {"uploaded", "Subido"},
                {"transfered", "Transferido"},
                {"transfering", "Transfiriendo"},
                {"error_downloading", "Error Descargando"},
                {"error_uploading", "Error Subiendo"},
                {"guser_deleted", "Usuario Google Eliminado Correctamente"},
                {"uploading", "Subiendo"},
                {"to_transfer", "Transferir"},
                {"no_transfer", "No Transferir"},
                {"error_tranfering", "Error Transfiriendo"},
                {"zipping", "Empaquetando"},
                {"aduser_deleted", "Usuario AD Eliminado Correctamente"},
                {"alias_created", "Alias Creado"},
                {"error_creating_export_log", "Error Creando Export Log"},
                {"error_creating_alias", "Error Creando Alias"},
                {string.Empty, "NO ESTABLECIDO" }
            };
    }

    public class Text
    {
        public static string ToTitleCase(string Text)
        {
            Text = Text.ToLower();
            TextInfo TextInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
            string Result = TextInfo.ToTitleCase(Text);
            return Result;
        }

    }


    public class Check
    {
        public static bool GetIfCorrectFormatMail(string Email)
        {
            bool CorrectFormat;
            Regex Regex = new Regex(@"^([\w\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            Match Match = Regex.Match(Email);

            if (Match.Success)
            {
                CorrectFormat = true;
            }
            else
            {
                CorrectFormat = false;
            }

            return CorrectFormat;
        }


        public static bool HasNumber(string input)
        {
            bool result = input.Where(x => Char.IsDigit(x)).Any();
            return result;
        }



    }
}