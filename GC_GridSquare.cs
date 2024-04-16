using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GC_GridSquare : MonoBehaviour{
    [SerializeField] private Color _defaultColour;
    [SerializeField] private Color _damageColour;
    [SerializeField] private Color _startColour;
    [SerializeField] private Color _endColour;
    [SerializeField] private Color _healColour;
    [SerializeField] private Color _playerSpawnColour;
    [SerializeField] private Color _enemySpawnColour;

    /* Required Squares
     * Start Point
     * End Point - no end point means the player doesn't move
     * Damage done
     * Player spawn
     * Enemy Spawn
    */

    /* Click and drag
     * Obstacle
     * Effect - burn, shock, poison
     * Disable Square
    */

    public class ColourState{
        private string _state = "";
        private Color _colour;

        public string State { get => _state; set => _state = value; }
        public Color Colour { get => _colour; set => _colour = value; }

        public ColourState(string state, Color colour) {
            State = state;
            Colour = colour;
        }
    }
    private ColourState[] _baseStates;

    void Start() {
        _choice = 0;
         _baseStates = new ColourState[]{
            new ColourState("default", _defaultColour),
            new ColourState("damage", _damageColour),
            new ColourState("start", _startColour),
            new ColourState("end", _endColour),
            new ColourState("heal", _healColour),
            new ColourState("playerSpawn", _playerSpawnColour),
            new ColourState("enemySpawn", _enemySpawnColour)
        };
    }

    private List<GC_Block> _attachedBlocks = new List<GC_Block>();
    private Dictionary<string, GameObject> _blockDisplays = new Dictionary<string, GameObject>();

    private int _choice = 0;
    
    [SerializeField] private GameObject _blockPrefab = null;

    public List<GC_Block> AttachedBlocks { get => _attachedBlocks; set => _attachedBlocks = value; }

    public void OnSquareClick() {
        if(GridCreator.Instance.CurrentBlock != null) {
            if (!AttachedBlocks.Contains(GridCreator.Instance.CurrentBlock)) {
                GameObject blockDisplay = Instantiate(_blockPrefab, this.transform);
                blockDisplay.name = GridCreator.Instance.CurrentBlock.Name;
                blockDisplay.transform.GetComponent<Image>().sprite = GridCreator.Instance.CurrentBlock.gameObject.transform.GetComponent<Image>().sprite;
                
                AttachedBlocks.Add(GridCreator.Instance.CurrentBlock);
                _blockDisplays[GridCreator.Instance.CurrentBlock.Name] = blockDisplay;
            }else{
                AttachedBlocks.Remove(GridCreator.Instance.CurrentBlock);
                Destroy(_blockDisplays[GridCreator.Instance.CurrentBlock.Name]);
                _blockDisplays.Remove(GridCreator.Instance.CurrentBlock.Name);
            }
        } else {
            _choice++;
            if(_choice >= _baseStates.Length) {
                _choice = 0;
            }
            transform.GetComponent<Image>().color = _baseStates[_choice].Colour;
        }
    }

    public string GetState() {
        return(_baseStates[_choice].State);
    }

    public int GetInformation() {
        return(_choice);
    }
}
