using HRApp.Models.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApp.Models.Configurations
{
    public class PositionConfiguration : EntityTypeConfiguration<Position>
    {
        public PositionConfiguration()
        {
            ToTable("dbo.Positions");

            Property(x => x.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
