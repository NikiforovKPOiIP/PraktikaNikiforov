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
    
    public partial class Revision
    {
        public int ID_REVISION { get; set; }
        public int UserId { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual users users { get; set; }
    }
}
