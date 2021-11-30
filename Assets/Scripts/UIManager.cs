using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject turnIndicatorR;
    public GameObject turnIndicatorL;
    public Text scoreTextLeft;
    public Text scoreTextRight;
    public Text turnsLeft;
    //true means its team1's turn, false means its team2's turn
 
    private static UIManager instance;
    
    private void Awake(){
        instance = this; 
        //used to test UI
        // updateScoreText(true, 4);
        // updateTurnsLeft(39);
        // setTurnIndicator(true);
        // setTurnIndicator(false);
        // setTurnIndicator(true);

    }

    private void updateScoreText(bool isTeam1, int score){
        if(isTeam1){
            scoreTextLeft.text = score.ToString();
        }
        else{
            scoreTextRight.text = score.ToString();
        }

    }

    private void updateTurnsLeft(int turns){
        turnsLeft.text = turns.ToString();
    }

    
    private void setTurnIndicator(bool isTeam1){
        if(isTeam1){
            turnIndicatorR.SetActive(false);
            turnIndicatorL.SetActive(true);
        }
        else{
            turnIndicatorR.SetActive(true);
            turnIndicatorL.SetActive(false);
        }
    }
    /*
    * Updates the score text for either team depending on the bool parameter
    * (true for team1, false for team2) takes an int for the score to be updated.
    */
    public static void updateScoreText_Static(bool isTeam1, int score){
        instance.updateScoreText(isTeam1, score);
    }
    /*
    * Updates the turn counter with a specific number (int turns) 
    */
    public static void updateTurnsLeft_Static(int turns){
        instance.updateTurnsLeft(turns);
    }

    /*
    * Sets the turn indicator for Team1 to on with true, and Team2 with false   
    */
    public static void setTurnIndicator_Static(bool isTeam1){
        instance.setTurnIndicator(isTeam1);
    }

  
    
}