//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApp1
//{

//    class ForMain
//    {
//        static void MainCar()
//        {
//            var car = new Car();
//            var car1 = new Car(10);
//            var car2 = new Car(12,14);


//            car.EngineStart();

//            car.Accelerate(30);
//            car.Accelerate(30);
//            car.Accelerate(30);
//            car.Accelerate(30);
//            car.Accelerate(30);
//            car.Accelerate(30);
//            car.Accelerate(30);
//            car.Accelerate(30);
//            car.Accelerate(30);
//            car.Accelerate(30);
//            Console.WriteLine(car.fuelTankDisplay.FillLevel);
//            Console.ReadLine();

//        }
//    }


//    public interface ICar
//    {
//        bool EngineIsRunning { get; }

//        void BrakeBy(int speed); // car #2

//        void Accelerate(int speed); // car #2

//        void EngineStart();

//        void EngineStop();

//        void FreeWheel(); // car #2

//        void Refuel(double liters);

//        void RunningIdle();
//    }

//    public interface IDrivingInformationDisplay // car #2
//    {
//        int ActualSpeed { get; }
//    }

//    public interface IDrivingProcessor // car #2
//    {
//        double ActualConsumption { get; } // car #3

//        int ActualSpeed { get; }

//        void EngineStart(); // car #3

//        void EngineStop(); // car #3

//        void IncreaseSpeedTo(int speed);

//        void ReduceSpeed(int speed);
//    }

//    public interface IEngine
//    {
//        bool IsRunning { get; }

//        void Consume(double liters);

//        void Start();

//        void Stop();
//    }

//    public interface IFuelTank
//    {
//        double FillLevel { get; }

//        bool IsOnReserve { get; }

//        bool IsComplete { get; }

//        void Consume(double liters);

//        void Refuel(double liters);
//    }

//    public interface IFuelTankDisplay
//    {
//        double FillLevel { get; }

//        bool IsOnReserve { get; }

//        bool IsComplete { get; }
//    }

    
//    public class DrivingInformationDisplay : IDrivingInformationDisplay
//    {

//        private IDrivingProcessor _drivingProcessor;

//        public DrivingInformationDisplay(IDrivingProcessor drivingProcessor)
//        {
//            _drivingProcessor = drivingProcessor;
//        }

//        public int ActualSpeed
//        {
//            get
//            {
//                return _drivingProcessor.ActualSpeed;
//            }
//        }
//    }
//    public class DrivingProcessor : IDrivingProcessor
//    {
//        private IEngine _engine;
//        private int _maxAcceleration;
//        private int _actualSpeed = 0;

//        public DrivingProcessor(IEngine engine, int maxAcceleration)
//        {
//            if (maxAcceleration < 5)
//            {
//                maxAcceleration = 5;
//            }
//            if (maxAcceleration > 20)
//            {
//                maxAcceleration = 20;
//            }

//            _engine = engine;
//            _maxAcceleration = maxAcceleration;
//        }

//        public int ActualSpeed => _actualSpeed;

//        public double ActualConsumption => throw new NotImplementedException();

//        public void EngineStart()
//        {
//            _engine.Start();
//        }

//        public void EngineStop()
//        {
//            throw new NotImplementedException();
//        }

//        public void IncreaseSpeedTo(int speed)
//        {
//            if (_engine.IsRunning && speed >= _actualSpeed)
//            {
//                if (speed - _actualSpeed >= _maxAcceleration)
//                {
//                    if (_actualSpeed + _maxAcceleration <= 250)
//                    {
//                        _actualSpeed=_actualSpeed + _maxAcceleration;
//                    }
//                    else
//                    {
//                        _actualSpeed = 250;
//                    }
//                }
//                else
//                {
//                    _actualSpeed = speed;
//                }

//                if (_actualSpeed == 0)
//                {
//                    _engine.Consume(0.0003);
//                }
//                if (_actualSpeed >= 1 && _actualSpeed <= 60)
//                {
//                    _engine.Consume(0.002);
//                }
//                if (_actualSpeed >= 61 && _actualSpeed <= 100)
//                {
//                    _engine.Consume(0.0014);
//                }
//                if (_actualSpeed >= 101 && _actualSpeed <= 140)
//                {
//                    _engine.Consume(0.002);
//                }
//                if (_actualSpeed >= 141 && _actualSpeed <= 200)
//                {
//                    _engine.Consume(0.0025);
//                }
//                if (_actualSpeed >= 201 && _actualSpeed <= 250)
//                {
//                    _engine.Consume(0.003);
//                }

//            }
           
//        }

//        public void ReduceSpeed(int speed)
//        {
//            if (_actualSpeed - speed >= 0)
//                if (speed < 10)
//                {
//                    _actualSpeed -= speed;
//                }
//                else
//                {
//                    _actualSpeed -=speed;
//                }

//        }
//    }

    
//    public class Car : ICar
//    {
 
//        public IFuelTankDisplay fuelTankDisplay;
//        private IEngine engine;
//        private IFuelTank fuelTank;
//        private IDrivingProcessor drivingProcessor;
//        public IDrivingInformationDisplay drivingInformationDisplay;

//        public IOnBoardComputerDisplay onBoardComputerDisplay; // car #3

//        private IOnBoardComputer onBoardComputer; // car #3


//        public Car(double fuelLevel = 20, int maxAcceleration = 10) // car #2
//        {
           
//            fuelTank = new FuelTank(fuelLevel);
//            engine = new Engine(fuelTank);
//            fuelTankDisplay = new FuelTankDisplay(fuelTank);
//            drivingProcessor = new DrivingProcessor(engine, maxAcceleration);
//            drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);

//        }

//        public bool EngineIsRunning => engine.IsRunning;
        
//        public void EngineStart()
//        {
//            if (fuelTank.FillLevel > 0)
//            {
//                engine.Start();
//            }
//        }

//        public void EngineStop()
//        {
//            engine.Stop();
//        }

//        public void Refuel(double liters)
//        {
//            fuelTank.Refuel(liters);
//        }

//        public void RunningIdle()
//        {
//            if (engine.IsRunning)
//            {
//                fuelTank.Consume(0.0003);
//            }
//            if(fuelTank.FillLevel<=0)
//            {
//                engine.Stop();
//            }
//        }

//        public void BrakeBy(int speed)
//        {
//            if (drivingInformationDisplay.ActualSpeed - speed >= 0)
//                if (speed < 10)
//                {
//                    drivingProcessor.ReduceSpeed(speed);
//                }
//                else
//                {
//                    drivingProcessor.ReduceSpeed(10);
//                }
//        }

//        public void Accelerate(int speed)
//        {
//            drivingProcessor.IncreaseSpeedTo(speed);
//            if (speed < drivingInformationDisplay.ActualSpeed)
//            {
//                FreeWheel();
//            }
//            if (fuelTankDisplay.FillLevel <= 0)
//                engine.Stop();
//        }

//        public void FreeWheel()
//        {
//            if (drivingInformationDisplay.ActualSpeed  > 0)
//                BrakeBy(1);
//            else
//            {
//                RunningIdle();
//            }
//        }
//    }

//    public class Engine : IEngine
//    {

//        private IFuelTank _fuelTank;

//        public bool IsRunning { get; private set; }

//        public Engine(IFuelTank fuelTank)
//        {
//            _fuelTank = fuelTank;
//        }

//        public void Consume(double liters)
//        {
//            if (IsRunning)
//            {
//                _fuelTank.Consume(liters);

//                if (_fuelTank.FillLevel <= 0)
//                {
//                    Stop();
//                }
//            }
//        }

//        public void Start()
//        {
//            IsRunning = true;
//        }

//        public void Stop()
//        {
//            IsRunning = false;
//        }
//    }

//    public class FuelTank : IFuelTank
//    {
//        double fuelLevel;

//        public FuelTank(double liters)
//        {
//            if (liters <= 60 && liters > 0)
//            {
//                fuelLevel = liters;
//            }
//            else if (liters<0)
//            {
//                fuelLevel = 0;
//            }
//            else if(liters > 60)
//            {
//                fuelLevel = 60;
//            }
            
//        }

//        public double FillLevel => fuelLevel;

//        public bool IsOnReserve => fuelLevel < 5 ? true : false;
      
//        public bool IsComplete => fuelLevel == 60 ? true : false;
        
//        public void Consume(double liters)
//        {
//            fuelLevel -= liters; 
//        }

//        public void Refuel(double liters)
//        {
//            if (liters > 0)
//            {
//                if (fuelLevel + liters < 60)
//                    fuelLevel += liters;
//                else if (fuelLevel + liters >= 60)
//                    fuelLevel = 60;
//            }
                
//        }
//    }

//    public class FuelTankDisplay : IFuelTankDisplay
//    {
//        private IFuelTank fuelTank;
//        public FuelTankDisplay(IFuelTank tank)
//        {
//            fuelTank = tank;
//        }
        
//        public double FillLevel => System.Math.Round(fuelTank.FillLevel,2);

//        public bool IsOnReserve => fuelTank.IsOnReserve;

//        public bool IsComplete => fuelTank.IsComplete;

//    }


//    public interface IOnBoardComputer // car #3
//    {
//        int TripRealTime { get; }

//        int TripDrivingTime { get; }

//        int TripDrivenDistance { get; }

//        int TotalRealTime { get; }

//        int TotalDrivingTime { get; }

//        int TotalDrivenDistance { get; }

//        double TripAverageSpeed { get; }

//        double TotalAverageSpeed { get; }

//        int ActualSpeed { get; }

//        double ActualConsumptionByTime { get; }

//        double ActualConsumptionByDistance { get; }

//        double TripAverageConsumptionByTime { get; }

//        double TotalAverageConsumptionByTime { get; }

//        double TripAverageConsumptionByDistance { get; }

//        double TotalAverageConsumptionByDistance { get; }

//        int EstimatedRange { get; }

//        void ElapseSecond();

//        void TripReset();

//        void TotalReset();
//    }

//    public interface IOnBoardComputerDisplay // car #3
//    {
//        int TripRealTime { get; }

//        int TripDrivingTime { get; }

//        double TripDrivenDistance { get; }

//        int TotalRealTime { get; }

//        int TotalDrivingTime { get; }

//        double TotalDrivenDistance { get; }

//        int ActualSpeed { get; }

//        double TripAverageSpeed { get; }

//        double TotalAverageSpeed { get; }

//        double ActualConsumptionByTime { get; }

//        double ActualConsumptionByDistance { get; }

//        double TripAverageConsumptionByTime { get; }

//        double TotalAverageConsumptionByTime { get; }

//        double TripAverageConsumptionByDistance { get; }

//        double TotalAverageConsumptionByDistance { get; }

//        int EstimatedRange { get; }

//        void TripReset();

//        void TotalReset();
//    }


//    public class OnBoardComputer : IOnBoardComputer // car #3
//    {
//        private IDrivingProcessor drivingProcessor;

//        public int TripRealTime => throw new NotImplementedException();

//        public int TripDrivingTime => throw new NotImplementedException();

//        public int TripDrivenDistance => throw new NotImplementedException();

//        public int TotalRealTime => throw new NotImplementedException();

//        public int TotalDrivingTime => throw new NotImplementedException();

//        public int TotalDrivenDistance => throw new NotImplementedException();

//        public double TripAverageSpeed => throw new NotImplementedException();

//        public double TotalAverageSpeed => throw new NotImplementedException();

//        public int ActualSpeed => drivingProcessor.ActualSpeed;

//        public double ActualConsumptionByTime => throw new NotImplementedException();

//        public double ActualConsumptionByDistance => throw new NotImplementedException();

//        public double TripAverageConsumptionByTime => throw new NotImplementedException();

//        public double TotalAverageConsumptionByTime => throw new NotImplementedException();

//        public double TripAverageConsumptionByDistance => throw new NotImplementedException();

//        public double TotalAverageConsumptionByDistance => throw new NotImplementedException();

//        public int EstimatedRange => throw new NotImplementedException();

//        public void ElapseSecond()
//        {
//            throw new NotImplementedException();
//        }

//        public void TotalReset()
//        {
//            throw new NotImplementedException();
//        }

//        public void TripReset()
//        {
//            throw new NotImplementedException();
//        }
//    }

//    public class OnBoardComputerDisplay : IOnBoardComputerDisplay // car #3
//    {
//        public int TripRealTime => throw new NotImplementedException();

//        public int TripDrivingTime => throw new NotImplementedException();

//        public double TripDrivenDistance => throw new NotImplementedException();

//        public int TotalRealTime => throw new NotImplementedException();

//        public int TotalDrivingTime => throw new NotImplementedException();

//        public double TotalDrivenDistance => throw new NotImplementedException();

//        public int ActualSpeed => throw new NotImplementedException();

//        public double TripAverageSpeed => throw new NotImplementedException();

//        public double TotalAverageSpeed => throw new NotImplementedException();

//        public double ActualConsumptionByTime => throw new NotImplementedException();

//        public double ActualConsumptionByDistance => throw new NotImplementedException();

//        public double TripAverageConsumptionByTime => throw new NotImplementedException();

//        public double TotalAverageConsumptionByTime => throw new NotImplementedException();

//        public double TripAverageConsumptionByDistance => throw new NotImplementedException();

//        public double TotalAverageConsumptionByDistance => throw new NotImplementedException();

//        public int EstimatedRange => throw new NotImplementedException();

//        public void TotalReset()
//        {
//            throw new NotImplementedException();
//        }

//        public void TripReset()
//        {
//            throw new NotImplementedException();
//        }
//    }


//}
