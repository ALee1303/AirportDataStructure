using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarmUP
{
    public class Airport
    {
        protected int MaxVehicles;
        private List<AerialVehicle> Vehicles;

        public string AirportCode { get; private set; }

        public Airport(string Code)
            : this(Code, 100)
        {
        }
        public Airport(string Code, int MaxVehicles)
        {
            this.AirportCode = Code;
            this.MaxVehicles = MaxVehicles;
            this.Vehicles = new List<AerialVehicle>();
        }
        public string AllTakeOff()
        {
            if (Vehicles.Count() == 0)
                return string.Format("Airport is empty.");
            StringBuilder sb = new StringBuilder();
            for (int idx = Vehicles.Count()-1; idx >= 0; idx--)
                sb.AppendLine(TakeOff(Vehicles[idx]));
            return sb.ToString();
        }
        public string TakeOff(AerialVehicle a)
        {
            a.TakeOff();
            Vehicles.RemoveAt(-1);
            return string.Format($"{this.GetType()} has taken off.");
        }
        public string Land(AerialVehicle a)
        {
            if (Vehicles.Count() < MaxVehicles)
            {
                a.FlyDown(a.CurrentAltitude);
                Vehicles.Add(a);
                return string.Format($"{a.GetType()} has landed.");
            }
            return string.Format($"Airport {AirportCode} is full.");
        }
        public string Land(List<AerialVehicle> landing)
        {
            StringBuilder sb = new StringBuilder();
            for (int idx = landing.Count()-1; idx >= 0; idx--)
            {
                if (Vehicles.Count() > MaxVehicles)
                    break;
                sb.AppendLine(Land(landing[idx]));
                landing.RemoveAt(idx);
            }
            return sb.ToString();
        }
    }
}
