using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SingalrChat.Models
{
    public partial class ChatContext : DbContext
    {
        public ChatContext()
            : base("name=ChatContext3")
        {
        }

        public virtual DbSet<message> messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
