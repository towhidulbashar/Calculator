using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Domain
{
    public class CalculationHistory
    {
        public long Id { get; set; }
        public long ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public DateTime CalculationDate { get; set; }
        public string FirstNumber { get; set; }
        public string SecondNumber { get; set; }
        public string Result { get; set; }
    }
}
