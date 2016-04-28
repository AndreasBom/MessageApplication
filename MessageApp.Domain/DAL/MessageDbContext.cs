using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageApp.Domain.DAL.Entities;

namespace MessageApp.Domain.DAL
{
    /// <summary>
    /// Database context
    /// </summary>
    public class MessageDbContext : DbContext
    {
        public MessageDbContext()
            :base("name=MessageAppConnectionString")
        {
            //Empty
        }

        public virtual DbSet<Entities.Message> Messages { get; set; }
    }
}
