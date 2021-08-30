using ServerDiplom.BusinessLogic;

namespace ServerDiplom.Controllers.Search.Data
{
    public class ResultAlgorithmsData
    {
        public ResultAlgorithm BruteForce { get; set; } = new ResultAlgorithm();
        public ResultAlgorithm RK { get; set; } = new ResultAlgorithm();
        public ResultAlgorithm KMPWithPFunc { get; set; } = new ResultAlgorithm();
        public ResultAlgorithm AlgZ { get; set; } = new ResultAlgorithm();
        public ResultAlgorithm BMH { get; set; } = new ResultAlgorithm();
    }
}
