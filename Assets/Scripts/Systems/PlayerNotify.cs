using System;
using UnityEngine;

public static class GameEvents
{
    public static event Action OnPlayerMove;

    public static event Action OnEnemyMove;


    public static void NotifyPlayerMove()
    {
        OnPlayerMove?.Invoke();

    }

    public static void NotifyEnemyMove()
    {
        OnEnemyMove?.Invoke();
    }
}

