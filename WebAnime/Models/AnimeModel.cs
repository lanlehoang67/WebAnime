using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAnime.Models
{
    public class AnimeModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AnimeModel()
        {
            this.Coes = new HashSet<Co>();
            this.ChuDes = new HashSet<ChuDe>();
        }

        public int MaPhim { get; set; }
        public string TenPhim { get; set; }
        public string AnhBia { get; set; }
        public string MoTa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Co> Coes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChuDe> ChuDes { get; set; }
    }
}