using InsuranceContractingAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceContractingAPI.DAL
{

    public class CreateTestData
    {
        public static void AddTestData(ICDbContext context)
        {

            List<Contractors> contractors = new List<Contractors>()
            {
                new Contractors() { ContractorId = 1, ContractorName = "ADV-1"},
                new Contractors() { ContractorId = 2, ContractorName = "ADV-2"},
                new Contractors() { ContractorId = 3, ContractorName = "ADV-3"},
                new Contractors() { ContractorId = 4, ContractorName = "ADV-4"},
                new Contractors() { ContractorId = 5, ContractorName = "CAR-1"},
                new Contractors() { ContractorId = 6, ContractorName = "CAR-2"},
                new Contractors() { ContractorId = 7, ContractorName = "CAR-3"},
                new Contractors() { ContractorId = 8, ContractorName = "CAR-4"},
                new Contractors() { ContractorId = 9, ContractorName = "MGA-1"},
                new Contractors() { ContractorId = 10, ContractorName = "MGA-2"},
                new Contractors() { ContractorId = 11, ContractorName = "MGA-3"},
                new Contractors() { ContractorId = 12, ContractorName = "MGA-4"},
                new Contractors() { ContractorId = 13, ContractorName = "ADV-5"},
                new Contractors() { ContractorId = 14, ContractorName = "ADV-6"},
                new Contractors() { ContractorId = 15, ContractorName = "CAR-5"},
                new Contractors() { ContractorId = 16, ContractorName = "CAR-6"}, 
                new Contractors() { ContractorId = 17, ContractorName = "MGA-5"},
                new Contractors() { ContractorId = 18, ContractorName = "MGA-6"}
            };
            context.Contractors.AddRange(contractors);


            List<Advisors> listOfAdvisors = new List<Advisors>()
            {
                new Advisors(){ AdvisorsId = 1, Address = "123 test location",
                    FirstName = "Bill", LastName = "Gates", PhoneNumber = "6478523574", HealthStatus = GetHealthStatus(), ContractorId = 1},
                new Advisors(){ AdvisorsId = 2, Address = "CN Tower",
                    FirstName = "Sundar", LastName = "Pichai", PhoneNumber = "698535356", HealthStatus = GetHealthStatus(), ContractorId = 2},
                new Advisors(){ AdvisorsId = 3, Address = "Hyper Loop",
                                    FirstName = "Ray", LastName = "Krustwel", PhoneNumber = "6358745555", HealthStatus = GetHealthStatus(), ContractorId = 3},
                new Advisors(){ AdvisorsId = 4, Address = "Casa loma",
                                    FirstName = "Albert", LastName = "Einstein", PhoneNumber = "4564568956", HealthStatus = GetHealthStatus(), ContractorId = 4},
                new Advisors(){ AdvisorsId = 5, Address = "Casa loma",
                                    FirstName = "Nicholas", LastName = "Tesla", PhoneNumber = "2145454545", HealthStatus = GetHealthStatus(), ContractorId = 13},
                new Advisors(){ AdvisorsId = 6, Address = "Casa loma",
                                    FirstName = "Erwin", LastName = "Schrodinger", PhoneNumber = "4654654545", HealthStatus = GetHealthStatus(), ContractorId = 14}

            };

            context.Advisors.AddRange(listOfAdvisors);

            List<Carriers> listOfCarriers = new List<Carriers>()
            {
                new Carriers(){ CarrierId = 1, BusinessAddress = "Rose street", BusinessName = "Apple", PhoneNumber = "6549876545", ContractorId =  5},
                new Carriers(){ CarrierId = 2, BusinessAddress = "Tulip avenue", BusinessName = "Google", PhoneNumber = "3216546545" , ContractorId = 6},
                new Carriers(){ CarrierId = 3, BusinessAddress = "Sunflower cresent", BusinessName = "Tesla", PhoneNumber = "6546546542" , ContractorId = 7},
                new Carriers(){ CarrierId = 4, BusinessAddress = "Nightqueen Park", BusinessName = "Amazon", PhoneNumber = "2315465455" , ContractorId = 8},
                new Carriers(){ CarrierId = 5, BusinessAddress = "Marriegold Park", BusinessName = "Palantir", PhoneNumber = "4654654654" , ContractorId = 15},
                new Carriers(){ CarrierId = 6, BusinessAddress = "Jasmine Park", BusinessName = "IBM", PhoneNumber = "7564654546" , ContractorId = 16}

            };
            context.Carriers.AddRange(listOfCarriers);

            List<MGAs> listOfMGAs = new List<MGAs>()
            {
                new MGAs(){ MGAId = 1, PhoneNumber = "6546549878", BusinessName = "Kubernetes", BusinessAddress = "Church Street", ContractorId = 9},
                new MGAs(){ MGAId = 2, PhoneNumber = "3216549875", BusinessName = "Linux", BusinessAddress = "Park Avenue", ContractorId = 10},
                new MGAs(){ MGAId = 3, PhoneNumber = "3546513454", BusinessName = "Android", BusinessAddress = "Fiftheen Place", ContractorId = 11},
                new MGAs(){ MGAId = 4, PhoneNumber = "7854268598", BusinessName = "Docker", BusinessAddress = "Void Hill", ContractorId = 12},
                new MGAs(){ MGAId = 5, PhoneNumber = "5465878787", BusinessName = "Bitcoin", BusinessAddress = "Back Road", ContractorId = 17},
                new MGAs(){ MGAId = 6, PhoneNumber = "3454534688", BusinessName = ".Net Core", BusinessAddress = "Forest Canal", ContractorId = 18}
            };
            context.MGAs.AddRange(listOfMGAs);

            List<Contracts> listOfContracts = new List<Contracts>()
            {
                new Contracts() { ContractId = 1, ContractorIdA = 1, ContractorIdB = 5},
                new Contracts() { ContractId = 2, ContractorIdA = 5, ContractorIdB = 10},
                new Contracts() { ContractId = 3, ContractorIdA = 2, ContractorIdB = 6},
                new Contracts() { ContractId = 4, ContractorIdA = 3, ContractorIdB = 5},
            };
            context.Contracts.AddRange(listOfContracts);

            context.SaveChanges();

        }

        static string GetHealthStatus()
        {
            Random random = new Random();
            //Generate Green status 70 percent of time
            if (random.NextDouble() < 0.71)
                return "Green";
            else
                return "Red";
        }
    }
}
