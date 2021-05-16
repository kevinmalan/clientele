using System.Collections.Generic;

namespace Clientele.Core.Services.Interfaces
{
    public interface ICsvWriter<T>
    {
        string ToCsvBody(IEnumerable<T> items);

        string ToCsvheader(IEnumerable<T> items);
    }
}