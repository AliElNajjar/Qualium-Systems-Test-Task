using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
	GameObject nextTarget;
    public static bool targeting;
    private PointSpawner PointSpawner;

	// Start is called before the first frame update
	void Start()
    {
        PointSpawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<PointSpawner>();

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!PauseControl.gameIsPaused && targeting)
        if (PointSpawner.points.Count > 0)
            UpdateTarget();
    }

	public void UpdateTarget()
	{
        nextTarget= PointSpawner.points.Dequeue(); // To chase the points in order of appearance.
        Debug.Log("Enqeued" + nextTarget.name);
        Vector2 dir = nextTarget.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector2 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        GoToTarget(nextTarget);

        targeting = false;
    }

    void GoToTarget(GameObject target)
    {
        transform.Translate(target.transform.position * Time.deltaTime);
    }
}


