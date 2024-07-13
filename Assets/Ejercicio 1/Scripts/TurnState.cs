using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurnState
{
    public abstract int ReturnColumnChosen();
}

public class PlayerTurn : TurnState
{
    public override int ReturnColumnChosen()
    {
        return Input.anyKeyDown ? int.Parse(Input.inputString) : 0;
    }
}

public class EnemyTurn : TurnState
{
    public override int ReturnColumnChosen()
    {
        return Random.Range(1, 7);
    }
}