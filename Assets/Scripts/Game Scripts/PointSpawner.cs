using System.Collections.Generic;
using UnityEngine;
using Input = InputTouchSimulator.Input;
public class PointSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pointPrefab;
    private Queue<GameObject> points;
    private Queue<Vector3> pointPositions;
    private AntiOverlapping AntiOverlapping;

    // Start is called before the first frame update
    void Start()
    {
        points = new Queue<GameObject>();
        pointPositions = new Queue<Vector3>();
        AntiOverlapping = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<AntiOverlapping>();
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
    }

    void Inputs()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0f;

            if (touch.phase == TouchPhase.Began)
            {
                if (!ScreenBounds.OutOfBounds(touchPos) && AntiOverlapping.ValidSpawnPos(touchPos))
                {
                    GameObject point = Instantiate(pointPrefab, touchPos, Quaternion.identity);

                    
                    points.Enqueue(point);
                    pointPositions.Enqueue(point.transform.position);

                }
            }
        }

        if (points.Count > 0)
        {
            Events.CallPointCreated(points);
            Events.CallPointPosition(pointPositions);
        }
    }
}
