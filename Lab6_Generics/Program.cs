//Rickard Idevall NET26

namespace Lab6_Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Mina objekt som jag ska stoppa i Stacken
            Employee employee1 = new Employee
            {
                Id = 001,
                Name = "Petter Pansarvagn",
                Gender = "Häst",
                Salary = 90000
            };
            Employee employee2 = new Employee
            {
                Id = 002,
                Name = "Aldor Ambulans",
                Gender = "Katt",
                Salary = 80000

            };
            Employee employee3 = new Employee
            {
                Id = 003,
                Name = "Rille Raket",
                Gender = "Unknown",
                Salary = 0

            };
            Employee employee4 = new Employee
            {
                Id = 004,
                Name = "Siri Spårvagn",
                Gender = "Kvinna",
                Salary = 500000

            };
            Employee employee5 = new Employee
            {
                Id = 007,
                Name = "James Bond",
                Gender = "Man",
                Salary = 500000

            };

            //Skapar Stacken
            Stack<Employee> employeeStack = new Stack<Employee>();
            //Pushar in mina objekt i stacken
            employeeStack.Push(employee1);
            employeeStack.Push(employee2);
            employeeStack.Push(employee3);
            employeeStack.Push(employee4);
            employeeStack.Push(employee5);
            Console.WriteLine("---------------------------");

            Console.WriteLine("Utskrift av alla Employees med foreach");
            //Sätter en egen räknare som börjar på Count antalet som finns i stacken och det sätts i remaining.
            //Eftersom foreach inte tar bort något utan bara går genom stacken. 
            int remaining = employeeStack.Count; 
            //Foreach går genom stacken och börjar på första elementet(emp) och skriver ut dess info.
            foreach (Employee emp in employeeStack)
            {
                Console.WriteLine($"{emp.Id}, - {emp.Name}, - {emp.Gender}, - {emp.Salary}");

                //Efter foreach gått genom och skrivit ut för objekt(emp) ett. Minska räknaren remaining med ett och använd metoden PrintRemaining().
                remaining--;
                PrintRemaining(remaining);
            }
            
            Console.WriteLine("---------------------------");
            // Eftersom POP() tar bort det översta objektet i stacken och returnerar det behöver jag ingen egen räknare.
            Console.WriteLine("Utskrift av alla Employees med POP()");
            //Jag vill gå genom hela stacken och pop tar bort.
            //Så använder jag While loop som ska gå genom stacken tills den är nere på 0.

            // Skapar en lista som jag kan lägga dom popade objekten i så jag når dom sen.
            Console.WriteLine("---------------------------");
            List<Employee> poppedEmployees = new List<Employee>();
            while (employeeStack.Count > 0)
            {
                //Gå genom employeeStack och använd Pop metoden på översta objektet. Lägg det i variabeln emp.
                Employee emp = employeeStack.Pop();
                Console.WriteLine($"{emp.Id}, - {emp.Name}, - {emp.Gender}, - {emp.Salary}");

                //Lägger den poppade emp i listan.
                poppedEmployees.Add(emp);

                //Efter varje pop och utksrift körs PrintRemaining metoden. 
                PrintRemaining(employeeStack.Count);

            }
            //Stacken tom efter popat alla, lägger nu tillbaka dom med push och här märkte jag att mina objekt är borta och fastnade.
            //Pushar tillbaka dom popade emp från min lista tillbaka till stacken
            Console.WriteLine("---------------------------");
            Console.WriteLine("Pushar tillbaka alla Employees i till stacken");

            //Märkte att nu när Popat objekten ur stacken hamna dom inte i LIFO ordning. Använder Reverse() på listan. 
            poppedEmployees.Reverse();
            
            foreach (Employee emp in poppedEmployees)
            {
                employeeStack.Push(emp);
                
            }
            Console.WriteLine("---------------------------");
            Console.WriteLine("Hämtar två(samma) objekt med Peek()");
            //Märkte att den peekar på samma och höll på överkomplicera. 
            //Såg sedan er utskrift peeka på samma objekt så gör likadant.

            Employee peekEmp = employeeStack.Peek();
            Console.WriteLine($"{peekEmp.Id}, - {peekEmp.Name}, - {peekEmp.Gender}, - {peekEmp.Salary}");
            PrintRemaining(employeeStack.Count);

            // Peek igen samma objekt eftersom Peek inte tar bort något.
            peekEmp = employeeStack.Peek();
            Console.WriteLine($"{peekEmp.Id}, - {peekEmp.Name}, - {peekEmp.Gender}, - {peekEmp.Salary}");
            PrintRemaining(employeeStack.Count);

            Console.WriteLine("---------------------------");

            Console.WriteLine("Kollar om Employee nummer 3 finns i stacken");

            // Contains kollar om objektet finns i stacken.
            // Eftersom jag pushat tillbaka alla Employees ska employee3 finnas.
            bool exists = employeeStack.Contains(employee3);

            if (exists)
            {
                Console.WriteLine("Emp3 finns med i stacken");
            }
            else
            {
                Console.WriteLine("Emp3 finns inte med i stacken");
            }
            //Skapar en ny Employee list.
            List<Employee> employeeList = new List<Employee>();
            employeeList.Add(employee1);
            employeeList.Add(employee2);
            employeeList.Add(employee3);
            employeeList.Add(employee4);
            employeeList.Add(employee5);
            // Contains() kollar om objektet employee2 finns i listan.
            Console.WriteLine("---------------------------");
            
            Console.WriteLine("Kollar om Employee2 finns i listan. ");
            if (employeeList.Contains(employee2))
            {
                Console.WriteLine("Employee2 objektet finns i listan. ");
            }
            else
            {
                Console.WriteLine("Employee2 objektet finns inte i listan.");
            }
            //Insåg när jag började med Find() att det bara är en inbyggd foreach med en break.
            //Find() gör det snyggare och snabbare? Använder if sats för utskrift.
            //Tog tid att fatta jag ska jämföra med null. och varför det blir bra.
            Employee firstMale = employeeList.Find(emp => emp.Gender == "Man");
            if (firstMale != null)
            {
                Console.WriteLine($"{firstMale.Id}, - {firstMale.Name}, - {firstMale.Gender}, - {firstMale.Salary}");
            }
            else
            {
                Console.WriteLine("Ingen Employee med könet Man finns.");
            }
            Console.WriteLine("---------------------------");
            // FindAll() hitta alla objekt med Gender = "Man"
            //FindAll kan returnera flera objekt så skapar en lista allMales kopplat till metoden FindAll() och dess vilkor.
            List<Employee> allMales = employeeList.FindAll(emp => emp.Gender == "Man");
            //Går sedan genom allMales listan med en foreach.
            foreach(Employee male in allMales)
            {
                Console.WriteLine($"{male.Id}, - {male.Name}, - {male.Gender}, - {male.Salary}");
            }
        }

        //Märkte att jag skulle skriva ut kvarvarande flera gånger så raderade och gör om det till en metod.
        //Lägger metoden här i Program klassen så jag inte överkomplicerar programmet.
        public static void PrintRemaining(int remaining)
        {
            Console.WriteLine($"Antal personer kvar i stacken: {remaining}\n");
        }
    }
}

