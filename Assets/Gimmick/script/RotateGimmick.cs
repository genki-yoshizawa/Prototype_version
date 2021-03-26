using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGimmick : MonoBehaviour
{
    [SerializeField]
    private float rot;

    void Start()
    {
        
    }

    void Update()
    {
        this.gameObject.transform.Rotate(0.0f, 0.0f, rot);
    }
}
