﻿using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.EF.Configuration
{
    public class CategoryConfig
    {
        public CategoryConfig(EntityTypeBuilder<Category> entityBuilder)
        {
            entityBuilder.ToTable("Category");
            entityBuilder.Property(x => x.Id).IsRequired();
        }
    }
}
