using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Block : MonoBehaviour{
    [ShowNonSerializedField]
    private string _name = "";
    [ShowNonSerializedField]
    private string _type = "";
    private bool _blocksMelee;
    private bool _blocksRanged;
    private bool _blocksSupport;
    private bool _blocksMovement;
    private StatusEffect _statusEffects;

    public string Name { get => _name; set => _name = value; }
    public bool BlocksMelee { get => _blocksMelee; set => _blocksMelee = value; }
    public bool BlocksRanged { get => _blocksRanged; set => _blocksRanged = value; }
    public bool BlocksSupport { get => _blocksSupport; set => _blocksSupport = value; }
    public bool BlocksMovement { get => _blocksMovement; set => _blocksMovement = value; }
    public StatusEffect StatusEffects { get => _statusEffects; set => _statusEffects = value; }
    public string Type { get => _type; set => _type = value; }

    public void SetValues(BlockConfig values) {
        _name = values.Name;
        _type = values.Type;
        _blocksMelee = values.BlocksMelee;
        _blocksRanged = values.BlocksRanged;
        _blocksSupport = values.BlocksSupport;
        _blocksMovement = values.BlocksMovement;
        _statusEffects = values.StatusEffects;
    }
}
