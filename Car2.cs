using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    public interface ICar
    {
        bool EngineIsRunning { get; }

        void BrakeBy(int speed); // car #2

        void Accelerate(int speed); // car #2

        void EngineStart();

        void EngineStop();

        void FreeWheel(); // car #2

        void Refuel(double liters);

        void RunningIdle();
    }

    public interface IDrivingInformationDisplay // car #2
    {
        int ActualSpeed { get; }
    }

    public interface IDrivingProcessor // car #2
    {
        int ActualSpeed { get; }

        void IncreaseSpeedTo(int speed);

        void ReduceSpeed(int speed);

        double ActualConsumption { get; } // car #3

        void EngineStart(); // car #3

        void EngineStop(); // car #3

    }

    public interface IEngine
    {
        bool IsRunning { get; }

        void Consume(double liters);

        void Start();

        void Stop();
    }

    public interface IFuelTank
    {
        double FillLevel { get; }

        bool IsOnReserve { get; }

        bool IsComplete { get; }

        void Consume(double liters);

        void Refuel(double liters);
    }

    public interface IFuelTankDisplay
    {
        double FillLevel { get; }

        bool IsOnReserve { get; }

        bool IsComplete { get; }
    }

    public interface IOnBoardComputer // car #3
    {
        int TripRealTime { get; }

        int TripDrivingTime { get; }

        int TripDrivenDistance { get; }

        int TotalRealTime { get; }

        int TotalDrivingTime { get; }

        int TotalDrivenDistance { get; }

        double TripAverageSpeed { get; }

        double TotalAverageSpeed { get; }

        int ActualSpeed { get; }

        double ActualConsumptionByTime { get; }

        double ActualConsumptionByDistance { get; }

        double TripAverageConsumptionByTime { get; }

        double TotalAverageConsumptionByTime { get; }

        double TripAverageConsumptionByDistance { get; }

        double TotalAverageConsumptionByDistance { get; }

        int EstimatedRange { get; }

        void ElapseSecond();

        void TripReset();

        void TotalReset();
    }

    public interface IOnBoardComputerDisplay // car #3
    {
        int TripRealTime { get; }

        int TripDrivingTime { get; }

        double TripDrivenDistance { get; }

        int TotalRealTime { get; }

        int TotalDrivingTime { get; }

        double TotalDrivenDistance { get; }

        int ActualSpeed { get; }

        double TripAverageSpeed { get; }

        double TotalAverageSpeed { get; }

        double ActualConsumptionByTime { get; }

        double ActualConsumptionByDistance { get; }

        double TripAverageConsumptionByTime { get; }

        double TotalAverageConsumptionByTime { get; }

        double TripAverageConsumptionByDistance { get; }

        double TotalAverageConsumptionByDistance { get; }

        int EstimatedRange { get; }

        void TripReset();

        void TotalReset();
    }

    public class Engine : IEngine
    {

        private IFuelTank _fuelTank;
        public double Consumption { get; private set; } = 0;
        public List<double> ConsumptionList { get; }

        public bool IsRunning { get; private set; }

        public Engine(IFuelTank fuelTank)
        {
            _fuelTank = fuelTank;
            ConsumptionList = new List<double>();
        }

        public void Consume(double liters)
        {
            if (IsRunning)
            {
                _fuelTank.Consume(liters);
                Consumption += liters;
                ConsumptionList.Add(liters);
                if (_fuelTank.FillLevel == 0)
                {
                    Stop();
                }
            }
        }

        public void Start()
        {
            IsRunning = true;
        }

        public void Stop()
        {
            IsRunning = false;
        }
    }

    public class FuelTank : IFuelTank
    {
        public FuelTank(double liters)
        {
            if (liters <= 60 && liters > 0)
            {
                FillLevel = liters;
            }
            else if (liters < 0)
            {
                FillLevel = 0;
            }
            else if (liters > 60)
            {
                FillLevel = 60;
            }

        }

        public double FillLevel { get; private set; }

        public bool IsOnReserve => FillLevel < 5 ? true : false;

        public bool IsComplete => FillLevel == 60 ? true : false;

        public void Consume(double liters)
        {
            FillLevel -= liters;
        }

        public void Refuel(double liters)
        {
            if (liters > 0)
            {
                if (FillLevel + liters < 60)
                    FillLevel += liters;
                else if (FillLevel + liters >= 60)
                    FillLevel = 60;
            }

        }
    }

    public class FuelTankDisplay : IFuelTankDisplay
    {
        private IFuelTank fuelTank;
        public FuelTankDisplay(IFuelTank tank)
        {
            fuelTank = tank;
        }

        public double FillLevel => System.Math.Round(fuelTank.FillLevel, 2);

        public bool IsOnReserve => fuelTank.IsOnReserve;

        public bool IsComplete => fuelTank.IsComplete;
    }

    public class DrivingInformationDisplay : IDrivingInformationDisplay
    {

        private IDrivingProcessor _drivingProcessor;

        public DrivingInformationDisplay(IDrivingProcessor drivingProcessor)
        {
            _drivingProcessor = drivingProcessor;
        }

        public int ActualSpeed
        {
            get
            {
                return _drivingProcessor.ActualSpeed;
            }
        }
    }

    public class DrivingProcessor : IDrivingProcessor
    {
        private IEngine _engine;
        private readonly int _maxAcceleration;
        public IFuelTank FuelTank;


        public DrivingProcessor(IEngine engine, int maxAcceleration, IFuelTank fuelTank)
        {
            if (maxAcceleration < 5)
            {
                maxAcceleration = 5;
            }
            if (maxAcceleration > 20)
            {
                maxAcceleration = 20;
            }

            _engine = engine;
            _maxAcceleration = maxAcceleration;
            FuelTank = fuelTank;
        }

        public int ActualSpeed { get; private set; } = 0;

        public double ActualConsumption => ActualSpeed;

        public void EngineStart()
        {
            _engine.Start();
        }

        public void EngineStop()
        {
            _engine.Stop();
        }

        public bool IsEngineRunning()
        {
            return _engine.IsRunning;
        }

        public void IncreaseSpeedTo(int speed)
        {

            if (_engine.IsRunning && speed >= ActualSpeed)
            {
                if (speed - ActualSpeed >= _maxAcceleration)
                {
                    if (ActualSpeed + _maxAcceleration <= 250)
                    {
                        ActualSpeed = ActualSpeed + _maxAcceleration;
                    }
                    else
                    {
                        ActualSpeed = 250;
                    }
                }
                else
                {
                    ActualSpeed = speed;
                }

                if (ActualSpeed == 0)
                {
                    _engine.Consume(0.0003);
                }
                if (ActualSpeed >= 1 && ActualSpeed <= 60)
                {
                    _engine.Consume(0.002);
                }
                if (ActualSpeed >= 61 && ActualSpeed <= 100)
                {
                    _engine.Consume(0.0014);
                }
                if (ActualSpeed >= 101 && ActualSpeed <= 140)
                {
                    _engine.Consume(0.002);
                }
                if (ActualSpeed >= 141 && ActualSpeed <= 200)
                {
                    _engine.Consume(0.0025);
                }
                if (ActualSpeed >= 201 && ActualSpeed <= 250)
                {
                    _engine.Consume(0.003);
                }

            }

        }

        public void ReduceSpeed(int speed)
        {

            if (ActualSpeed - speed >= 0)
                if (speed < 10)
                {
                    ActualSpeed -= speed;
                }
                else
                {
                    ActualSpeed -= speed;
                }
        }
        public double Consumption => (_engine as Engine).Consumption;
        public List<double> ConsumptionList => (_engine as Engine).ConsumptionList;
    }

    public class OnBoardComputer : IOnBoardComputer // car #3
    {
        private readonly double _consumption;
        private List<double> _consumptionList;
        public IDrivingProcessor DrivingProcessor { get; set; }

        public OnBoardComputer(IDrivingProcessor drivingProcessor)
        {
            DrivingProcessor = drivingProcessor;
            _consumption= Math.Round((DrivingProcessor as DrivingProcessor).Consumption,10);
            _consumptionList = (DrivingProcessor as DrivingProcessor).ConsumptionList;
        }

        public int TripRealTime { get; private set; } = 0;

        public int TripDrivingTime { get; private set; } = 0;

        public int TripDrivenDistance { get; private set; } = 0;

        public int TotalRealTime { get; private set; } = 0;

        public int TotalDrivingTime { get; private set; } = 0;

        public int TotalDrivenDistance { get; private set; } = 0;

        public double TripAverageSpeed => TripDrivenDistance/TripDrivingTime;

        public double TotalAverageSpeed => TotalDrivenDistance/TotalDrivingTime;

        public int ActualSpeed => DrivingProcessor.ActualSpeed;

        public double ActualConsumptionByTime => Math.Round(DrivingProcessor.ActualConsumption,5);

        public double ActualConsumptionByDistance
        {
            get
            {
                if (TotalDrivenDistance == 0)
                    return 0;
                else
                {
                    return (DrivingProcessor as DrivingProcessor).Consumption * (100/TotalDrivenDistance);
                }
            }
        }

        public double TripAverageConsumptionByTime => (DrivingProcessor as DrivingProcessor).Consumption / TripDrivingTime;

        public double TotalAverageConsumptionByTime => (DrivingProcessor as DrivingProcessor).Consumption / TotalDrivingTime;

        public double TripAverageConsumptionByDistance => (DrivingProcessor as DrivingProcessor).Consumption * TripDrivenDistance;

        public double TotalAverageConsumptionByDistance => (DrivingProcessor as DrivingProcessor).Consumption * TotalDrivenDistance;

        public int EstimatedRange
        {
            get
            {
                double fuel = (DrivingProcessor as DrivingProcessor).FuelTank.FillLevel;
                List<double> top100 = _consumptionList.Skip(Math.Max(0, _consumptionList.Count() - 100)).ToList();
                double sum = top100.Sum();
                return 0;
            }
        }


        public void ElapseSecond()
        {
            if((DrivingProcessor as DrivingProcessor).IsEngineRunning() && DrivingProcessor.ActualSpeed>0)
            {
                TotalDrivingTime++;
                TripDrivingTime++;
                TripDrivenDistance += ActualSpeed;
                TotalDrivenDistance += ActualSpeed;
            }
            TotalRealTime++;
            TripRealTime++;
            
        }

        public void TotalReset()
        {
            TotalDrivingTime = 0;
            TotalRealTime = 0;
            TripDrivingTime = 0;
            TripRealTime = 0;
            TotalDrivenDistance = 0;
        }

        public void TripReset()
        {
            TripDrivingTime = 0;
            TripRealTime = 0;
            TripDrivenDistance = 0;

        }
    }

    public class OnBoardComputerDisplay : IOnBoardComputerDisplay // car #3
    {
        private IOnBoardComputer _onBoardComputer;

        public OnBoardComputerDisplay(IOnBoardComputer computer)
        {
            _onBoardComputer = computer;
        }
        public int TripRealTime => _onBoardComputer.TripRealTime;

        public int TripDrivingTime => _onBoardComputer.TripDrivingTime;

        public double TripDrivenDistance => _onBoardComputer.TripDrivenDistance;

        public int TotalRealTime => _onBoardComputer.TotalRealTime;

        public int TotalDrivingTime => _onBoardComputer.TotalDrivingTime;

        public double TotalDrivenDistance => _onBoardComputer.TotalDrivenDistance;

        public int ActualSpeed => _onBoardComputer.ActualSpeed;

        public double TripAverageSpeed => _onBoardComputer.TripAverageSpeed;

        public double TotalAverageSpeed => _onBoardComputer.TotalAverageSpeed;

        public double ActualConsumptionByTime => _onBoardComputer.ActualConsumptionByTime;

        public double ActualConsumptionByDistance => _onBoardComputer.ActualConsumptionByDistance;

        public double TripAverageConsumptionByTime => _onBoardComputer.TripAverageConsumptionByTime;

        public double TotalAverageConsumptionByTime => _onBoardComputer.TotalAverageConsumptionByTime;

        public double TripAverageConsumptionByDistance => _onBoardComputer.TripAverageConsumptionByDistance;

        public double TotalAverageConsumptionByDistance => _onBoardComputer.TotalAverageConsumptionByDistance;

        public int EstimatedRange => _onBoardComputer.EstimatedRange;

        public void TotalReset()
        {
            _onBoardComputer.TotalReset();
        }

        public void TripReset()
        {
            _onBoardComputer.TripReset();
        }
    }
    public class Car : ICar
    {

        public IFuelTankDisplay fuelTankDisplay;
        private IEngine engine;
        private IFuelTank fuelTank;
        private IDrivingProcessor drivingProcessor;
        public IDrivingInformationDisplay drivingInformationDisplay;
        private IOnBoardComputer onBoardComputer; // car #3
        public IOnBoardComputerDisplay onBoardComputerDisplay; // car #3
        


        public Car(double fuelLevel = 20, int maxAcceleration = 10) // car #2
        {

            fuelTank = new FuelTank(fuelLevel);
            engine = new Engine(fuelTank);
            fuelTankDisplay = new FuelTankDisplay(fuelTank);
            drivingProcessor = new DrivingProcessor(engine, maxAcceleration,fuelTank);
            drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);
            onBoardComputer = new OnBoardComputer(drivingProcessor);
            onBoardComputerDisplay = new OnBoardComputerDisplay(onBoardComputer);

        }

        public bool EngineIsRunning => engine.IsRunning;

        public void EngineStart()
        {
            if (fuelTank.FillLevel > 0)
            {
                engine.Start();

                onBoardComputer.ElapseSecond();
            }
        }

        public void EngineStop()
        {
            engine.Stop();
            onBoardComputer.ElapseSecond();
        }

        public void Refuel(double liters)
        {
            fuelTank.Refuel(liters);

        }

        public void RunningIdle()
        {
            if (engine.IsRunning)
            {
                fuelTank.Consume(0.0003);
       

            }
            if (fuelTank.FillLevel <= 0)
            {
               
                engine.Stop();
                
            }
            onBoardComputer.ElapseSecond();
        }

        public void BrakeBy(int speed)
        {
            if (drivingInformationDisplay.ActualSpeed - speed >= 0)
                if (speed < 10)
                {
                    drivingProcessor.ReduceSpeed(speed);
                }
                else
                {
                    drivingProcessor.ReduceSpeed(10);
                }
            onBoardComputer.ElapseSecond();

        }

        public void Accelerate(int speed)
        {
            drivingProcessor.IncreaseSpeedTo(speed);
            if (speed < drivingInformationDisplay.ActualSpeed)
            {
                FreeWheel();
            }
            if (fuelTankDisplay.FillLevel <= 0)
                engine.Stop();
            onBoardComputer.ElapseSecond();
        }

        public void FreeWheel()
        {
            if (drivingInformationDisplay.ActualSpeed > 0)
                BrakeBy(1);
            else
            {
                RunningIdle();
            }
        }
        static void Main12()
        {
            Car car = new Car();

            car.EngineStart();

            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);

            car.BrakeBy(10);
            car.BrakeBy(10);
            car.BrakeBy(10);


            Console.WriteLine(car.onBoardComputerDisplay.TripAverageConsumptionByDistance);
            //Console.WriteLine(car.onBoardComputerDisplay.TripDrivingTime);
            //Console.WriteLine(car.onBoardComputerDisplay.TotalRealTime);
            //Console.WriteLine(car.onBoardComputerDisplay.TotalDrivingTime);

            Console.ReadLine();
        }
    }
}
