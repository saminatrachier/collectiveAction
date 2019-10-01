using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bacteriaMove : MonoBehaviour
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
        if (scoreCounter.moveCode == true)
        {
            Vector3 moveDir = destination - transform.position;
            Debug.DrawLine(transform.position, destination, Color.yellow);

            if (moveDir.magnitude > 1f)
            {
                moveDir = moveDir.normalized;
            }

            transform.position += moveDir * speed * Time.deltaTime;

            transform.forward = Vector3.Lerp(transform.forward, moveDir, speed * Time.deltaTime);
        }

       
        }
    void OnTriggerEnter(Collider wound)
    {
        if (wound.gameObject.CompareTag("wound"))
        {
            Debug.Log("scoreprint");
            scoreCounter.badScore++;
        }
    }
     
}
