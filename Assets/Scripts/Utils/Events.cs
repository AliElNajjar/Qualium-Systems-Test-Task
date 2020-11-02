using UnityEngine.Events;
using UnityEngine;
using System;
using System.Collections.Generic;

public class Events
{
    [System.Serializable] public class EventGameState : UnityEvent<GameManager.GameState, GameManager.GameState> { }

    public static event Action<Queue<GameObject>> PointCreated;

    public static event Action<Queue<Vector3>> DeclarePointPosition;

    public static void CallPointCreated(Queue<GameObject> points)
    {
        PointCreated?.Invoke(points);
    }

    public static void CallPointPosition(Queue<Vector3> pointPositions)
    {
        DeclarePointPosition?.Invoke(pointPositions);
    }
}
