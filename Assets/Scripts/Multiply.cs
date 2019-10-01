using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiply : MonoBehaviour
{
    public static int bacteriaCount = 0;
    public Transform bacteriaPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bacteriaCount <= 5)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-30f,30f), Random.Range(-30f,30f),Random.Range(10f,30f));
            Instantiate(bacteriaPrefab, randomPosition, Quaternion.Euler(0, Random.Range(0f, 360), 0));
            bacteriaCount++;
        }
    }
}
