using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiOverlapping : MonoBehaviour
{
    [SerializeField] private LayerMask collisionTest;
    private Vector2 pointHalfSize;

    [SerializeField] private Vector2 pointSize;

    void Start()
    {
        pointHalfSize = pointSize * 0.5f;
    }

    public bool ValidSpawnPos(Vector3 clickPos)
    {
        Vector3 clickPosMin = clickPos - (Vector3)pointHalfSize;
        Vector3 clickPosMax = clickPos + (Vector3)pointHalfSize;

        Collider2D[] overlapObjects = Physics2D.OverlapAreaAll(clickPosMin, clickPosMax, collisionTest);

        if (overlapObjects.Length == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
