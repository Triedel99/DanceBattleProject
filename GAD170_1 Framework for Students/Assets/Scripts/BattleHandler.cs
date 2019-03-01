using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Static class with method (function) to determine the outcome of a dance battle based on the player and NPC that are 
///     dancing off against each other.
///     
/// TODO:
///     Battle needs to use stats and random to determine the winner of the dance off
///       - outcome value to be a float value between 1 and negative 1. 1 being the biggest possible player win over NPC, 
///         through to -1 being the most decimating defeat of the player possible.
/// </summary>
public static class BattleHandler
{
    public static void Battle(BattleEventData data)
    {
        //This needs to be replaced with some actual battle logic, at present 
        // we just award the maximum possible win to the player
     

        //calulating the luck values for player and npc
        int playerLuck = Random.Range(0, data.player.luck + 1);
        int npcLuck = Random.Range(0, data.npc.luck + 1);

        //Debug.Log(playerLuck);
        //Debug.Log(npcLuck);

        //Calulating the player and npc's total battle number
        int playerResult = data.player.rhythm + data.player.style * playerLuck;
        int npcResult = data.npc.rhythm + data.npc.style * npcLuck;

        //Debug.Log(playerResult);
        //Debug.Log(npcResult);

        float outcome = 0;

        //Finding out who won player or npc
        if (playerResult > npcResult)
        {
            outcome = 1;
        }
        else if (playerResult < npcResult)
        {
            outcome = -1;
        }
        else
        {
            outcome = 0;
        }

        //Debug.Log(outcome);

        var results = new BattleResultEventData(data.player, data.npc, outcome);

        GameEvents.FinishedBattle(results);
    }
}
