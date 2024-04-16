using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridFiles;

public class CombatGrid : MonoBehaviour{
    
    private Vector2Int _dimensions;
    private CombatSquare[,] _combatGrid = null;
    private GameObject _combatSquarePrefab = null;

    public Vector2Int Dimensions { get => _dimensions; set => _dimensions = value; }

    public void Initialize(Vector2Int dimensions, GameObject combatSquarePrefab) {
        Dimensions = dimensions;
        _combatSquarePrefab = combatSquarePrefab;

        _combatGrid = new CombatSquare[Dimensions.x, Dimensions.y];

        transform.position = Vector3.zero - new Vector3(Dimensions.x/2, Dimensions.y/2, 0);

        for(int x=0; x<dimensions.x; x++) {
            for(int y=0; y<dimensions.y; y++) {
                GameObject combatSquare = Instantiate(_combatSquarePrefab, transform);
                combatSquare.transform.position = transform.position + new Vector3(x, y, 0);
                combatSquare.transform.GetComponent<CombatSquare>().Coordinates = new Vector2Int(x, y);
                _combatGrid[x, y] = combatSquare.transform.GetComponent<CombatSquare>();
            }
        }
    }

    public void SetDefaultStates(GridSaveFormat gridData) {
        int counter = 0;
        for(int x=0; x<_dimensions.x; x++) {
            for(int y=0; y<_dimensions.y; y++) {
                _combatGrid[x,y].InitialState = gridData.squares[counter].state;
                counter++;
            }
        }
    }

    public void PlaceBlock(Vector2Int position, BlockConfig block) {
        _combatGrid[position.x, position.y].AddBlock(block);
    }

    public List<CombatSquare> GetSpawnsByTeam(string teamName) {
        List<CombatSquare> teamSquares = new List<CombatSquare>();
        for(int x=0; x<_dimensions.x; x++) {
            for(int y=0; y<_dimensions.y; y++) {
                if (_combatGrid[x,y].InitialState == teamName) {
                    teamSquares.Add(_combatGrid[x,y]);
                }
            }
        }
        return(teamSquares);
    }
}
