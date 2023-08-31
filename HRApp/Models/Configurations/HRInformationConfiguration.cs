using HRApp.Models.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApp.Models.Configurations
{
    public class HRInformationConfiguration : EntityTypeConfiguration<HRInformation>
    {
        public HRInformationConfiguration()
        {
            ToTable("dbo.HRInformations");

            HasKey(x => x.ID);
        }
    }
}
