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
    
    public partial class ExamenClinico
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExamenClinico()
        {
            this.AtencionVeterinaria = new HashSet<AtencionVeterinaria>();
        }
    
        public int Id { get; set; }
        public string Fecha { get; set; }
        public string MotivoConsulta { get; set; }
        public int FrecuenciaCardiaca { get; set; }
        public double TemperaturaPaciente { get; set; }
        public string Anamnesis { get; set; }
        public string Diagnostico { get; set; }
        public string Tratamiento { get; set; }
        public string Tipo { get; set; }
        public Nullable<int> IdMascota { get; set; }
        public Nullable<int> Microchip { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AtencionVeterinaria> AtencionVeterinaria { get; set; }
        public virtual Mascota Mascota { get; set; }
    }
}
