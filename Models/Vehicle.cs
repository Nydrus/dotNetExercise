using System;
using System.Collections.Generic;

namespace dotNetExercise.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Claims = new HashSet<Claim>();
        }

        public int IdVehicles { get; set; }
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int OwnerId { get; set; }
        public string? Vehiclescol { get; set; }

        public virtual Owner Owner { get; set; } = null!;
        public virtual ICollection<Claim> Claims { get; set; }
    }
}
