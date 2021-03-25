using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

  
    [SerializeField] private bool nowRotate;


    private Vector3 defaultPosition;

    [SerializeField]
    private GameObject frontFace;

    //private GameObject stage;

    void Start()
    {
        defaultPosition = this.transform.position;
    }

    void Update()
    {
        //stage = GameObject.FindWithTag("Stage");

        //ê≥ñ éÊìæ
        frontFace = GetComponent<faceManager>().GetFrontFace();
    }

   

    public void BlockDecision()
    {
        //defaultPosition = this.transform.position;
        this.transform.position += new Vector3(0, 0, -5f);
        this.transform.Rotate(-12.0f, 24.0f, 0.0f, Space.World);
    }

    public void BlockChoice()
    {
        this.transform.position += new Vector3(0, 0, 5f);

    }

    public void UpdateDefaultPosition()
    {
        defaultPosition = this.transform.position;
    }

}
