//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sql_Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Empleado
    {
        public int empleadoId { get; set; }
        public string sociedadId { get; set; }
        public string usuarioWindows { get; set; }
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string unidadOrganizativaId { get; set; }
        public string nombreCompleto { get; set; }
        public string email { get; set; }
        public string dni { get; set; }
        public string telefonoPersonal { get; set; }
        public string telefonoEmpresa { get; set; }
        public string controlGastoTfo { get; set; }
        public Nullable<System.DateTime> ultimaModificacion { get; set; }
        public Nullable<bool> activo { get; set; }
        public string cebe { get; set; }
        public string cebeDescripcion { get; set; }
        public string posicion { get; set; }
        public string posicionDescripcion { get; set; }
        public string divisionPersonal { get; set; }
        public string divisionPersonalDescripcion { get; set; }
        public string subDivisionPersonal { get; set; }
        public string subDivisionPersonalDescripcion { get; set; }
        public string alias { get; set; }
        public string fechaNacimiento { get; set; }
        public string paisTrabajo { get; set; }
        public string paisTrabajoDescripcion { get; set; }
        public string telefonoContacto { get; set; }
        public string telefonoContactoDescripcion { get; set; }
        public string emailPrivado { get; set; }
        public string usuarioSapActivo { get; set; }
        public string fechaAlta { get; set; }
        public string unidadOrganizativaDescripcion { get; set; }
    
        public virtual Empleado Empleado1 { get; set; }
        public virtual Empleado Empleado2 { get; set; }
    }
}
