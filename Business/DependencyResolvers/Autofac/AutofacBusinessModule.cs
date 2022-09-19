using System;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Interceptors;
using DataAccess.Concrete;
using DataAccess.Abstract;
using Core.Utilities.Security.JWT;
using Core.Utilities.Helpers.FileHelper;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance();
            builder.RegisterType<NewsRepository>().As<INewsRepository>().SingleInstance();
            builder.RegisterType<NewsImageRepository>().As<INewsImageRepository>().SingleInstance();
            builder.RegisterType<GenreRepository>().As<IGenreRepository>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            builder.RegisterType<FileHeplerManager>().As<IFileHelper>().SingleInstance();

            builder.RegisterType<NewsDbContext>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();


        }
    }
}
