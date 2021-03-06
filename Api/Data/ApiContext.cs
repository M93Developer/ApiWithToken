﻿using Api.Model;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data
{
    public class ApiContext : DbContext
    {
        //cambiar por línea conectada para usar conección de 
        //public ApiContext() : base("EvolutionDb")
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }
        public DbSet<ApiUser> ApiUser { get; set; }
    }
}
