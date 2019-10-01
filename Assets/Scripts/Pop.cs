using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pop : MonoBehaviour
{
   // public bool isAlive = true;
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Ray bacteriaRay = new Ray(transform.position, transform.forward);

        float maxRayDistance = 1.5f;

        Debug.DrawRay(bacteriaRay.origin, bacteriaRay.direction * maxRayDistance, Color.magenta);

        if (Physics.Raycast(bacteriaRay, maxRayDistance))
        {
           // Destroy(this.gameObject);
        }
    }


}
