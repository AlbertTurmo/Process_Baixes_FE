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
    
    public partial class LatLon
    {
        public int LatLonId { get; set; }
        public int GroupsId { get; set; }
        public int n { get; set; }
        public Nullable<int> ngs { get; set; }
        public Nullable<int> ns { get; set; }
        public string Seccio { get; set; }
        public string NomGrup { get; set; }
        public Nullable<double> lat { get; set; }
        public Nullable<double> lon { get; set; }
    
        public virtual Adreces Adreces { get; set; }
    }
}