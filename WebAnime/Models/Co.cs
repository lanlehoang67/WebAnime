//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAnime.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Co
    {
        public int STT { get; set; }
        public Nullable<int> MaPhim { get; set; }
        public Nullable<int> Tap { get; set; }
        public string Link { get; set; }
    
        public virtual Anime Anime { get; set; }
    }
}