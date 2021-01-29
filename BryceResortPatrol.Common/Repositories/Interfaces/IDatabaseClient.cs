namespace BryceResortPatrol.Common.Repositories.Interfaces
{
    public interface IDatabaseClient
    {
        T SingleOrDefault<T>(string sql);
    }
}
