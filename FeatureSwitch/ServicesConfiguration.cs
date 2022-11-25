using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace FeatureSwitch
{
	public static class ServicesConfiguration
    {
        public static void AddScopedSwitch<T>(this IServiceCollection services, Action<FeatureManager<T>> a)
        {
            a(new FeatureManager<T>(services));
        }
    }

    public class FeatureManager<T>
    {
        IServiceCollection _services;
        public FeatureManager(IServiceCollection services)
        {
            _services=services;
        }

        public FeatureManager<T> RegisterVersion(string FeatureCode, string Version, Type theType)
        {
            if (FeatureSwitch.Enabled(FeatureCode, Version))
            {
                _services.AddScoped(typeof(T), theType);
            }

            return this;
        }
    }
}
