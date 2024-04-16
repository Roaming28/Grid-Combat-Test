using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class CombatSquare : MonoBehaviour{
  
    private Actor _currentActor = null;
    public Actor CurrentActor { get => _currentActor; set => _currentActor = value; }

    private List<Block> _blocks = null;
    [SerializeField] private GameObject _blockPrefab;
    
    [Foldout("State Colours")]
    [SerializeField] private Color _defaultColour;
    [Foldout("State Colours")]
    [SerializeField] private Color _potentialColour;
    [Foldout("State Colours")]
    [SerializeField] private Color _attackColour;
    [Foldout("State Colours")]
    [SerializeField] private Color _movementColour;

    [ShowNonSerializedField]
    private string _initialState = "";
    public string InitialState { get => _initialState; set => _initialState = value; }
    
    [ShowNonSerializedField]
    private Vector2Int _coordinates;
    public Vector2Int Coordinates { get => _coordinates; set => _coordinates = value; }

    private string _state = "default";
    public string State { 
        get {
            return _state;
        } 
        set {
            _state = value;
            switch (_state) {
                case "potential":
                    GetComponent<SpriteRenderer>().color = _potentialColour;
                    break;
                case "attack":
                    GetComponent<SpriteRenderer>().color = _attackColour;
                    break;
                case "movement":
                    GetComponent<SpriteRenderer>().color = _movementColour;
                    break;
                default:
                    break;
            }
        }
    }

    void Awake() {
        _blocks = new List<Block>();
    }

    public void AddBlock(BlockConfig block) {
        bool contains = false;
        if(_blocks.Count > 0) {
            foreach(Block b in _blocks) {
                if(b.Name == block.name) {
                    contains = true;
                    break;
                }
            }
        }
        if (!contains) {
            GameObject blockObject = Instantiate(_blockPrefab, this.transform);
            blockObject.transform.localPosition = new Vector3(0,0,0);
            blockObject.transform.GetComponent<Block>().SetValues(block);
            blockObject.transform.GetComponent<SpriteRenderer>().sprite = block.Appearance;
            _blocks.Add(blockObject.transform.GetComponent<Block>());
        }
    }
}
