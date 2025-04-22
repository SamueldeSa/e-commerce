using RO.DevTest.Application;
using RO.DevTest.Infrastructure.IoC;
using RO.DevTest.Persistence.IoC;
using RO.DevTest.Application.Contracts.Services;
using RO.DevTest.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using RO.DevTest.Application.Services;
using RO.DevTest.Application.Contracts.Persistence.Repositories;
using RO.DevTest.Infrastructure.Persistence.Repositories;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using RO.DevTest.Application.Contracts.Persistance.Repositories;

namespace RO.DevTest.WebApi;

public class Program {
    public static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<AppDbContext>(options 
            => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<IClienteService, ClienteService>();
        builder.Services.AddScoped<IClienteRepository, ClienteRepository>();  
        builder.Services.AddScoped<IProdutoService, ProdutoService>();
        builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
        

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        builder.Services.InjectPersistenceDependencies()
            .InjectInfrastructureDependencies();

        // Add Mediatr to program
        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(
                typeof(ApplicationLayer).Assembly,
                typeof(Program).Assembly
            );
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if(app.Environment.IsDevelopment()) {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
