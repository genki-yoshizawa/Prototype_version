using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceManager : MonoBehaviour
{
   

    [SerializeField] private GameObject frontFace;

    void Start()
    {


        frontFace = transform.GetChild(0).gameObject;
        foreach (Transform child in gameObject.transform)
        {
            if (frontFace.transform.position.z > child.transform.position.z)
            {
                frontFace = child.gameObject;
            }
        }


        Set2DMap();
    }

    void Update()
    {
        
    }

  

    public void Set2DMap()
    {
       
        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(false);
        }
        frontFace.SetActive(true);
    }

    public void Set3DMap()
    {
      
        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    public void FaceDecision()
    {

        frontFace = transform.GetChild(0).gameObject;
        foreach(Transform child in gameObject.transform)
        {
           if(frontFace.transform.position.z > child.transform.position.z)
            {
                frontFace = child.gameObject;
            }
        }
        

        Vector3 rot = this.transform.localEulerAngles;

        int a;
        int b;

        //XŽ²
        {
            a = (int)rot.x % 90;
            b = 90 - a;
            if (b > 45)
            {
                rot.x = (int)rot.x - a;
            }
            else
            {
                rot.x += b;
            }
        }
        //YŽ²
        {
            a = (int)rot.y % 90;
            b = 90 - a;
            if (b > 45)
            {
                rot.y = (int)rot.y - a;
            }
            else
            {
                rot.y += b;
            }
        }
        //ZŽ²
        {
            a = (int)rot.z % 90;
            b = 90 - a;
            if (b > 45)
            {
                rot.z = (int)rot.z - a;
            }
            else
            {
                rot.z += b;
            }
        }



        this.transform.rotation = Quaternion.Euler(rot);
    }

    public GameObject GetFrontFace()
    {
        return frontFace;
    }
}
