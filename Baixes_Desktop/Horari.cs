//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Baixes_Desktop
{
    using System;
    using System.Collections.Generic;
    
    public partial class Horari
    {
        public int HorariId { get; set; }
        public int GroupsId { get; set; }
        public string WeekDay { get; set; }
        public Nullable<System.TimeSpan> Hour { get; set; }
    
        public virtual Groups Groups { get; set; }
    }
}