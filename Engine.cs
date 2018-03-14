using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarmUP
{
    public class Engine
    {
        public bool IsStarted { get; private set; }

        public Engine()
        {
            IsStarted = false;
        }

        public string About()
        {
            if (!IsStarted)
                return String.Format($"{this.GetType()} is not started.");
            else
                return String.Format($"{this.GetType()} is started.");
        }

        public void Start()
        {
            IsStarted = true;
        }

        public void Stop()
        {
            IsStarted = false;
        }
    }
}
