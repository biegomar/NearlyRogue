﻿using System.Collections.Generic;
using Heretic.Roguelike.ArtificialIntelligence.Movements;
using Heretic.Roguelike.Dices;

namespace Heretic.Roguelike.Creatures.Monsters.Breeds;

public class Rattlesnake : IMonsterBreed
{
    public string Name => nameof(Rattlesnake);
    
    public Monster<T> Spawn<T>(IMotionController<T> motionController, T icon)
    {
        byte expLevel = 2;
        DiceThrow diceThrow = new(1, Dice.D6);
        
        return new(motionController)
        {
            Breed = Name,
            ExperienceLevel = expLevel,
            Experience = 9,
            Flags = MonsterFlag.Mean,
            TreasurePercentage = 0,
            AmorClass = 3,
            Strength = 10,
            HitPoints = Dice.D8.Roll(expLevel),
            Damage = new List<DiceThrow>() {diceThrow},
            Icon = icon
        };
    }
}