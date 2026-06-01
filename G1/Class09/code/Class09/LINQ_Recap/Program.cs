// Homework LINQ: Task 11
// Select only the model and horsepower of cars with horsepower greater than 200.

// 1) Using anonymous type (not recommended)
IEnumerable<object> result = CarsData.Cars
    .Where(car => car.HorsePower > 200)
    .Select(car => new { car.Model, car.HorsePower });

// 2) Using a named class (recommended)
IEnumerable<CarInfo> result2 = CarsData.Cars
    .Where(car => car.HorsePower > 200)
    .Select(car => new CarInfo { Model = car.Model, HorsePower = car.HorsePower });

// 3) Using a record type (recommended for immutability)
IEnumerable<CarInfoRecord> result3 = CarsData.Cars
    .Where(car => car.HorsePower > 200)
    .Select(car => new CarInfoRecord(car.Model, car.HorsePower));

CarInfoRecord carInfoRecord = new CarInfoRecord("TestModel", 250);
//carInfoRecord.Model = "NewModel"; // This will cause a compile-time error because records are immutable.

Console.ReadLine();

internal class CarInfo
{
    public string Model { get; set; }
    public double HorsePower { get; set; }
}

internal record CarInfoRecord(string Model, double HorsePower);
