using Bemol.Channel.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bemol.Channel.Model
{
    public class BemolDigitalContext : DbContext
    {
        public BemolDigitalContext() : base("name=bemolConnectionString")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<BemolDigitalContext>());
        }

        public virtual DbSet<Usuario> Usuarios { get; set; }
    }
}
