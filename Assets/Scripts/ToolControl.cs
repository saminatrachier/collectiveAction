using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToolControl : MonoBehaviour
{
    private float mZCoord;
    private Vector3 offset;
    // Start is called before the first frame update


    void onMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position + GetMouseAsWorldPoint();
    
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        Destroy(this.gameObject);
        Multiply.bacteriaCount-=1; 
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
