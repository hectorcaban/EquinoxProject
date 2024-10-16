﻿using Equinox.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Equinox.Services.Api.Configurations
{
    public static class DatabaseConfig
    {
        public static WebApplicationBuilder AddDatabaseConfiguration(this WebApplicationBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.Services.AddDbContext<EquinoxContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddDbContext<EventStoreSqlContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            return builder;
        }

        public static WebApplicationBuilder AddSQLLiteConfiguration(this WebApplicationBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.Services.AddDbContext<EquinoxContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddEntityFrameworkSqlite().AddDbContext< EventStoreSqlContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            return builder;
        }
    }
}