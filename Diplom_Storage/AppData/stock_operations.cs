//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Diplom_Storage.AppData
{
    using System;
    using System.Collections.Generic;
    
    public partial class stock_operations
    {
        public int ID_STOKOP { get; set; }
        public Nullable<System.DateTime> operation_date { get; set; }
        public int operation_type_ID { get; set; }
        public int product_id { get; set; }
        public Nullable<int> quantity { get; set; }
        public int user_id { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual stock_operation_types stock_operation_types { get; set; }
        public virtual users users { get; set; }
    }
}
