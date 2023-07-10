// See https://aka.ms/new-console-template for more information

using System.Globalization;
using EnumerationExercise.Entities;
using EnumerationExercise.Entities.Enums;

Console.Write("Enter department's name: ");
string departmentName = Console.ReadLine();
Department department = new Department(departmentName);

Console.WriteLine("Enter worker data...");

Console.Write("Name: ");
string workerName = Console.ReadLine();

Console.Write("Level (Junior/MidLevel/Senior): ");
string stringWorkerLevel = Console.ReadLine();
WorkerLevel workerLevel;
Enum.TryParse(stringWorkerLevel, out workerLevel);

Console.Write("Base salary: ");
double baseSalary = Convert.ToDouble(Console.ReadLine());

Worker worker = new Worker(workerName,baseSalary,workerLevel,department);

Console.Write("How many contracts to this worker? ");
int numberOfContracts = Convert.ToInt32(Console.ReadLine());

for (int i = 0; i < numberOfContracts; i++)
{
    Console.Write("Date (DD:MM:YYYY): ");
    string dateString = Console.ReadLine();
    DateTime date;
    DateTime.TryParseExact(dateString, "dd:MM:yyyy", null, DateTimeStyles.None, out date);
    
    Console.Write("Value per hour: ");
    double valuePerHour = Convert.ToDouble(Console.ReadLine());
    
    Console.Write("Number of hours: ");
    int numberOfhours = Convert.ToInt32(Console.ReadLine());

    HourContract contract = new HourContract(date, valuePerHour, numberOfhours);

    worker.AddContract(contract);
    
}

Console.Write("Enter month and year to calculate income (MM:YYYY): ");
string monthDateString = Console.ReadLine();
DateTime monthDate;
DateTime.TryParseExact(monthDateString, "MM:yyyy", null, DateTimeStyles.None, out monthDate);


double income = worker.Income(monthDate.Year, monthDate.Month);

string formatedStringOfIncome =
    $"Name: {worker.Name}\nDepartment: {worker.Department.ToString()}\nIncome for {monthDate}: {income}";

Console.WriteLine(formatedStringOfIncome);

