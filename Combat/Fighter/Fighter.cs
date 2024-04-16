using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Fighter : Actor{

    private string[] teams = {
        "Player",
        "Enemy"
    };
    
    [Dropdown("teams")]
    [SerializeField] private string _team;
    [SerializeField] private bool _playerControlled;
    [SerializeField] private Stats stats = null;

    [SerializeField] private MoveConfig _standardMove = null;
    [SerializeField] private MoveConfig[] _moves = null;

    public string Team { get => _team; set => _team = value; }
    public Stats FighterStats { get => stats; set => stats = value; }

    public override void InitiateTurn() {
        StartCoroutine(MakeTurn());
    }

    public IEnumerator MakeTurn() {
        if (_playerControlled) {
            //Make calls to UI on movetype
            //All moves should share an overall class so that the UI can handle the selection and telling the difference and this here can just take a move and execute it regardless of type
            //Select type of move
            //Select move
            //Select
        } else {

        }
        yield break;
    }


    public void MakeMoveAI() {

    }

    public override void EndTurn() {
        CombatManager.Instance.Order.Enqueue(this);
        CombatManager.Instance.NextTurn = true;
    }
}
