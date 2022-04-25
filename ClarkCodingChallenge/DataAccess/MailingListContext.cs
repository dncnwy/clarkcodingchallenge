using ClarkCodingChallenge.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ClarkCodingChallenge.DataAccess
{
    public class MailingListContext : DbContext
    {
        public MailingListContext(DbContextOptions options) : base(options)
        {            
        }

        public DbSet<ContactModel> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactModel>();
        }              

        public IEnumerable<ContactModel> GetContacts()
        {
            return Contacts;
        }
    }
}
