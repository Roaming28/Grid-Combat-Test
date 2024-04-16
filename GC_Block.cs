using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class GC_Block : MonoBehaviour{
    [SerializeField] private string name = "";

    [SerializeField] private bool _blocksMelee = false;
    [SerializeField] private bool _blocksRanged = false;
    [SerializeField] private bool _blocksSupport = false;
    [SerializeField] private bool _blocksMovement = false; //Includes knockback

    [SerializeField] private bool _hasStatusEffects = false;
    [ShowIf("_hasStatusEffects")]
    [SerializeField] private StatusEffect _statusEffects = null;

    public string Name { get => name; set => name = value; }
    public bool BlocksMelee { get => _blocksMelee; set => _blocksMelee = value; }
    public bool BlocksRanged { get => _blocksRanged; set => _blocksRanged = value; }
    public bool BlocksSupport { get => _blocksSupport; set => _blocksSupport = value; }
    public bool BlocksMovement { get => _blocksMovement; set => _blocksMovement = value; }
    public StatusEffect StatusEffects { get => _statusEffects; set => _statusEffects = value; }

    public void OnSelect() {
        GridCreator.Instance.CurrentBlock = this;
    }
}
