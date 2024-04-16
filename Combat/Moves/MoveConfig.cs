using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using GridFiles;

[CreateAssetMenu(fileName = "Move Config", menuName = "ScriptableObjects/Move Config", order = 0)]
public class MoveConfig : ScriptableObject{
    private string[] _moveTypes = {
        "Move",
        "Attack",
        "Item",
        "Ability"
    };

    [SerializeField] private TextAsset _moveGrid = null;
    private List<Effect> _relativeMoveGrid;
    private Vector2Int _startPosition;
    private Vector2Int _endPosition;

    [Dropdown("_moveTypes")]
    [SerializeField] private string _moveType;

    public TextAsset MoveGrid { get => _moveGrid; set => _moveGrid = value; }
    public string MoveType { get => _moveType; set => _moveType = value; }
    public List<Effect> RelativeMoveGrid { get => _relativeMoveGrid; set => _relativeMoveGrid = value; }

    void OnEnable() {
        JsonGridHelper reader = new JsonGridHelper();
        GridSaveFormat gridSave = reader.ReadFromJson(_moveGrid);

        //Find start point if exists.
        //Otherwise assume start point is center.
        int xStart = (int)gridSave.dimensions.x/2;
        int yStart = (int)gridSave.dimensions.y/2;
        int counter = 0;
        for(int x=0; x<gridSave.dimensions.x; x++) {
            for(int y=0; y<gridSave.dimensions.y; y++) {
                if(gridSave.squares[counter].state == "start") {
                    xStart = x;
                    yStart = y;
                    _startPosition = new Vector2Int(x, y);
                }else if (gridSave.squares[counter].state == "end") {
                    _endPosition = new Vector2Int(x, y);
                }
                counter++;
            }
        }

        //Find all affects squares and assign their relative cooridnates to _moveGrid
        counter = 0;
        for(int x=0; x<gridSave.dimensions.x; x++) {
            for(int y=0; y<gridSave.dimensions.y; y++) {
                Effect effect = new Effect(gridSave.squares[counter].state);
                effect.RelativeCoordinates = new Vector2Int(x-xStart, y-yStart);
                foreach(BlockSaveFormat block in gridSave.squares[counter].blocks) {
                    effect.Blocks.Add(block.name);
                }
                _relativeMoveGrid.Add(effect);
                counter++;
            }
        }
    }
}
