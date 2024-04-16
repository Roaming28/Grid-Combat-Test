using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour{
    
    /* Actor
     * Can be loaded into the turn stack
     * Makes a move
     * Has a position
     * Subclasses will be fighter, obstacle.
    */

    public abstract void InitiateTurn();
    public abstract void EndTurn();
}
