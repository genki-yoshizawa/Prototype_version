using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmicHummer : MonoBehaviour
{
    //èdêSÇ≈ÇÕÇ»Ç≠âÒì]é≤
    [SerializeField] private Vector3 center = new Vector3(-1.0f, 0f, 0f);
    [SerializeField] private Vector3 offset = new Vector3(1.5f, 0.0f, 0.0f);

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = center;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 force = Physics.gravity * rb.mass;
        //Mathf.Cos(transform.rotation.z * Mathf.Deg2Rad) * offset
        Vector3 offset_position = transform.position + Quaternion.AngleAxis(transform.rotation.eulerAngles.z, -Vector3.forward) * offset ;
        rb.AddForceAtPosition(force, offset_position);

        Debug.DrawLine(transform.position, transform.position + transform.rotation * center);
        Debug.Log(Quaternion.AngleAxis(transform.rotation.eulerAngles.z, -Vector3.forward) * offset);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + transform.rotation * center, 0.1f);
    }
}
