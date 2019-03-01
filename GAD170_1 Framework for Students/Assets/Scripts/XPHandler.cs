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
        int playerCalMulti = Random.Range(1, data.player.luck + 1);
        //int npcCalMulti = Random.Range(1, data.npc.luck + 1);

        if (data.outcome == 1)
        {
            data.player.xp =+ data.player.rhythm + data.player.style + playerCalMulti;
            //data.npc.xp =+ (data.npc.rhythm + data.npc.style + npcCalMulti)/2;
        }
        else
        {
            data.player.xp =+ (data.player.rhythm + data.player.style + playerCalMulti)/2;
            //data.npc.xp = +data.npc.rhythm + data.npc.style + npcCalMulti;
        }
        //Debug.Log(data.outcome);
        Debug.Log(data.player.xp);
        //Debug.Log(data.npc.xp);

        // DON'T USE THIS CODE - makes player level 500
        // data.player.level = 500;

        //data.player.xp += 1; // add 1 xp to the player

        // check if the player leveled up
        // if they leveled up run this code - it makes NPCs level up
        //   GameEvents.PlayerLevelUp(data.player.level);

        // when player levels up, call these lines to add points to stats
        // int numPoints = 10;
        // StatsGenerator.AssignUnusedPoints(data.player, numPoints);
    }
}
