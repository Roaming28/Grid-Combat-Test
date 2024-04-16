using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item{

    private enum Type {
        Drink,
        Food,
    }

    [Header("Consumable")]
    [SerializeField] private Type consumableType;
    [SerializeField] private int duration;

    private string ConsumableType { get => consumableType.ToString(); set => consumableType = (Type)System.Enum.Parse( typeof(Type), value); }
    public int Duration { get => duration; set => duration = value; }
}
