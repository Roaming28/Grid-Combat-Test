using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Moveset{
    //Movement around the field
    [SerializeField] private GameObject[] movements;
    //Direct damage led moves
    [SerializeField] private GameObject[] attacks;
    //Support led moves
    [SerializeField] private GameObject[] supports;
    //Fall into none of the above
    [SerializeField] private GameObject[] skills;

    //Set and that other thing I can't remember
    public GameObject[] Movements { get => movements; set => movements = value; }
    public GameObject[] Attacks { get => attacks; set => attacks = value; }
    public GameObject[] Supports { get => supports; set => supports = value; }
    public GameObject[] Skills { get => skills; set => skills = value; }
}
