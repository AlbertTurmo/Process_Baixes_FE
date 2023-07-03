//using Sql_Data;
//using System;
//using System.Data;
//using System.Web;

//using System.Web.UI.WebControls;

//namespace UnsubscribeR
//{
//    public static class UUser
//    {
//        public static int LogBajasId { get; set; }
//        public static string Ticket { get; set; }
//        public static DateTime StartProcess { get; set; }
//        public static string StatusTicket { get; set; }
//        public static string Mail { get; set; }
//        public static string Dni { get; set; }
//        public static string ResponsableTicket { get; set; }
//        public static string ResponsableAd { get; set; }
//        public static string StatusProcess { get; set; }
//        public static DateTime ChangeStatusProcess { get; set; }
//        public static string WindowsId { get; set; }
//        public static string EmployeeID { get; set; }
//        public static string Name { get; set; }
//        public static string Company { get; set; }
//        public static string Department { get; set; }
//        public static string Title { get; set; }
//        public static string Observations { get; set; }
//        public static DateTime Date { get; set; }
//        public static TimeSpan Hour { get; set; }
//        public static string SocietyN { get; set; }
//        public static string DelegationN { get; set; }
//        public static string DateHour { get; set; }
//        public static bool EntrevistaSalida { get; set; }

//        public static class Condition
//        {
//            public static bool Scheduled { get; set; }     // llista de programats
//            public static string Petitioner { get; set; }
//            public static string Now { get; set; }

//        }


//        //public static void SetUserFromRow(DataRow row)
//        //{
//        //    UUser.Clear();
//        //    UUser.LogBajasId = GetDataFromRowAsInt(row, "LogBajasId");
//        //    UUser.Ticket = GetRowDataAsString(row, "Ticket");
//        //    UUser.StartProcess = GetDataFromRowAsDateTime(row, "StartProcess");
//        //    UUser.StatusTicket = GetRowDataAsString(row, "StatusTicket");
//        //    UUser.Name = GetRowDataAsString(row, "Name");
//        //    UUser.Mail = GetRowDataAsString(row, "Mail");
//        //    UUser.Dni = GetRowDataAsString(row, "Nif");
//        //    UUser.ResponsableTicket = GetRowDataAsString(row, "ResponsableTicket");
//        //    UUser.ResponsableAd = GetRowDataAsString(row, "ResponsableAd");
//        //    UUser.StatusProcess = GetRowDataAsString(row, "StatusProcess");
//        //    UUser.ChangeStatusProcess = GetDataFromRowAsDateTime(row, "ChangeStatusP");
//        //    UUser.WindowsId = GetRowDataAsString(row, "windowsID");
//        //    //User.EmployeeID = GetRowData(row, "employeeID");
//        //    //User.Company = GetRowData(row, "company");
//        //    //User.Department = GetRowData(row, "department");
//        //    //User.Title = GetRowData(row, "title");
//        //    UUser.Condition.Petitioner = Search.SessionUser;
//        //    //User.Observations = GetRowData(row, "observations");
//        //    //User.SocietyN = GetRowData(row, "societyN");
//        //    //User.DelegationN = GetRowData(row, "delegationN");
//        //}

//        //public static void SetUserFromRow_New(DataRow row)
//        //{
//        //    UUser.Clear();
//        //    UUser.LogBajasId = GetDataFromRowAsInt(row, "LogBajasId");
//        //    UUser.Ticket = GetRowDataAsString(row, "Ticket");
//        //    UUser.StartProcess = GetDataFromRowAsDateTime(row, "StartProcess");
//        //    UUser.StatusTicket = GetRowDataAsString(row, "StatusTicket");
//        //    UUser.Name = GetRowDataAsString(row, "Name");
//        //    UUser.Mail = GetRowDataAsString(row, "Mail");
//        //    UUser.Dni = GetRowDataAsString(row, "Nif");
//        //    UUser.ResponsableTicket = GetRowDataAsString(row, "ResponsableTicket");
//        //    UUser.ResponsableAd = GetRowDataAsString(row, "ResponsableAd");
//        //    UUser.StatusProcess = GetRowDataAsString(row, "StatusProcess");
//        //    UUser.ChangeStatusProcess = GetDataFromRowAsDateTime(row, "ChangeStatusP");
//        //    UUser.WindowsId = GetRowDataAsString(row, "windowsID");
//        //    //User.EmployeeID = GetRowData(row, "employeeID");
//        //    //User.Company = GetRowData(row, "company");
//        //    //User.Department = GetRowData(row, "department");
//        //    //User.Title = GetRowData(row, "title");
//        //    UUser.Condition.Petitioner = Search.SessionUser;
//        //    //User.Observations = GetRowData(row, "observations");
//        //    //User.SocietyN = GetRowData(row, "societyN");
//        //    //User.DelegationN = GetRowData(row, "delegationN");
//        //}



//        //internal static void SetUserFromEmployee(Empleado Empleado)
//        //{
//        //    UUser.Clear();
//        //    string NewTicket = GetNextIMTicket();

//        //    string Mail = string.Empty;
//        //    string MailResposible = string.Empty;

//        //    if (!string.IsNullOrEmpty(Empleado.usuarioWindows))
//        //    {
//        //        Mail = ConnectAd.LookForMail(Empleado.usuarioWindows);
//        //        MailResposible = ConnectAd.LookForManager(Empleado.usuarioWindows);

//        //    }


//        //    UUser.LogBajasId = 0;
//        //    UUser.Ticket = NewTicket; // s'ha de consulta sql per posar ticket IM-(+1)
//        //    UUser.StartProcess = DateTime.Now;
//        //    UUser.StatusTicket = "En Proceso";
//        //    UUser.EmployeeID = Empleado.empleadoId.ToString();
//        //    UUser.Name = CommonTools.Text.ToTitleCase(Empleado.nombreCompleto);
//        //    UUser.Mail = (!string.IsNullOrEmpty(Mail)) ? Mail : Empleado.email.ToLower();
//        //    UUser.Dni = Empleado.dni;
//        //    UUser.ResponsableTicket = string.Empty;
//        //    UUser.ResponsableAd = (!string.IsNullOrEmpty(MailResposible)) ? MailResposible : string.Empty;
//        //    UUser.ChangeStatusProcess = DateTime.Now;
//        //    UUser.WindowsId = Empleado.usuarioWindows.ToLower();
//        //    UUser.Company = Empleado.divisionPersonalDescripcion;
//        //    UUser.Department = Empleado.subDivisionPersonalDescripcion;
//        //    UUser.Title = Empleado.posicionDescripcion;
//        //    UUser.StatusProcess = Sql_Data.StatusProcess.programmed.ToString().ToLower();
//        //    UUser.Condition.Petitioner = Search.SessionUser;
//        //}

//        //public static string GetNextIMTicket()
//        //{
//        //    LogPBajasA LastIMLogPBajasA = SqlData_Bajas.GetLastTicketsIMInSql();

//        //    string NewTicket = $"IM-{int.Parse(LastIMLogPBajasA.Ticket.Substring(3)) + 1:0000}";
//        //    return NewTicket;
//        //}

//        //internal static void SetUserFromRowReprogramming(LogPBajasA LogPBajasA)
//        //{

//        //    UUser.Clear();

//        //    UUser.LogBajasId = LogPBajasA.LogBajasId;
//        //    UUser.Ticket = LogPBajasA.Ticket;
//        //    UUser.StartProcess = LogPBajasA.StartProcess.Value;
//        //    UUser.StatusTicket = LogPBajasA.StatusTicket;
//        //    UUser.Name = LogPBajasA.Name;
//        //    UUser.Mail = LogPBajasA.Mail;
//        //    UUser.Dni = LogPBajasA.Nif;
//        //    UUser.ResponsableTicket = LogPBajasA.ResponsableTicket;
//        //    UUser.ResponsableAd = LogPBajasA.ResponsableAd;
//        //    UUser.StatusProcess = LogPBajasA.StatusProcess;
//        //    UUser.ChangeStatusProcess = LogPBajasA.ChangeStatusP.Value;
//        //    UUser.WindowsId = LogPBajasA.WindowsId;

            

//        //    // User.Title = GetRowData(DataRow, "cargo");
//        //    UUser.Condition.Petitioner = Search.SessionUser;
//        //}

//        //internal static void SetUserFromRowReprogramming(GridViewRow GridViewRow)
//        //{

//        //    UUser.Clear();

//        //    UUser.LogBajasId = int.Parse(GetCellByName(GridViewRow, "Id").Text);
//        //    UUser.Ticket = GetCellByName(GridViewRow, "Ticket").Text;
//        //    UUser.StartProcess = DateTime.Parse(GetCellByName(GridViewRow, "StartProcess").Text);
//        //    UUser.StatusTicket = GetCellByName(GridViewRow, "StatusTicket").Text;
//        //    UUser.Name = GetCellByName(GridViewRow, "Name").Text;
//        //    UUser.Mail = GetCellByName(GridViewRow, "Mail").Text;
//        //    UUser.Dni = GetCellByName(GridViewRow, "Nif").Text;
//        //    UUser.ResponsableTicket = GetCellByName(GridViewRow, "ResponsableTicket").Text;
//        //    UUser.ResponsableAd = GetCellByName(GridViewRow, "ResponsableAd").Text;
//        //    UUser.StatusProcess = GetCellByName(GridViewRow, "StatusProcess").Text;
//        //    UUser.ChangeStatusProcess = DateTime.Parse(GetCellByName(GridViewRow, "ChangeStatusP").Text);
//        //    UUser.WindowsId = GetCellByName(GridViewRow, "windowsID").Text;
          
//        //    // User.Title = GetRowData(DataRow, "cargo");
//        //    UUser.Condition.Petitioner = Search.SessionUser;
//        //}



//        //public static void EncryptUser()
//        //{
//        //    WindowsId = EncryptionTools.encryptStToSt(WindowsId);
//        //    EmployeeID = EncryptionTools.encryptStToSt(EmployeeID);
//        //    Dni = EncryptionTools.encryptStToSt(Dni);
//        //    Name = EncryptionTools.encryptStToSt(Name);
//        //    Company = EncryptionTools.encryptStToSt(Company);
//        //    Department = EncryptionTools.encryptStToSt(Department);
//        //    Title = EncryptionTools.encryptStToSt(Title);
//        //    Observations = EncryptionTools.encryptStToSt(Observations);
//        //    Condition.Petitioner = EncryptionTools.encryptStToSt(Condition.Petitioner);
//        //    SocietyN = EncryptionTools.encryptStToSt(SocietyN);
//        //    DelegationN = EncryptionTools.encryptStToSt(DelegationN);

//        //    Condition.Now = EncryptionTools.encryptStToSt(Condition.Now);
//        //    DateHour = EncryptionTools.encryptStToSt(DateHour);



//        //}

//        //public static void SetUserFromRow(GridViewRow GridViewRow)
//        //{
            

//        //    UUser.WindowsId = GridViewRow.Cells[0].Text;
//        //    UUser.EmployeeID = GridViewRow.Cells[1].Text;
//        //    UUser.Dni = GridViewRow.Cells[2].Text;
//        //    UUser.Name = GridViewRow.Cells[3].Text;
//        //    UUser.Company = GridViewRow.Cells[4].Text;
//        //    UUser.Department = GridViewRow.Cells[5].Text;
//        //    UUser.Title = GridViewRow.Cells[6].Text;

//        //    UUser.SocietyN = GridViewRow.Cells[7].Text;
//        //    UUser.DelegationN = GridViewRow.Cells[8].Text;

//        //}

//        //public static void SetUserFromRow_old(GridViewRow GridViewRow)
//        //{
//        //    foreach (DataControlFieldCell cell in GridViewRow.Cells)
//        //    {
//        //        System.Diagnostics.Debug.WriteLine("Text: " + cell.Text);

//        //        Console.WriteLine(cell);

//        //    }

//        //    UUser.WindowsId = GridViewRow.Cells[0].Text;
//        //    UUser.EmployeeID = GridViewRow.Cells[1].Text;
//        //    UUser.Dni = GridViewRow.Cells[2].Text;
//        //    UUser.Name = GridViewRow.Cells[3].Text;
//        //    UUser.Company = GridViewRow.Cells[4].Text;
//        //    UUser.Department = GridViewRow.Cells[5].Text;
//        //    UUser.Title = GridViewRow.Cells[6].Text;

//        //    UUser.SocietyN = GridViewRow.Cells[7].Text;
//        //    UUser.DelegationN = GridViewRow.Cells[8].Text;

//        //}





//        //private static string GetRowData(DataRow row, int v)
//        //{

//        //    string st = HttpUtility.HtmlDecode(row[v].ToString());
//        //    return st;
//        //}


        


//        //public static DataControlFieldCell GetCellByName(GridViewRow GridViewRow, string CellName)
//        //{
//        //    DataControlFieldCell RetunedCell = null;


//        //    foreach (DataControlFieldCell Cell in GridViewRow.Cells)
//        //    {
//        //        if (Cell.ContainingField.ToString() == CellName)
//        //        {
//        //            RetunedCell = Cell;
//        //        }
//        //    }
//        //    return RetunedCell;
//        //}


//        //private static string GetRowDataAsString(DataRow row, string column)
//        //{
//        //    if (!string.IsNullOrEmpty(row[column].ToString()))
//        //    {
//        //        string st = row[column].ToString();
//        //        return st;

//        //    }
//        //    else
//        //    {
//        //        return string.Empty;
//        //    }



//        //}


       


//        //private static int GetDataFromRowAsInt(DataRow row, string Column)
//        //{
//        //    int n = 0;

//        //    if (!string.IsNullOrEmpty(row[Column].ToString()))
//        //    {
//        //        string st = row[Column].ToString();

//        //        bool CanParse = int.TryParse(st, out int nn);

//        //        if(CanParse)
//        //        {
//        //            n = nn;
//        //        }
//        //    }
            
//        //    return n;
//        //}

//        //private static DateTime GetDataFromRowAsDateTime(DataRow row, string Column)
//        //{
//        //    DateTime d = DateTime.Now;

//        //    if (!string.IsNullOrEmpty(row[Column].ToString()))
//        //    {
//        //        string st = row[Column].ToString();

//        //        bool CanParse = DateTime.TryParse(st, out DateTime dd);

//        //        if (CanParse)
//        //        {
//        //            d = dd;
//        //        }
//        //    }

//        //    return d;
//        //}



//        //private static void Clear()
//        //{

//        //    LogBajasId = 0;
//        //    Ticket = string.Empty;
//        //    StartProcess = new DateTime(0);
//        //    StatusTicket = string.Empty;
//        //    Mail = string.Empty;
//        //    Dni = string.Empty;
//        //    ResponsableTicket = string.Empty;
//        //    ResponsableAd = string.Empty;
//        //    StatusProcess = string.Empty;
//        //    ChangeStatusProcess = new DateTime(0L);
//        //    EmployeeID = string.Empty;
//        //    Name = string.Empty;
//        //    WindowsId = string.Empty;
//        //    Dni = string.Empty;
//        //    Company = string.Empty;
//        //    Department = string.Empty;
//        //    Title = string.Empty;
//        //    Observations = string.Empty;
//        //    Date = new DateTime(0);
//        //    Hour = new TimeSpan(0);
//        //    SocietyN = string.Empty;
//        //    DelegationN = string.Empty;
//        //    EntrevistaSalida = false;

//        //    Condition.Petitioner = string.Empty;

//        //}

       
//    }
//}