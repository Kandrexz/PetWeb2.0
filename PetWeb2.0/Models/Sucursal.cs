//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PetWeb2._0.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sucursal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sucursal()
        {
            this.AspNetUsers = new HashSet<AspNetUsers>();
            this.AtencionVeterinaria = new HashSet<AtencionVeterinaria>();
        }
    
        public int Id { get; set; }
        public int Veterinaria { get; set; }
        public string Patente { get; set; }
        public string Correo { get; set; }
        public Nullable<int> Fono { get; set; }
        public string Direccion { get; set; }
        public string Region { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AtencionVeterinaria> AtencionVeterinaria { get; set; }
        public virtual Veterinaria Veterinaria1 { get; set; }
    }
}
