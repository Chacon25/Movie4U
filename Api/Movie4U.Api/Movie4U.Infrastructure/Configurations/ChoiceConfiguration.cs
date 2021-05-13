﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movie4U.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie4U.Infrastructure.Configurations
{
    class ChoiceConfiguration : IEntityTypeConfiguration<Choice>
    {
        public void Configure(EntityTypeBuilder<Choice> builder)
        {
            builder.HasKey(xx => xx.Id);
            builder.Property(xx => xx.Id).ValueGeneratedOnAdd();

            builder.Property(xx => xx.UserId).IsRequired();
           

        }
    }
}
