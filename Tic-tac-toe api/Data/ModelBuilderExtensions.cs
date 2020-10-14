﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tic_tac_toe_api.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder, IInitializer initializer)
        {
            initializer.Run(modelBuilder);
        }
        
    }
}
