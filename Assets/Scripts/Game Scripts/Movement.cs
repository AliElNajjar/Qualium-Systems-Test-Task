using UnityEngine;
using System.Collections.Generic;
using System.Collections;
//using System.Numerics;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    Transform nextTarget;
    bool arrived, isMoving;
    private Queue<GameObject> targets;
    public GameObject currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        targets = new Queue<GameObject>();
        Events.PointCreated += UpdateTargets;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        GoToNextPoint();
    }

    private void GoToNextPoint()
    {
        //Debug.Log("ismoving" + isMoving);
        if (!isMoving && targets.Count > 0)
        {
            currentTarget = targets.Dequeue();
            nextTarget = currentTarget.transform;

            RotateToTarget();
            StartCoroutine(GoToTarget(currentTarget));
        }
    }
    IEnumerator GoToTarget(GameObject target)
    {
        do
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            
            //Debug.Log("going to target");
            
            arrived = Arrived(nextTarget);

            yield return new WaitForSeconds(Time.deltaTime);

        } while (!arrived);
        

        yield return null;
    }

    void RotateToTarget()
    {
        Vector3 targetPos = nextTarget.position;
        Vector2 dir = targetPos - transform.position;
        transform.up = dir;
    }

    private bool Arrived(Transform target)
    {
        if (target != null)
        {
            if ((transform.position == target.position ||
            Vector3.Distance(transform.position, target.position) <= 0.1f))
            {
                isMoving = false;
                return true;
            }
            else
            {
                isMoving = true;
                return false;
            } 
        }
        else
        {
            isMoving = false;
            return true;
        }    
    }

    void UpdateTargets(Queue<GameObject> points)
    {
        GameObject target = points.Dequeue();
        targets.Enqueue(target);

    }
}


