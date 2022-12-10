using System;
using System.Collections.Generic;

namespace dotNetExercise.Models
{
    public partial class Claim
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public DateOnly Date { get; set; }
        public string Description { get; set; } = null!;

        public virtual Vehicle Vehicle { get; set; } = null!;
    }
}
