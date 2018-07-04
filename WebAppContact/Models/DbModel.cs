namespace WebAppContact.Models
{
    using System.Data.Entity;
    

    public class DbModel : DbContext
    {
       
        public DbModel()
            : base("name=DbModel")
        {
        }

       

         public virtual DbSet<Contact> Contacts { get; set; }
    }

   
}