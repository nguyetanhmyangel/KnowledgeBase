//using FluentValidation;
//using MediatR;
//using Microsoft.Extensions.DependencyInjection;
//using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Config Add AutoMapper,FluentValidation and MediatR / Application project
        /// </summary>
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            // services.AddAutoMapper(Assembly.GetExecutingAssembly());
            // services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}