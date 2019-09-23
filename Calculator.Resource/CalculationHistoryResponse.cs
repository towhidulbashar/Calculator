using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Resource
{
    public class CalculationHistoryResponse
    {
        public long Id { get; set; }
        public long ApplicationUserId { get; set; }
        public string UserName { get; set; }
        public DateTime CalculationDate { get; set; }
        public string FirstNumber { get; set; }
        public string SecondNumber { get; set; }
        public string Result { get; set; }
    }
}
