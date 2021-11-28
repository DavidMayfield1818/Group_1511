using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public GameObject enemyPlayer;

    public int moves = 3;
    public static bool hasMoved = false;
    
    public int baseShotChance = 80;
    public int shotChance;
    public int basePassChance = 95;
    public int passChance;
    
    public int baseOffReboundChance = 20;
    public int offReboundChance;
    public int baseDefReboundChance = 80;
    public int defReboundChance;

    public int stealChance = 30;

    public void movingShot(){
        if (hasMoved == true){
            shotChance = baseShotChance/2;
        }
        //unless movingshot is done next to the hoop (layup)
    }

    public void movingPass(){
        if (hasMoved == true){
            passChance = basePassChance - 10;
        }
    }

    public void steal(){
        // if this player is one hex from enemyPlayer
        int randVal;
        randVal = Random.Range(0, 100);
        if (randVal < stealChance){
            //this player has possession of the ball
            // Debug.log("success");
        }
    }

    public void distancetoHoop(){
        //40% at the 3 point line (4 hexes distance)
        //80% at the hoop (layup)
        //80%-8*(amount of hexes away from hoop)
        //shotChance = finishedcalculation
    }
}
