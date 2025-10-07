using Microsoft.EntityFrameworkCore;
using Produto.Infrastructure.Data;

public static class DatabaseManagementService
{
    // Método de extensão para IApplicationBuilder
    public static void MigrationInitialisation(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            // Pega o AppDbContext do contêiner 
            var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

            if (context != null)
            {
                // Aplica qualquer migração pendente
                context.Database.Migrate();
            }
        }
    }
}