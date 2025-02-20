using System;
using UnityEngine;

public static class GameEvents
{
    public static event Action OnPlayerMove;

    public static event Action OnEnemyMove;

    public static event Action OnEnemyDeath;


    public static void NotifyPlayerMove()
    {
        OnPlayerMove?.Invoke();


    }

    public static void NotifyEnemyMove()
    {
        OnEnemyMove?.Invoke();
    }

    public static void NotifyEnemyDeath()
    {
        OnEnemyDeath?.Invoke();
    }


}

