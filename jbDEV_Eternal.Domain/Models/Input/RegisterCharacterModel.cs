using jbDEV_Eternal.Api.Shared;
using System;

namespace jbDEV_Eternal.Domain.Models.Input
{
    public class RegisterCharacterModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }
        public EnumClass Class { get; set; }
    }
}
