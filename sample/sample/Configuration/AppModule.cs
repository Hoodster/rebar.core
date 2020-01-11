using Autofac;
using Rebar.Core;
using static System.Reflection.Assembly;

namespace sample.Configuration
{
    public class AppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var executingAssembly = GetExecutingAssembly();

            builder.RegisterCommandHandlers(executingAssembly);
            builder.RegisterQueryHandlers(executingAssembly);

            //You can also register both commands and queries using
            //    builder.RegisterAll();

            builder.AddRebar(); //Used to configure things such as dispatchers. Required. 
        }
    }
}
