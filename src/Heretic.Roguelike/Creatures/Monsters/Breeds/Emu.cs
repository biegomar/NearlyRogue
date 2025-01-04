﻿using System.Collections.Generic;
using Heretic.Roguelike.ArtificialIntelligence.Movements;
using Heretic.Roguelike.Dices;

namespace Heretic.Roguelike.Creatures.Monsters.Breeds;

public class Emu : IMonsterBreed
{
    public string Name => nameof(Emu);
    
    public Monster<T> Spawn<T>(IMotionController<T> motionController, T icon)
    {
        byte expLevel = 1;
        var initialHitPoints = Dice.D8.Roll(expLevel);
        
        DiceThrow diceThrow = new(1, Dice.D2);
        ushort strength = Dice.Roll(diceThrow);
        
        return new(motionController)
        {
            Breed = Name,
            ExperienceLevel = expLevel,
            Experience = 2,
            Flags = MonsterFlag.Mean,
            TreasurePercentage = 0,
            AmourClass = 7,
            Strength = strength,
            MaxStrength = strength,
            HitPoints = initialHitPoints,
            MaxHitPoints = initialHitPoints,
            Damage = new List<DiceThrow>() {diceThrow},
            Icon = icon
        };
    }
}