using jbDEV_Eternal.Api.Shared;

namespace jbDEV_Eternal.Domain.Entities
{
    public class Character : Entity
    {
        protected Character() : base()
        {

        }

        public Character(string name, int hitPoints, int strength, int defense, int intelligence, EnumCharacterClass characterClass)
        {
            Name = name;
            HitPoints = hitPoints;
            Strength = strength;
            Defense = defense;
            Intelligence = intelligence;
            CharacterClass = characterClass;
        }

        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }
        public EnumCharacterClass CharacterClass { get; set; }
    }
}
