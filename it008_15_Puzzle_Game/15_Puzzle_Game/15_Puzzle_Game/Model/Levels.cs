//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _15_Puzzle_Game.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Levels
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Levels()
        {
            this.LeaderBoards = new HashSet<LeaderBoards>();
        }
    
        public int level_id { get; set; }
        public string level_name { get; set; }
        public int grid_size { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LeaderBoards> LeaderBoards { get; set; }
    }
}