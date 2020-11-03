using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using hb.Business.Types;

namespace hb.Business
{
    public class Field
    {
        public Boundry Boundry;
        public List<Vehicle> Vehicles = new List<Vehicle>();

        public Field(Boundry boundry)
        {
            this.Boundry = boundry;
        }

        public void HandleMoves()
        {
            if (Vehicles == null || Vehicles.Count == 0)
                throw new ArgumentNullException("Vehicles");
            foreach (var vehicle in Vehicles)
            {
                vehicle.HandleMoves();
            }
        }

        public bool IsValid()
        {
            return !this.Vehicles.Any(v => v.Pos.X > Boundry.X || v.Pos.Y > Boundry.Y);
        }
    }
}
