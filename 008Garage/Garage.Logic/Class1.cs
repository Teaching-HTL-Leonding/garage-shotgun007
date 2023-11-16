namespace Garage.Logic;
public class ParkingSpot
{
    public ParkingSpot(string licensePlate, DateTime entryTime)
    {
        LicensePlate = licensePlate;
        EntryTime = entryTime;
    }
    public string LicensePlate { get; set; }
    public DateTime EntryTime { get; set; }
}
public class GarageClass
{
    public bool IsOccupied(int parkingSpotNumber)
    {
        if (ParkingSpots[parkingSpotNumber - 1] is not null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool TryOccupy(int parkingSpotNumber, string licensePlate, DateTime entryTime)
    {
        if (IsOccupied(parkingSpotNumber))
        {
            Console.WriteLine("Parking spot is occupied");
            return false;
        }
        else
        {

            ParkingSpots[parkingSpotNumber - 1] = new ParkingSpot(licensePlate, entryTime);
            return true;
        }
    }
    public bool TryExit(int parkingSpotNumber, DateTime exitTime, out decimal costs)
    {
        if (IsOccupied(parkingSpotNumber))
        {
            var time = exitTime - ParkingSpots[parkingSpotNumber - 1].EntryTime;
            int halfHour = time.Minutes / 30;
            if (time.Minutes % 30 != 0)
            {
                halfHour++;
            }
            if (time.Minutes > 15)
            {
                costs = halfHour * 3;
            }
            else
            {
                costs = 0;
            }
            ParkingSpots[parkingSpotNumber - 1] = null!;
            Console.WriteLine($"Costs are {costs}");
            return true;
        }
        else
        {
            Console.WriteLine("Invalid input");
            costs = 0;
            return false;
        }
    }
    public void A()
    {
        Console.WriteLine("| Spot | License Plate |");
        for (int i = 0; i < ParkingSpots.Length; i++)
        {
            Console.Write($"| {i + 1}");
            if (i < 9)
            {
                Console.Write("    | ");
            }
            else
            {
                Console.Write("   | ");
            }
            if (ParkingSpots[i] != null)
            {
                Console.Write(ParkingSpots[i].LicensePlate);
                for (int j = 14 - ParkingSpots[i].LicensePlate.Length; j > 0; j--)
            {
                Console.Write(" ");
            }
            }
            else
            {
                Console.Write("              ");
            }
            
            Console.WriteLine("|");
        }
    }
    public ParkingSpot[] ParkingSpots { get; } = new ParkingSpot[50];
}









