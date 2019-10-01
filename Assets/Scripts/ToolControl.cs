using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ToolControl : MonoBehaviour
{
    private float mZCoord;
    private Vector3 offset;

  //  public GameObject bParticle;

   // public GameObject rParticle;

   // public GameObject pParticle;
    // Start is called before the first frame update


    void onMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position + GetMouseAsWorldPoint();
    
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        if (this.gameObject.CompareTag("Bacteria"))
        {
           // Instantiate(bParticle, transform.position, Quaternion.identity);
            Multiply.bacteriaCount-=1; 
            Destroy(gameObject);
        }
        if (this.gameObject.CompareTag("Red"))
        {
            redMultiply.redCount-=1; 
            Destroy(this.gameObject);
        }
        if (this.gameObject.CompareTag("Plate"))
        {
            PlateletMultiply.plateCount-=1; 
            Destroy(this.gameObject);
        }
        Debug.Log("SEND HALP");
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + offset;
    }
}
