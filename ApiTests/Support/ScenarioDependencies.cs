namespace ApiTests.DependencyInjection
{
    using ApiTests.Actions;
    using ApiTests.Clients;
    using ApiTests.ClientsConfigurations;
    using ApiTests.Controllers;
    using ApiTests.Models;
    using ApiTests.Models.Configs;
    using ApiTests.Models.Configs.ServicesConfiguration;
    using ApiTests.Tests.Steps;
    using ApiTests.Utilities.Configurations;
    using Autofac;
    using SpecFlow.Autofac;

    public class ScenarioDependencies
    {
        [ScenarioDependencies]
        public static ContainerBuilder CreateContainerBuilder()
        {
            var builder = new ContainerBuilder();

            // client
            builder.RegisterType<Client>().As<Client>();
            builder.RegisterType<Client>().As<IClient>();

            // controllers
            builder.RegisterType<Controller>();
            builder.RegisterType<WeatherController>().As<IController>();
            builder.RegisterType<WeatherController>().As<WeatherController>();
            builder.RegisterType<PhotoController>().As<IController>();
            builder.RegisterType<PhotoController>().As<PhotoController>();

            // actions
            builder.RegisterType<PhotoActions>();
            builder.RegisterType<WeatherActions>();

            // steps
            builder.RegisterType<GenericSteps>();
            builder.RegisterType<PhotoAPISteps>();
            builder.RegisterType<WeatherAPISteps>();

            // classes responsible for confuguration
            builder.RegisterType<Photo>();
            builder.RegisterType<TestConfiguration>();
            builder.RegisterType<WeatherService>();
            builder.RegisterType<ServiceConfiguration>();
            builder.RegisterType<PlaceholderService>();

            return builder;
        }
    }
}
