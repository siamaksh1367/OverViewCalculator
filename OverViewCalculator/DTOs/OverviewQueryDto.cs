using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OverViewCalculator.DTOs
{
    public class OverviewQueryDto
    {
        public double LoanAmount { get; set; }
        public short DurationOfLoanYear { get; set; }
        public double AnnualInterestRate { get; set; }
        public double AdministrationFee { get; set; }
    }
}
