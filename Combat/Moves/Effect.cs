using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour{
    //The effect of a move
    //Can be damage, healing, movement, placement of block

    private string _type;
    private Vector2Int _relativeCoordinates;
    private int _damage = 0;
    private List<string> _blocks = null;

    public string Type { get => _type; set => _type = value; }
    public Vector2Int RelativeCoordinates { get => _relativeCoordinates; set => _relativeCoordinates = value; }
    public int Damage { get => _damage; set => _damage = value; }
    public List<string> Blocks { get => _blocks; set => _blocks = value; }

    public Effect(string type) {
        _type = type;
    }
}