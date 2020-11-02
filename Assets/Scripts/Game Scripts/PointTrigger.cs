using UnityEngine;

public class PointTrigger : MonoBehaviour
{
    private Movement movement;

    private void OnEnable()
    {
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(this.gameObject.transform.position == movement.currentTarget.transform.position)
            {
                Destroy(this.gameObject);
            }  
        }
    }
}
