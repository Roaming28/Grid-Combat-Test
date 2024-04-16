using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using GridFiles;

[CreateAssetMenu(fileName = "Block Config", menuName = "ScriptableObjects/Block Config", order = 1)]
public class BlockConfig : ScriptableObject{
    private string[] _blockTypes = {
        "Obstacle",
        "Effect"
    };

    [SerializeField] private string _name;
    [Dropdown("_blockTypes")]
    [SerializeField] private string _type;
    [SerializeField] private Sprite _appearance;
    [SerializeField] private bool _blocksMelee;
    [SerializeField] private bool _blocksRanged;
    [SerializeField] private bool _blocksSupport;
    [SerializeField] private bool _blocksMovement;
    [SerializeField] private StatusEffect _statusEffects;

    public string Name { get => _name; set => _name = value; }
    public bool BlocksMelee { get => _blocksMelee; set => _blocksMelee = value; }
    public bool BlocksRanged { get => _blocksRanged; set => _blocksRanged = value; }
    public bool BlocksSupport { get => _blocksSupport; set => _blocksSupport = value; }
    public bool BlocksMovement { get => _blocksMovement; set => _blocksMovement = value; }
    public StatusEffect StatusEffects { get => _statusEffects; set => _statusEffects = value; }
    public string Type { get => _type; set => _type = value; }
    public Sprite Appearance { get => _appearance; set => _appearance = value; }
}
