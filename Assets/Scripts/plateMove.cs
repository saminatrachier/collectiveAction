using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateMove : MonoBehaviour
{
    public float speed = 5f;

    public Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {

}

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = destination - transform.position;
        Debug.DrawLine(transform.position, destination, Color.yellow);

        if (moveDir.magnitude > 1f)
        {
            moveDir = moveDir.normalized;
        }

        transform.position += moveDir * speed * Time.deltaTime;

        transform.forward = Vector3.Lerp(transform.forward, moveDir, speed * Time.deltaTime);
        if (transform.position == destination)
        {
            Destroy(this.gameObject);
            PlateletMultiply.plateCount-=1; 
        }
    }
}
