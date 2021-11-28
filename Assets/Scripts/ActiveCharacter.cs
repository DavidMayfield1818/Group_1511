using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCharacter : MonoBehaviour
{
    public CharacterMovement CharacterA;
    public CharacterMovement CharacterB;
    public CharacterMovement CharacterC;
    public CharacterMovement CharacterD;
    public CharacterMovement CharacterE;
    public CharacterMovement CharacterF;

    private state State;
    private state NextState;

    private CharacterMovement curPlayer;

    private enum state{
        TurnA,
        TurnB,
        TurnC,
        TurnD,
        TurnE,
        TurnF,
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

            //reset hasMoved variable
            /*
            switch(gameObject.tag){
                case guard:
                    Guard.hasMoved = false;
                    break;
                case forward:
                    Forward.hasMoved = false;
                    break;
                case center:
                    Center.hasMoved = false;
                    break;    
            }*/

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
    public CharacterMovement getActiveCharacter(){
        return curPlayer;
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
            NextState = state.TurnD;
            curPlayer = CharacterC;
        }
        else if(State == state.TurnD)
        {
            NextState = state.TurnE;
            curPlayer = CharacterD;
        }
        else if(State == state.TurnE)
        {
            NextState = state.TurnF;
            curPlayer = CharacterE;
        }
        else if(State == state.TurnF)
        {
            NextState = state.TurnA;
            curPlayer = CharacterF;
        }
        //Debug.Log(State);
    }
}
