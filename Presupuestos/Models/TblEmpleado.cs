//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Presupuestos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblEmpleado
    {
        public TblEmpleado()
        {
            this.TblProyectosEmpleados = new HashSet<TblProyectosEmpleado>();
        }
    
        public int IDEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
    
        public virtual ICollection<TblProyectosEmpleado> TblProyectosEmpleados { get; set; }
    }
}