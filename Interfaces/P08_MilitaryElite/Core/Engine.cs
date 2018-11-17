using P08_MilitaryElite.Enums;
using P08_MilitaryElite.Interfaces;
using P08_MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P08_MilitaryElite.Core
{
    public class Engine
    {
        private List<ISoldier> soldiers;
        private ISoldier soldier;

        public Engine()
        {
            this.soldiers = new List<ISoldier>();
        }
        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputArgs = input.Split(' ').ToArray();

                //• Private: “Private<id> < firstName > < lastName > < salary >”
                //• LeutenantGeneral: “LieutenantGeneral<id> < firstName > < lastName > < salary > < private1Id > < private2Id > … < privateNId >” where privateXId will always be an Id of a private already received through the input.
                //• Engineer: “Engineer<id> <firstName> <lastName> <salary> <corps> <repair1Part> <repair1Hours> … <repairNPart> <repairNHours>” where repairXPart is the name of a repaired part and repairXHours the hours it took to repair it(the two parameters will always come paired). 
                //• Commando: “Commando<id> <firstName> <lastName> <salary> <corps> <mission1CodeName>  <mission1state> … <missionNCodeName> <missionNstate>” a missions cde name, description and state will always come together.
                //• Spy: “Spy<id> <firstName> <lastName> <codeNumber>”

                string type = inputArgs[0];
                int id = int.Parse(inputArgs[1]);
                string firstName = inputArgs[2];
                string lastName = inputArgs[3];

                if (type == "Private")
                {
                    decimal salary = decimal.Parse(inputArgs[4]);
                    soldier = GetPrivateSoldier(id, firstName, lastName, salary);
                }
                else if (type == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(inputArgs[4]);
                    soldier = GetLieutenantGeneral(id, firstName, lastName, salary, inputArgs);
                }
                else if (type == "Engineer")
                {
                    decimal salary = decimal.Parse(inputArgs[4]);
                    soldier = GetEngineer(id, firstName, lastName, salary, inputArgs);
                }
                else if (type == "Commando")
                {
                    decimal salary = decimal.Parse(inputArgs[4]);
                    soldier = GetCommando(id, firstName, lastName, salary, inputArgs);
                }
                else if (type == "Spy")
                {
                    int codeNumber = int.Parse(inputArgs[4]);
                    soldier = GetSpy(id, firstName, lastName, codeNumber);
                }

                if (soldier != null)
                {
                    this.soldiers.Add(soldier);
                }

                input = Console.ReadLine();
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        private ISoldier GetSpy(int id, string firstName, string lastName, int codeNumber)
        {
            ISpy spy = new Spy(id, firstName, lastName, codeNumber);

            return spy;
        }

        private ISoldier GetCommando(int id, string firstName, string lastName, decimal salary, string[] inputArgs)
        {

            string corpsAsString = inputArgs[5];

            if (!Enum.TryParse(corpsAsString, out Corps corps))
            {
                return null;
            }
            ICommando commando = new Commando(id, firstName, lastName, salary, corps);

            for (int i = 6; i < inputArgs.Length; i+=2)
            {
                string codeName = inputArgs[i];
                string stateAsString = inputArgs[i + 1];
                if (!Enum.TryParse(stateAsString, out State state))
                {
                    continue;
                }

                IMission mission = new Missions(codeName, state);
                commando.Missions.Add(mission);
            }

            return commando;
        }

        private ISoldier GetEngineer(int id, string firstName, string lastName, decimal salary, string[] inputArgs)
        {
            string corpsAsString = inputArgs[5];

            if(!Enum.TryParse(corpsAsString, out Corps corps))
            {
                return null;
            }

            IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

            for (int i = 6; i < inputArgs.Length; i+=2)
            {
                string partName = inputArgs[i];
                int hours = int.Parse(inputArgs[i + 1]);

                IRepair repair = new Repair(partName, hours);
                engineer.Repairs.Add(repair);
            }



            return engineer;
        }

        private ISoldier GetLieutenantGeneral(int id, string firstName, string lastName, decimal salary, string[] inputArgs)
        {
            ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

            for (int i = 5; i < inputArgs.Length; i++)
            {
                int privateId = int.Parse(inputArgs[i]);
                IPrivate privateSoldier = (IPrivate) this.soldiers.FirstOrDefault(s => s.Id == privateId);
                lieutenantGeneral.Privates.Add(privateSoldier);
            }

            return lieutenantGeneral;
        }

        private ISoldier GetPrivateSoldier(int id, string firstName, string lastName, decimal salary)
        {
            IPrivate privateSoldier = new Private(id, firstName, lastName, salary);
            return privateSoldier;
        }
    }
}
