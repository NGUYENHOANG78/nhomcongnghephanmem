//------------------------------------------------------------------------------

//------------------------------------------------------------------------------

namespace DAO
{
    using System;
    using System.Collections.Generic;
    
    public partial class nhomsanpham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public nhomsanpham()
        {
            this.loaisanphams = new HashSet<loaisanpham>();
            this.thuonghieux = new HashSet<thuonghieu>();
        }
    
        public string id_nhom { get; set; }
        public string tennhom { get; set; }
        public System.DateTime ngaytao { get; set; }
        public System.DateTime ngaycapnhat { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<loaisanpham> loaisanphams { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<thuonghieu> thuonghieux { get; set; }
    }
}
