//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MimAcher.Dominio
{
    using System;
    using System.Collections.Generic;
    
    public partial class MA_STATUS_RELACAO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MA_STATUS_RELACAO()
        {
            this.MA_PARTICIPANTE_APRENDER = new HashSet<MA_PARTICIPANTE_APRENDER>();
            this.MA_PARTICIPANTE_ENSINAR = new HashSet<MA_PARTICIPANTE_ENSINAR>();
            this.MA_PARTICIPANTE_HOBBIE = new HashSet<MA_PARTICIPANTE_HOBBIE>();
        }
    
        public int cod_s_relacao { get; set; }
        public string nome { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MA_PARTICIPANTE_APRENDER> MA_PARTICIPANTE_APRENDER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MA_PARTICIPANTE_ENSINAR> MA_PARTICIPANTE_ENSINAR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MA_PARTICIPANTE_HOBBIE> MA_PARTICIPANTE_HOBBIE { get; set; }
    }
}
