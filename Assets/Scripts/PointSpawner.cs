using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pointPrefab;
    [HideInInspector] public Queue<GameObject> points;
    
    // Start is called before the first frame update
    void Start()
    {
        points = new Queue<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseControl.gameIsPaused)
        {
            Inputs();
        }
    }

    void Inputs()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                GameObject point = Instantiate(pointPrefab, touchPos, Quaternion.identity);

                points.Enqueue(point);
            }

            
        }
    }
}
