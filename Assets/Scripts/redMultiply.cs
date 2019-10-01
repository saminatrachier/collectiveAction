using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redMultiply : MonoBehaviour
{
    public static int redCount = 0;
    public Transform redPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (redCount <= 7)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-10f,10f), Random.Range(-10f,10f),Random.Range(-10f,10f));
            Instantiate(redPrefab, randomPosition, Quaternion.Euler(0, Random.Range(0f, 360), 0));
            redCount++;
        }
    }
}
