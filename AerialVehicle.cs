using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarmUP
{
    public abstract class AerialVehicle
    {
        public int CurrentAltitude { get; protected set; }
        public Engine Engine { get; protected set; }
        public bool IsFlying { get; protected set; }
        public int MaxAltitude { get; protected set; }

        public AerialVehicle(int _max)
        {
            CurrentAltitude = 0;
            IsFlying = false;
            Engine = new Engine();
            MaxAltitude = _max;
        }

        public virtual string About()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"\nThis {this.GetType()} has a max altitude of {MaxAltitude}");
            sb.AppendLine($"It's current altitude is {CurrentAltitude}");
            sb.AppendLine($"{Engine.About()}");

            return sb.ToString();
        }

        public void FlyDown()
        {
            FlyDown(1000);
        }

        public void FlyDown(int HowManyFeet)
        {
            if (!Engine.IsStarted || CurrentAltitude - HowManyFeet < 0)
                return;
            CurrentAltitude -= HowManyFeet;
            if (CurrentAltitude == 0) IsFlying = false;
        }

        public void FlyUp()
        {
            FlyUp(1000);
        }

        public void FlyUp(int HowManyFeet)
        {
            if (!Engine.IsStarted || CurrentAltitude + HowManyFeet > MaxAltitude)
                return;
            CurrentAltitude += HowManyFeet;
            IsFlying = true;
        }

        protected string getEngineStartedString()
        {
            if (!Engine.IsStarted)
                return String.Format($"{this.GetType()} can't fly its engine is not started.");
            return String.Format($"{this.GetType()} is flying");
        }

        public virtual void StartEngine()
        {
            Engine.Start();
        }

        public void StopEngine()
        {
            Engine.Stop();
        }

        public virtual string TakeOff()
        {
            if (!IsFlying)
                return getEngineStartedString();
            else
                return String.Format($"{this.GetType()} is already flying");
        }
    }
}
