using System;
using UnityEngine;

public static class GameEvents
{
    public static event Action OnPlayerMove;

    public static void NotifyPlayerMove()
    {
        OnPlayerMove?.Invoke();
    }
}

