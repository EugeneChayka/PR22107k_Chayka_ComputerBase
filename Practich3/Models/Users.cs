//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Practich3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        public int IdEmp { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    
        public virtual Employeey Employeey { get; set; }
    }
}
