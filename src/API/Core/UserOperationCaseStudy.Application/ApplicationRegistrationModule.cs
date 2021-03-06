using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using Castle.DynamicProxy;
using MediatR.Extensions.Autofac.DependencyInjection;
using UserOperationCaseStudy.Common.Helpers.Interceptors;

namespace UserOperationCaseStudy.Application
{
    public class ApplicationRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterMediatR(assembly);
            builder.RegisterAutoMapper(assembly);
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
