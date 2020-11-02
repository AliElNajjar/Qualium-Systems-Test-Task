using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrajectoryLogic : MonoBehaviour
{
    private List<Vector3> pointTargetPositionsList;
    [SerializeField] private LineRenderer trajectory;

    // Start is called before the first frame update
    void Start()
    {
        pointTargetPositionsList = new List<Vector3>();
        Events.DeclarePointPosition += UpdatePointTargetPos;
    }

    // Update is called once per frame
    void Update()
    {
        DrawTrajectory();
    }

    void UpdatePointTargetPos(Queue<Vector3> pointPositions)
    {
        pointTargetPositionsList = pointPositions.ToList();    
    }

    void DrawTrajectory()
    {
        Vector3[] trajectoryPoints = GetTargetPositions(pointTargetPositionsList);
        
        trajectory.positionCount = trajectoryPoints.Length;

        trajectory.SetPositions(trajectoryPoints);
    }

    private Vector3[] GetTargetPositions(List<Vector3> pointspos)
    {
        Vector3[] pointPositions = new Vector3[pointspos.Count];

        for (int i = 0; i < pointspos.Count; i++)
        {
            pointPositions[i] = pointTargetPositionsList[i];
        }
        return pointPositions;
    }
}
