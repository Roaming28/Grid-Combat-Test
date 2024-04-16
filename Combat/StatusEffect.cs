using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatusEffect{
    
    [SerializeField] private int _burn = 0;
    [SerializeField] private int _frost = 0;
    [SerializeField] private int _shock = 0;
    [SerializeField] private int _poison = 0;
    [SerializeField] private int _stop = 0;
    [SerializeField] private int _slow = 0;
    [SerializeField] private int _curse = 0;

    public int Burn { get => _burn; set => _burn = value; }
    public int Frost { get => _frost; set => _frost = value; }
    public int Shock { get => _shock; set => _shock = value; }
    public int Poison { get => _poison; set => _poison = value; }
    public int Stop { get => _stop; set => _stop = value; }
    public int Slow { get => _slow; set => _slow = value; }
    public int Curse { get => _curse; set => _curse = value; }

}
