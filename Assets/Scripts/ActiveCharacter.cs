using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCharacter : MonoBehaviour
{
    public CharacterMovement CharacterA;
    public CharacterMovement CharacterB;
    public CharacterMovement CharacterC;

    private state State;
    private state NextState;

    private CharacterMovement curPlayer;

    private enum state{
        TurnA,
        TurnB,
        TurnC,
    }

    // Start is called before the first frame update
    void Start()
    {
        updateState(state.TurnA);
        Activate(curPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        if(CheckTaken(curPlayer))
        {
            Deactivate(curPlayer);
            updateState(NextState);
            Activate(curPlayer);
        }

    }

    void Activate(CharacterMovement Char)
    {
        Char.curTurn = true;
    }

    void Deactivate(CharacterMovement Char)
    {
        Char.curTurn = false;
        Char.takenTurn = false;
    }

    bool CheckTaken(CharacterMovement Char)
    {
        if(Char.curTurn && Char.takenTurn){
            return true;
        }
        return false;
    }

    void updateState(state newState)
    {
        State = newState;
        if(State == state.TurnA)
        {
            NextState = state.TurnB;
            curPlayer = CharacterA;
        }
        else if(State == state.TurnB)
        {
            NextState = state.TurnC;
            curPlayer = CharacterB;
        }
        else if(State == state.TurnC)
        {
            NextState = state.TurnA;
            curPlayer = CharacterC;
        }
        //Debug.Log(State);
    }
}
