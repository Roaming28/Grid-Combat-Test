using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour{

    [Header("Item")]
    [TextAreaAttribute]
    [SerializeField] private string description;

    [SerializeField] private Stats stats;

    public Stats Stats { get => stats; set => stats = value; }
}
