//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MailSenderGUI.data
{
    using System;
    using System.Collections.Generic;
    
    public partial class SchedulerTask
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SchedulerTask()
        {
            this.Emails = new HashSet<Email>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime Time { get; set; }
        public string Description { get; set; }
    
        public virtual MailingList MailingList { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Email> Emails { get; set; }
        public virtual Sender Sender { get; set; }
        public virtual Server Server { get; set; }
    }
}