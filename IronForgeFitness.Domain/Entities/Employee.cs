using IronForgeFitness.Domain.Abstractions;

namespace IronForgeFitness.Domain.Entities
{
    public class Employee : Person
    {
        public Account? Account { get; set; }
        public decimal Salary { get; set; }
        public DateOnly DateOfHire { get; set; }
    }
}
