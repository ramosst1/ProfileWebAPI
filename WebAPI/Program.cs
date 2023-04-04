using System.Reflection;
using FluentValidation.AspNetCore;
using Repositories.Profiles;
using Profiles;
using Repositories.States;
using Services.Profiles;
using Services.States;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc();

//builder.Services.AddCors(options =>
//{

//    options.AddDefaultPolicy(
//        policy =>
//        {
////            policy.WithOrigins("http://localhost:4200")
//            policy.WithOrigins("*")
//                .AllowAnyOrigin()
//                .AllowAnyHeader()
//                .AllowAnyMethod();
//        });
//});

builder.Services.AddCors(policy => 
        policy.AddPolicy(name: "Mypolicy",
        policy =>
        {
            policy.AllowAnyOrigin();
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
        }
    )
    );

builder.Services.AddControllers()
                .AddFluentValidation(options =>
                {
                    // Validate child properties and root collection elements
                    options.ImplicitlyValidateChildProperties = true;
                    options.ImplicitlyValidateRootCollectionElements = true;

                    // Automatic registration of validators in assembly
                    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                });

builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IStatesServices, StatesServices>();
builder.Services.AddScoped<IStatesRepository, StatesRepository>();
builder.Services.AddScoped<IStatesDataSource, StatesJsonDataSource>();
builder.Services.AddScoped<IProfileDataSource, ProfileDataJsonSource>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Mypolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
