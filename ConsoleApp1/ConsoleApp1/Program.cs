using System;

class Employee
{
    public string Name { get; }
    public string Position { get; }
    private readonly ISalaryCalculator _salaryCalculator;

    public Employee(string name, string position, ISalaryCalculator salaryCalculator)
    {
        Name = name;
        Position = position;
        _salaryCalculator = salaryCalculator;
    }

    public double CalculateSalary()
    {
        return _salaryCalculator.CalculateSalary();
    }
}

interface ISalaryCalculator
{
    double CalculateSalary();
}

// BRIDGE
class HourlySalaryCalculator : ISalaryCalculator
{
    private readonly double _hourlyPrice;
    private readonly int _hoursWorked;

    public HourlySalaryCalculator(double hourlyPrice, int hoursWorked)
    {
        _hourlyPrice = hourlyPrice;
        _hoursWorked = hoursWorked;
    }

    public double CalculateSalary()
    {
        return _hourlyPrice * _hoursWorked;
    }
}

// BRIDGE
class ContractSalaryCalculator : ISalaryCalculator
{
    private readonly double _contractAmount;

    public ContractSalaryCalculator(double contractAmount)
    {
        _contractAmount = contractAmount;
    }

    public double CalculateSalary()
    {
        return _contractAmount;
    }
}

class Program
{
    static void Main()
    {
        var hourlyEmployee = new Employee("Tommy", "Developer", new HourlySalaryCalculator(20, 40));
        var contractEmployee = new Employee("Alfred", "Designer", new ContractSalaryCalculator(1500));

        Console.WriteLine($"{hourlyEmployee.Name} Salary: ${hourlyEmployee.CalculateSalary()}");
        Console.WriteLine($"{contractEmployee.Name} Salary: ${contractEmployee.CalculateSalary()}");
    }
}
