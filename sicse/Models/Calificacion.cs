//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sicse.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Calificacion
    {
        public int idCalificacion { get; set; }
        public string tipoCalifacion { get; set; }
    
        public virtual Item Item { get; set; }
    }
}
