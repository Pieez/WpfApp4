//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp4
{
    using System;
    using System.Collections.Generic;
    
    public partial class AgentPriorityHistory
    {
        public int ID { get; set; }
        public Nullable<int> AgentID { get; set; }
        public Nullable<System.DateTime> ChangeDate { get; set; }
        public Nullable<int> PriorityValue { get; set; }
    
        public virtual Agent Agent { get; set; }
    }
}