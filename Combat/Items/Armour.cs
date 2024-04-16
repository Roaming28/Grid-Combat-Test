using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armour : Item{
    
    private enum Type {
        Headwear,
        UpperBody,
        LowerBody,
        Footwear,
        Talisman,
        Trinket,
        Charm
    }

    [Header("Armour")]
    [SerializeField] private Type armourType;

    [Tooltip("Skills and moves that the player will be able to use as long as they have this armour piece equiped")]
    [SerializeField] private Moveset attachedSkills;

    private string ArmourType { get => armourType.ToString(); set => armourType = (Type)System.Enum.Parse( typeof(Type), value); }
    public Moveset AttachedSkills { get => attachedSkills; set => attachedSkills = value; }
}
