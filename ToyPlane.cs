using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarmUP
{
    public class ToyPlane : Airplane
    {
        public bool IsWoundUP { get; set; }

        public ToyPlane():
            base(50)
        { }

        public override string About()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(base.About());
            if (!IsWoundUP)
                sb.AppendLine($"{this.GetType()} is not wound up");
            else
                sb.AppendLine($"{this.GetType()} is wound up");

            return sb.ToString();
        }

        protected string getWindUpString()
        {
            if (!IsWoundUP)
                return String.Format($"{this.GetType()} can't start its engine it's not wound up");
            return getEngineStartedString();
        }

        public override void StartEngine()
        {
            if (!IsWoundUP)
                return;
            Engine.Start();
        }

        public override string TakeOff()
        {
            if (!IsFlying)
                return getWindUpString();
            else
                return String.Format($"{this.GetType()} is already flying");
        }

        public void Unwind()
        {
            if(!IsFlying)
                IsWoundUP = false;
        }

        public void WindUp()
        {
            if (!IsFlying)
                IsWoundUP = true;
        }
    }
}
