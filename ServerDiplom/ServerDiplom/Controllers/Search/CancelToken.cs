using System.Threading;

namespace ServerDiplom.Controllers.Search
{
    public class CancelToken
    {
        public static CancellationTokenSource CancelTokenSourceR { get; set; }
        public static CancellationTokenSource CancelTokenSourceGS { get; set; }
    }
}
