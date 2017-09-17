
namespace Web.Utilities
{
    using System.Configuration;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;

    public static class DependencyFactory
    {
        private const string UnitySection = "Unity";
        public static IUnityContainer Container { get; }

        static DependencyFactory()
        {
            var container = new UnityContainer();

            var section = (UnityConfigurationSection)ConfigurationManager.GetSection(UnitySection);
            section?.Configure(container);
            Container = container;
        }

        public static T Resolve<T>()
        {
            var ret = default(T);

            if (Container.IsRegistered(typeof(T)))
            {
                ret = Container.Resolve<T>();
            }

            return ret;
        }
    }
}