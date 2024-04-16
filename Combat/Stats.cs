using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats{
    //Direct visible stats hp, mp and stamina/resolve
    [SerializeField] private int heart;
    [SerializeField] private int soul;
    [SerializeField] private int will;

    //Effector stats that indirectly effect
    [SerializeField] private int strength;
    [SerializeField] private int dexterity;
    [SerializeField] private int speed;
    [SerializeField] private int resilience;
    [SerializeField] private int intelligence;
    [SerializeField] private int spirit;
    [SerializeField] private int luck;
        
    //Sets and gets bayby!!!!
    public int Heart { get => heart; set => heart = value; }
    public int Soul { get => soul; set => soul = value; }
    public int Will { get => will; set => will = value; }

    public int Strength { get => strength; set => strength = value; }
    public int Dexterity { get => dexterity; set => dexterity = value; }
    public int Speed { get => speed; set => speed = value; }
    public int Resilience { get => resilience; set => resilience = value; }
    public int Intelligence { get => intelligence; set => intelligence = value; }
    public int Spirit { get => spirit; set => spirit = value; }
    public int Luck { get => luck; set => luck = value; }
}
