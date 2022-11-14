using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace BryceResortPatrol.Common.Extensions;
internal static class DependencyInjectionExtensions
{
    private const string ConfigurationCheckMessage = @"If this is a configuration object please check that the config provider contains the object.";
    public static T GetAndValidateService<T>(this IServiceProvider serviceProvider)
    {
        var type = typeof(T);
        var service = serviceProvider.GetService<T>();
        if (service == null)
        {
            throw new ConfigurationErrorsException(
                $"The service for type {typeof(T).Name} was not configured correctly and did not return. " +
                $"Check that the service was correctly added to the ConfigExtension.");
        }

        return service;
    }

    public static TProperty GetAndValidateServiceProperty<TService, TProperty>(this IServiceProvider serviceProvider)
    {
        var service = serviceProvider.GetAndValidateService<TService>();
        if (service == null)
        {
            throw new ConfigurationErrorsException($"The service named {typeof(TService)} was not provided. {ConfigurationCheckMessage}");
        }

        var property = service.GetType().GetProperties().Single(prop => prop.PropertyType == typeof(TProperty));
        if (property == null)
        {
            throw new ConfigurationErrorsException($"The service named {typeof(TService)} did not have a property named {typeof(TProperty)}. {ConfigurationCheckMessage}");
        }

        var propertyValue = property.GetValue(service, null);
        if (propertyValue == null)
        {
            throw new ConfigurationErrorsException($"The service named: {typeof(TService)} with property named: {typeof(TProperty).Name} did not contain a value. {ConfigurationCheckMessage}");
        }

        return (TProperty)propertyValue;
    }
}
