using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using GridFiles;

public class CombatManager : MonoBehaviour{
    public static CombatManager Instance { get; private set; }

    /*
     * TODO: In Order
     * Set background - Done
     * Setup the grid - Done
     * Place any obstacles or blocks - Done
     * Place fighters
     * Decide figher order based on fighter speed and first strike
     * Take turns
    */

    [Header("Manager")]
    [SerializeField] private CombatConfig _combatConfig = null;
    [SerializeField] private CombatGrid _combatGrid = null;
    
    [Header("Field")]
    [SerializeField] private GameObject _combatSquarePrefab = null;
    [SerializeField] private BlockConfig[] _potentialBlocks = null;

    [Header("Fighters")]
    [SerializeField] private GameObject _fighterParent = null;
    private List<Fighter> _fighters = null;
    private Queue<Actor> _order;

    public Queue<Actor> Order { get => _order; set => _order = value; }

    /* Design
     * Manager contains a grid and fighters.
     * Grid is made up of squares. Squares have states and contain a reference to what is on the square (player, obstacle, etc.)
     * A squares coordinates equals its index within a multidimensional array
     * 
    */

    void Awake() {
        if(Instance == null){
            Instance = this;
        } else {
            Destroy(this);
        }
    }
    
    private bool _nextTurn = false;
    public bool NextTurn { get => _nextTurn; set => _nextTurn = value; }

    void Start() {
        _fighters = new List<Fighter>();
        _order = new Queue<Actor>();

        SetAesthetic();
        InitializeGrid();
        PlaceObstacles();
        PlaceFighters();
        InitializeOrder();

        _nextTurn = true;
    }

    void Update() {
        if (_nextTurn) {
            ExecuteTurn();
            _nextTurn = false;
        }
    }
    
    //Strictly aesthetic
    private void SetAesthetic() {
        //Set background
        //Set music
    }

    //Places the squares
    private void InitializeGrid() {
        _combatConfig.ReadGridData();
        _combatGrid.Initialize(_combatConfig.GridData.dimensions, _combatSquarePrefab);
        _combatGrid.SetDefaultStates(_combatConfig.GridData);
    }

    //Places obstacles and effects
    private void PlaceObstacles() {
        //Loop through grid and place each obstacle and effect
        int counter = 0;
        for(int x=0; x<_combatGrid.Dimensions.x; x++) {
            for(int y=0; y<_combatGrid.Dimensions.y; y++) {
                foreach(BlockSaveFormat blockSave in _combatConfig.GridData.squares[counter].blocks) {
                    BlockConfig block = new BlockConfig();
                    foreach(BlockConfig potentialBlock in _potentialBlocks) {
                        if(potentialBlock.Name == blockSave.name) {
                            block = potentialBlock;
                            break;
                        }
                    }
                    if(block != null) _combatGrid.PlaceBlock(new Vector2Int(x,y), block);
                }
                counter++;
            }
        }
    }

    //Places players and enemies
    private void PlaceFighters() {
        //Get spawn squares
        //Set fighter coordinate
        List<Actor> players = new List<Actor>();
        List<Actor> enemies = new List<Actor>();
        foreach(Transform actor in _fighterParent.transform) {
            switch (actor.GetComponent<Fighter>().Team) {
                case("Player"):
                    players.Add(actor.transform.GetComponent<Actor>());
                    break;
                case("Enemy"):
                    enemies.Add(actor.transform.GetComponent<Actor>());
                    break;
                default:
                    break;
            }
            _fighters.Add(actor.transform.GetComponent<Fighter>());
        }
        //Attach fighter to square
        //Set fighter position
        SpawnTeam(players, _combatGrid.GetSpawnsByTeam("playerSpawn"));
        SpawnTeam(enemies, _combatGrid.GetSpawnsByTeam("enemySpawn"));
    }
    private void SpawnTeam(List<Actor> fighters, List<CombatSquare> squares) {
        foreach(Actor fighter in fighters) {
            int i = 0;
            squares[i].CurrentActor = fighter;
            fighter.transform.position = squares[i].transform.position;
            squares.RemoveAt(i);
        }
    }

    //Adds players, enemies and blocks with effects/turns to an order stack
    private void InitializeOrder(string firstStrike="Player") {
        //First strike and charactor speed
        bool flag = true;
        int highestSpeed = int.MaxValue;
        int speedOffset = 10;
        while(flag) {
            Fighter nextFastestFighter = null;
            int nextHighestSpeed = 0;
            flag = false;
            foreach(Fighter fighter in _fighters) {
                speedOffset = fighter.Team == firstStrike ? 10 : 0;
                if ((fighter.FighterStats.Speed+speedOffset) > nextHighestSpeed && (fighter.FighterStats.Speed+speedOffset)  < highestSpeed) {
                    nextFastestFighter = fighter;
                    nextHighestSpeed = (fighter.FighterStats.Speed+speedOffset);
                    flag = true;
                }
            }
            if (flag) {
                Debug.Log(nextFastestFighter);
                _order.Enqueue(nextFastestFighter);
                highestSpeed = nextHighestSpeed;
            }
        }

    }

    //Take from stack and execute turn
    //Take next actor
    //Have them make turn
    //
    private Actor _activeActor = null;
    private void ExecuteTurn() {
        _activeActor = _order.Dequeue();
        _activeActor.InitiateTurn();
    }
}
