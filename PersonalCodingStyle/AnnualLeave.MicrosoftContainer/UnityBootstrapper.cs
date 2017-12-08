using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnualLeave.Logging;
using AnnualLeave.Logging.Core;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace AnnualLeave.MicrosoftContainer
{
    public static class UnityBootstrapper
    {
        private const string UnityConfigSectionName = "unity";
        private const string DefaultLoggerInstanceName = "DefaultLogger";

        static UnityBootstrapper()
        {
            Container = new UnityContainer();

            var section = (UnityConfigurationSection)ConfigurationManager.GetSection(UnityConfigSectionName);
            section.Configure(Container);

            Container.RegisterInstance<ILogger>(DefaultLoggerInstanceName, Logger.Instance());
        }

        public static UnityContainer Container { get; private set; }
    }
}