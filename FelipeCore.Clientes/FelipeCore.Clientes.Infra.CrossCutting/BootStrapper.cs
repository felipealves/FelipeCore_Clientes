using FelipeCore.Clientes.Domain.Entities;
using FelipeCore.Clientes.Domain.Interfaces;
using FelipeCore.Clientes.Infra.Data.Repository;
using FelipeCore.Clientes.Service.Services;
using FelipeCore.Clientes.Service.Validators;
using FluentValidation;
using SimpleInjector;

namespace FelipeCore.Clientes.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            //Registrando as Implementações
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Singleton);
            container.Register<IClienteService, ClienteService>(Lifestyle.Singleton);
            container.Register<IValidator<Cliente>, ClienteValidator>(Lifestyle.Singleton);
        }
    }
}
