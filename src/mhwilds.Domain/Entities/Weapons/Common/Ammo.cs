﻿namespace mhwilds.Domain.Entities.Weapons.Common
{
    public class Ammo
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Level { get; set; }
        public int Capacity { get; set; }
        public bool Rapid { get; set; }
    }
}
