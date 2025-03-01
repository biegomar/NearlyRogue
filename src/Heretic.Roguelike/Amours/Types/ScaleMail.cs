﻿namespace Heretic.Roguelike.Amours.Types;

public class ScaleMail : IArmourType
{
    public string Name => nameof(ScaleMail);
    
    public Armour Create(sbyte amorClass)
    {
        return new Armour
        {
            Type = Name,
            Flag = ArmourFlag.IsKnown, 
            Count = 1, 
            AmorClass = amorClass 
        };
    }
}