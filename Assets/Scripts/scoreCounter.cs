using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scoreCounter : MonoBehaviour
{
    public static int badScore = 0;
    public static bool moveCode = true;
    
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (badScore >= 6)
        {
            Debug.Log("movecode is false");
            Physics.gravity = new Vector3(0, -9.8f, 0);
            moveCode = false;
        }
    }
}
