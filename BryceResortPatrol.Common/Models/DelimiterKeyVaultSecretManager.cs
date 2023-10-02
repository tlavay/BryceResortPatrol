using System;
using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;

namespace BryceResortPatrol.Common.Models;
public sealed class DelimiterKeyVaultSecretManager : KeyVaultSecretManager
{
    private string prefix = string.Empty;

    public DelimiterKeyVaultSecretManager()
    {
    }

    public DelimiterKeyVaultSecretManager(string prefix)
    {
        this.prefix = (prefix.EndsWith('-') ? prefix : (prefix + "-"));
    }

    public override bool Load(SecretProperties secret)
    {
        return secret.Name.StartsWith(prefix);
    }

    public override string GetKey(KeyVaultSecret secret)
    {
        return secret.Name.Substring(prefix.Length).Replace("-", ConfigurationPath.KeyDelimiter, StringComparison.OrdinalIgnoreCase);
    }
}
