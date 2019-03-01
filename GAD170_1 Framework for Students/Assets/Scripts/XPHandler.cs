using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for converting a battle result into xp to be awarded to the player.
/// 
/// TODO:
///     Respond to battle outcome with xp calculation based on;
///         player win 
///         how strong the win was
///         stats/levels of the dancers involved
///     Award the calculated XP to the player stats
///     Raise the player level up event if needed
/// </summary>
public class XPHandler : MonoBehaviour
{
    private void OnEnable()
    {
        GameEvents.OnBattleConclude += GainXP;
    }

    private void OnDisable()
    {
        GameEvents.OnBattleConclude -= GainXP;
    }

    public void GainXP(BattleResultEventData data)
    {
        //Player multiplier
        int playerCalMulti = Random.Range(1, data.player.luck + 1);

        //How much xp the player gains 
        if (data.outcome == 1)
        {
            data.player.xp += data.player.rhythm + data.player.style + playerCalMulti;
        }
        else
        {
            data.player.xp += (data.player.rhythm + data.player.style + playerCalMulti)/2;
        }
        //Debug.Log(data.outcome);
        //Debug.Log(data.player.xp);
        //Debug.Log(data.npc.xp);
        
        //Seeing if the player can level up
        int xpMax = data.player.level * 75 + 30;
        if (data.player.xp >= xpMax)
        {
            data.player.xp = data.player.xp - xpMax;
            data.player.level++;

            GameEvents.PlayerLevelUp(data.player.level);
            int numPoints = 12;
            StatsGenerator.AssignUnusedPoints(data.player, numPoints);
        }
        // DON'T USE THIS CODE - makes player level 500
        // data.player.level = 500

        //data.player.xp += 1; // add 1 xp to the player

        // check if the player leveled up
        // if they leveled up run this code - it makes NPCs level up
        

        // when player levels up, call these lines to add points to stats
        
    }
}
