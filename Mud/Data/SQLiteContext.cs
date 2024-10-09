using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Diagnostics;


namespace Mud.Data
{
    public class SQLiteContext : DbContext 
    {
        public DbSet<Product> Products { get; set; }
        public String DbPath { get; private set; }
        public Boolean VerboseSQL { get; set; } = true;


        private void LogToDebug(String message)
        {
            if (VerboseSQL)
            {
                Debug.WriteLine(message);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                 .UseSqlite($"Data Source={DbPath}")
                 .EnableSensitiveDataLogging()
                 .LogTo(LogToDebug,
                 new[] { DbLoggerCategory.Database.Command.Name },
                    LogLevel.Information,
                    DbContextLoggerOptions.None
                    );
        }

        public SQLiteContext()
        {
            var path = FileSystem.AppDataDirectory;
            DbPath = Path.Combine(path, "mud.db");
            LogToDebug($"Database path: {DbPath}");
            LogToDebug($"ContextId: {this.ContextId}");
            if (!File.Exists(DbPath))
            {
                LogToDebug("Database does not exist. Creating it.");
                Database.EnsureCreated();
            }
            
        }
    }
}
