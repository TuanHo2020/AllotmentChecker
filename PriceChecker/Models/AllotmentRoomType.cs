//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PriceChecker.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AllotmentRoomType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AllotmentRoomType()
        {
            this.AllotmentRecords1 = new HashSet<AllotmentRecord>();
        }
    
        public int RecordId { get; set; }
        public string RoomName { get; set; }
        public int HotelId { get; set; }
        public int DefaultAllotment { get; set; }
        public bool IgnoreThisRoomType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AllotmentRecord> AllotmentRecords1 { get; set; }
    }
}