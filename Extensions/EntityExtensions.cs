using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Document.Extension
{
    public static class EntityExtensions
    {
        public static void Reset(this DbContext context)
        {
            var entries = context.ChangeTracker
                .Entries()
                .Where(e => e.State != EntityState.Unchanged)
                .ToArray();

            foreach (var entry in entries) 
            { 
                switch (entry.State) 
                { 
                    case EntityState.Modified: 
                        entry.State = EntityState.Unchanged; 
                        break; 
                    case EntityState.Added: 
                        entry.State = EntityState.Detached; 
                        break; 
                    case EntityState.Deleted: 
                        entry.Reload(); 
                        break; 
                } 
            }
        }
    }
}