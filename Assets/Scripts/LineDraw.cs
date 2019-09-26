using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDraw : MonoBehaviour
{
    private LineRenderer line;
    private bool isMousePressed;
    public List<Vector3> pointsList;
    private Vector3 mousePos;

    //structure for line point (where it starts and stops)
    struct myLine
    {
        public Vector3 StartPoint;
        public Vector3 EndPoint;
    }
    // Start is called before the first frame update
    void Awake()
    {
        //creates the line renderer and sets its properties
        line = gameObject.AddComponent<LineRenderer>();
        line.material = new Material (Shader.Find("Legacy Shaders/Particles/Additive"));
        line.SetVertexCount(0);
        line.SetWidth(.01f,.01f);
        //draws the color of the tcell line
        line.SetColors(Color.red, Color.red);
        //finds the position of the mouse in the world space
        line.useWorldSpace = true;
        //mousepressed is false until player input
        isMousePressed = false;
        //holds a list of vector points of line drawn
        pointsList = new List<Vector3>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMousePressed = true;
            line.SetVertexCount(0);
            Debug.Log(pointsList.Count +"Getmouse");

            pointsList.RemoveRange(0, pointsList.Count);
            line.SetColors(Color.red, Color.red);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("pressed = false");
            isMousePressed = false;
        }
        //if mouse is pressed and moving, it will continue to draw a line
        if (isMousePressed)
        {
            Debug.Log("Mouse Pressed");

            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
          //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos = Camera.main.ScreenToWorldPoint(mousePosition);


            Debug.Log(mousePos);
            
           // mousePos.z = 0;
            if (!pointsList.Contains(mousePos))
            {          
                Debug.Log("draw = true");

                Debug.Log(pointsList.Count);

                pointsList.Add(mousePos);
                Debug.Log(pointsList.Count);
                line.SetVertexCount(pointsList.Count);
                line.SetPosition(pointsList.Count - 1, (Vector3) pointsList[pointsList.Count - 1]);
                if (isLineCollide())
                {
                    isMousePressed = false;
                    line.SetColors(Color.blue, Color.blue);
                }
            }
        }
    }

    private bool isLineCollide()
    {
        if (pointsList.Count < 2)
            return false;
        int TotalLines = pointsList.Count - 1;
        myLine[] lines = new myLine[TotalLines];
        if (TotalLines > 1)
        {
            for (int i = 0; i < TotalLines; i++)
            {
                lines [i].StartPoint = (Vector3) pointsList [i];
                lines [i].EndPoint = (Vector3) pointsList [i + 1];
                
            }
        }

        for (int i = 0; i < TotalLines - 1; i++)
        {
            myLine currentLine;
            currentLine.StartPoint = (Vector3) pointsList[pointsList.Count - 2];
            currentLine.EndPoint = (Vector3) pointsList[pointsList.Count - 1];
            if (isLinesIntersect(lines[i], currentLine))
                return true;
        }

        return false;
    }

    private bool checkPoints(Vector3 pointA, Vector3 pointB)
    {
        return (pointA.x == pointB.x && pointA.y == pointB.y);
    }

    private bool isLinesIntersect(myLine L1, myLine L2)
    {
        if (checkPoints(L1.StartPoint, L2.StartPoint) ||
            checkPoints(L1.StartPoint, L2.EndPoint) ||
            checkPoints(L1.EndPoint, L2.StartPoint) ||
            checkPoints(L1.EndPoint, L2.EndPoint))
            return false;

        return ((Mathf.Max(L1.StartPoint.x, L1.EndPoint.x) >= Mathf.Min(L2.StartPoint.x, L2.EndPoint.x)) &&
                (Mathf.Max(L2.StartPoint.x, L2.EndPoint.x) >= Mathf.Min(L1.StartPoint.x, L1.EndPoint.x)) &&
                (Mathf.Max(L1.StartPoint.y, L1.EndPoint.y) >= Mathf.Min(L2.StartPoint.y, L2.EndPoint.y)) &&
                (Mathf.Max(L2.StartPoint.y, L2.EndPoint.y) >= Mathf.Min(L1.StartPoint.y, L1.EndPoint.y)));
    }
}
