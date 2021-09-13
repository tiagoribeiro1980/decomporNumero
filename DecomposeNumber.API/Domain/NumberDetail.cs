using System.Collections.Generic;

namespace DecomposeNumber.API.Domain
{
    public class NumberDetail
    {
        public int Number { get; set; }
        public List<int> DivisorNumbers { get; set; }
        public List<int> PrimeNumbers { get; set; }
    }
}