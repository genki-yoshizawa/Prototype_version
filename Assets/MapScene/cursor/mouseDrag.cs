using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseDrag : MonoBehaviour
{

    private Vector3 startPos;
    private Vector3 dragStartPos;
 
    private bool enable;

    private Vector3 curPos;
    private Vector3 nexPos;

    void Start()
    {
        enable = false;
    }

  
    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
           

            enable = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (enable)
            {
                
                startPos = Input.mousePosition;
                enable = false;
            }


        }


    }

   

    public Vector3 GetStartPos()
    {
        return startPos;
    }

    
    public Vector3? AdditionalPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        foreach (RaycastHit hit in Physics.RaycastAll(ray))
        {
            //Debug.Log(hit.collider.gameObject.transform.position);
            if(hit.collider.gameObject.name == "Stage")
            {
                Vector3 screenPoint;
                screenPoint = Camera.main.WorldToScreenPoint(transform.position);
                Vector3 a = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
                return Camera.main.ScreenToWorldPoint(a);
            }
        }

        return null;
    }

    
    //前フレームとの座標座標差分
    public Vector3 GetCursorDifference()
    {
        Vector3 dif;

        dif = Input.mousePosition - curPos;
        curPos = Input.mousePosition;

        return dif;
    }

}
