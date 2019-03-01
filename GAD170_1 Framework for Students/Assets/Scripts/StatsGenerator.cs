﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  A <see langword="static"/> class with methods (functions) for initialising or randomising the stats class.
///  
/// TODO:
///     Initialise a stats instance with generated starting stats
///     Handle the assignment of extra points or xp into an existing stats of a character
///         - this is expected to be used by NPCs leveling up to match the player.
/// </summary>
public static class StatsGenerator
{
    public static void InitialStats(Stats stats)
    {
        stats.level = 1;
        stats.xp = 0;

        //randomly generating player and npc's stats
        stats.rhythm = Random.Range(2, 16);
        stats.style = Random.Range(2, 16);
        stats.luck = Random.Range(2, 16);

        //Debug.Log(stats.rhythm);
        //Debug.Log(stats.style);
        //Debug.Log(stats.luck);

    }

    public static void AssignUnusedPoints(Stats stats, int points)
    {
        //Debug.Log(stats.rhythm);
        //Debug.Log(stats.style);
        //Debug.Log(stats.luck);
    }
}
