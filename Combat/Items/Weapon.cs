using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item{

    private enum Type {
        Sword,
        Bat,
        Gun,
        Shield
    }

    [Header("Weapon")]
    [SerializeField] private Type weaponType;
    
    [Tooltip("Skills and moves that the player will be able to use as long as they have this weapon equiped")]
    [SerializeField] private Moveset attachedSkills;

    private string WeaponType { get => weaponType.ToString(); set => weaponType = (Type)System.Enum.Parse( typeof(Type), value); }
    public Moveset AttachedSkills { get => attachedSkills; set => attachedSkills = value; }
}
