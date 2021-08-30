using System.Collections.Generic;

namespace ClientDiplom.Data
{
    public class ResultAlgorithm
    {
        public string AlgorithmName { get; set; }
        public List<int> ListOfFoundMatches { get; set; }
        public string Timer { get; set; }
        public long Tick { get; set; }
        public long NumberOfOperations { get; set; }
    }
}
