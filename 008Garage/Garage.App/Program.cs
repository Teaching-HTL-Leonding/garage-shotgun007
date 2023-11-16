using System.ComponentModel.Design;
using Garage.Logic;

GarageClass g;
g = new GarageClass();
string selection;
int parkingSpotNumber;
decimal costs;
do
{
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("1) Enter a car entry");
    Console.WriteLine("2) Enter a car exit");
    Console.WriteLine("3) Generate report");
    Console.WriteLine("4) Exit");
    selection = Console.ReadLine()!;
    Console.WriteLine($"Your selection: {selection}");

    switch (selection)
    {
        case "1":
            Console.Write("Enter parking spot number: ");
            parkingSpotNumber = int.Parse(Console.ReadLine()!);
            Console.Write("Enter license plate: ");
            string licensePlate = Console.ReadLine()!;
            Console.Write("Enter entry date/time: ");
            DateTime entryTime = DateTime.Parse(Console.ReadLine()!);
            g.TryOccupy(parkingSpotNumber, licensePlate, entryTime);
            break;
        case "2":
            Console.Write("Enter parking spot number: ");
            parkingSpotNumber = int.Parse(Console.ReadLine()!);
            Console.Write("Enter exit date/time: ");
            DateTime exitTime = DateTime.Parse(Console.ReadLine()!);
            g.TryExit(parkingSpotNumber, exitTime,out costs);
            break;
        case "3":
            g.A();
            break;
        case "4":
            Console.WriteLine("Good Bye!");
            break;
        default:
            Console.WriteLine("Invalid input");
            break;
    }




}
while (selection != "4");
































































