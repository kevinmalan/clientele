namespace Clientele.Core.Services.Interfaces
{
    public interface ISqlQueryProvider
    {
        string GetQueryByName(string queryName);
    }
}