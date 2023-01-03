using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace excercise_4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Equipment> equipments = new List<Equipment>();

            
            //menu for selecting function by the user
            int choice = -1;
            while (choice != 9)
            {
                Console.WriteLine("1. Create an equipment");
                Console.WriteLine("2. Move an equipment");
                Console.WriteLine("3. View details of an equipment");
                Console.WriteLine("4. List all equipments");
                Console.WriteLine("5. Delete an equipment");
                Console.WriteLine("6. List all equipments not been moved till now");
                Console.WriteLine("7. List all Mobile equipments");
                Console.WriteLine("8. List all Immobile equipments");
                Console.WriteLine("9. Exit");
                Console.WriteLine("Your Choice: ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("\nSelect correct menu item.\n");
                }
                else
                {
                    switch (choice)
                    {
                        case 1://Create an equipment – mobile and immobile
                            createEquipment(equipments);
                            break;
                        case 2:
                            moveEquipment(equipments);
                            break;
                        case 3:
                            showdetails(equipments);
                            break;
                        case 4:
                            listAllEquipment(equipments);
                            break;
                        case 5:
                            deleteEquipment(equipments);
                            break;                        
                        case 6:
                            listAllEquipmentNotBeenMovedTillNow(equipments);
                            break;
                        case 7:
                            listAllMobileEquipment(equipments);
                            break;
                        case 8:
                            listAllImmobileEquipment(equipments);
                            break;
                        case 9:
                            break;
                        default:
                            Console.WriteLine("\nSelect correct menu item.\n");
                            break;
                    }
                }
            }
        }


        
        //creating an equipmnet with details as provided by user
        static void createEquipment(List<Equipment> equipments)
        {
            string name;
            string description;
            double maintenance;
            double distance;
            double parameter;
            int choice;
            Console.WriteLine("1. Create mobile equipment");
            Console.WriteLine("2. Create immobile equipment");
            Console.Write("Your choice: ");
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2)
            {
                Console.WriteLine("\nSelect correct menu item.\n");
            }
            else
            {
                Console.Write("Enter the name: ");
                name = Console.ReadLine();

                Console.Write("Enter the description: ");
                description = Console.ReadLine();

                Console.Write("Enter the distance covered: ");
                if (!double.TryParse(Console.ReadLine(), out distance) || distance < 0)
                {
                    Console.WriteLine("\nEnter correct the distance covered>0.\n");
                }
                
                Console.Write("Enter the maintenance cost: ");
                if (!double.TryParse(Console.ReadLine(), out maintenance) || maintenance < 0)
                {
                    Console.WriteLine("\nEnter correct the maintenance cost>0.\n");
                }                

                Console.WriteLine("Enter the ");
                if (Convert.ToInt32(choice) == 1)
                {
                    Console.WriteLine("number of wheels: ");
                    if (!double.TryParse(Console.ReadLine(), out parameter) || parameter < 0)
                    {
                        Console.WriteLine("\nEnter correct the parameter>0.\n");
                    }
                }
                else
                {
                    Console.WriteLine("weight of equipment: ");
                    if (!double.TryParse(Console.ReadLine(), out parameter) || parameter < 0)
                    {
                        Console.WriteLine("\nEnter correct the parameter>0.\n");
                    }
                }

                if (choice == 1)
                {
                    equipments.Add(new Mobile(name, description, distance, maintenance, parameter));
                }
                if (choice == 2)
                {
                    equipments.Add(new Immobile(name, description, distance, maintenance, parameter));
                }
                Console.WriteLine("\nA new equipment has been added.\n");
            }
        }

        //deleting an equipment
        static void deleteEquipment(List<Equipment> equipments)
        {
            if (equipments.Count > 0)
            {
                listAllEquipment(equipments);
                int selectedEquipment = -1;
                Console.Write("Select the equipment: ");
                if (!int.TryParse(Console.ReadLine(), out selectedEquipment) || selectedEquipment < 0 || selectedEquipment > equipments.Count)
                {
                    Console.WriteLine("\nSelect correct equipment.\n");
                }
                else
                {
                    equipments.RemoveAt(selectedEquipment - 1);
                    Console.WriteLine("\nThe equipment has been deleted.\n");
                }


            }
            else
            {
                Console.WriteLine("\nYou have not added equipments yet.");
            }
            Console.WriteLine();


        }


        ///moving selected equipment by entered distance
        static void moveEquipment(List<Equipment> equipments)
        {
            if (equipments.Count > 0)
            {
                listAllEquipment(equipments);
                int selectedEquipment = -1;
                Console.Write("Select the equipment: ");
                if (!int.TryParse(Console.ReadLine(), out selectedEquipment) || selectedEquipment < 0 || selectedEquipment > equipments.Count)
                {
                    Console.WriteLine("\nSelect correct equipment.\n");
                }
                else
                {
                    int distanceMoved;
                        Console.Write("Enter the distance to move equipment: ");
                        if (!int.TryParse(Console.ReadLine(), out distanceMoved) || distanceMoved < 0)
                        {
                            Console.WriteLine("\nEnter correct the distance to move>0.\n");
                        }
                        else
                        {
                            (equipments[selectedEquipment - 1]).distance = distanceMoved + equipments[selectedEquipment-1].distance;
                        equipments[selectedEquipment - 1].maintenance = equipments[selectedEquipment-1].maintenance + (equipments[selectedEquipment - 1].parameter * equipments[selectedEquipment - 1].distance);
                        }                    
                }


            }
            else
            {
                Console.WriteLine("\nYou have not added equipments yet.");
            }
            Console.WriteLine();
        }


        //listing all equipments for selecting equipments for distance move function
        static void listAllEquipment(List<Equipment> equipments)
        {


            if (equipments.Count > 0)
            {
                Console.WriteLine("\n{0,-15}{1,-25}{2,-15}", "No", "Name", "Description");
                for (int i = 0; i < equipments.Count; i++)
                {
                    Console.WriteLine("{0,-15}{1,-25}{2,-15}", (i + 1), equipments[i].name, equipments[i].description);
                }
            }
            else
            {
                Console.WriteLine("\nYou have not added equipments yet.");
            }
            Console.WriteLine();
        }

        
        //listing all equipments function with all the details
        static void showdetails(List<Equipment> equipments)
        {


            if (equipments.Count > 0)
            {
                Console.WriteLine("\n{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}", "No", "Type", "Name", "Description", "Cost", "Distance Moved");
                for (int i = 0; i < equipments.Count; i++)
                {
                    string type = "Immobile";
                    if (equipments[i] is Mobile)
                    {
                        type = "Mobile";
                    }
                    Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}", (i + 1), type, equipments[i].name, equipments[i].description, equipments[i].maintenance, equipments[i].distance);
                }
            }
            else
            {
                Console.WriteLine("\nYou have not added equipments yet.");
            }
            Console.WriteLine();
        }

        //list all mobile equipment
        static void listAllMobileEquipment(List<Equipment> equipments)
        {


            if (equipments.Count > 0)
            {
                int i = 0;
                Console.WriteLine("\n{0,-15}{1,-15}{2,-25}{3,-35}{4,-15}{5,-15}", "No", "Type", "Name", "Description", "Cost", "Distance moved");
                foreach (Equipment equipment in equipments.FindAll(e => e is Mobile))
                {
                    Console.WriteLine("{0,-15}{1,-15}{2,-25}{3,-35}{4,-15}{5,-15}", (i + 1), "Mobile", equipment.name, equipment.description, equipment.maintenance, (((Mobile)equipment).distance));
                    i++;
                }
            }
            else
            {
                Console.WriteLine("\nYou have not added equipments yet.");
            }
            Console.WriteLine();
        }

        //list of immobile equipment
        static void listAllImmobileEquipment(List<Equipment> equipments)
        {


            if (equipments.Count > 0)
            {
                int i = 0;
                Console.WriteLine("\n{0,-15}{1,-15}{2,-25}{3,-35}{4,-15}", "No", "Type", "Name", "Description", "Cost");
                foreach (Equipment equipment in equipments.FindAll(e => e is Immobile))
                {
                    Console.WriteLine("{0,-15}{1,-15}{2,-25}{3,-35}{4,-15}", (i + 1), "Immobile", equipment.name, equipment.description, equipment.maintenance);
                    i++;
                }
            }
            else
            {
                Console.WriteLine("\nYou have not added equipments yet.");
            }
            Console.WriteLine();
        }

        //list of equipment that has not been moved till now
        static void listAllEquipmentNotBeenMovedTillNow(List<Equipment> equipments)
        {


            if (equipments.Count > 0)
            {
                int i = 0;
                Console.WriteLine("\n{0,-15}{1,-15}{2,-25}{3,-35}{4,-15}", "No", "Type", "Name", "Description", "Cost");
                foreach (Equipment equipment in equipments.FindAll(e => e is Mobile && (((Mobile)e).distance) == 0))
                {
                    Console.WriteLine("{0,-15}{1,-15}{2,-25}{3,-35}{4,-15}", (i + 1), "Mobile", equipment.name, equipment.description, equipment.maintenance);
                    i++;
                }
            }
            else
            {
                Console.WriteLine("\nYou have not added equipments yet.");
            }
            Console.WriteLine();
        }

        
        //Delete all Equipment
        static void deleteAllEquipment(List<Equipment> equipments)
        {
            if (equipments.Count > 0)
            {
                listAllEquipment(equipments);

                Console.Write("Are you sure you want to delete all the equipments?(Y/N)");
                
                string confirm = Console.ReadLine();
                if(confirm == "Y")
                {
                    equipments.Clear();
                }

            }
            else
            {
                Console.WriteLine("\nYou have not added equipments yet.");
            }
            Console.WriteLine();


        }

        //Delete all Mobile or Immobile Equipment
        //static void deleteAllMobileEquipment(List<Equipment> equipments)
        //{
        //    if (equipments.Count > 0)
        //    {
        //        listAllEquipment(equipments);                

        //        Console.Write("Are you sure you want to delete all the equipments?(Y/N)");

        //        string confirm = Console.ReadLine();
        //        if (confirm == "Y")
        //        {                    
        //            equipments.RemoveAll();                    
        //        }


        //    }
        //    else
        //    {
        //        Console.WriteLine("\nYou have not added equipments yet.");
        //    }
        //    Console.WriteLine();


        //}
    }
}
