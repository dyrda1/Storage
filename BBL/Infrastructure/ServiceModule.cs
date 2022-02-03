using BBL.Services.Classes;
using BBL.Services.Interfaces;
using Ninject.Modules;

namespace BBL.Infrastructure
{
    class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAuthenticateService>().To<AuthenticateService>();
        }
    }
}
