using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmicHummer : MonoBehaviour
{
    //�d�S�ł͂Ȃ���]��
    [SerializeField] private Vector3 center = new Vector3(-1.0f, 0f, 0f);
    //�ϐ����Ƃ������������l���ĂȂ��i���������f�o�b�O�ŏo���ׂ���ˁj
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
        //���@�K�I�[�u
        //���N���b�N�ŕ����G���W����~�A�X�y�[�X�ōĊJ
        if (Input.GetMouseButtonDown(0))
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        }

        Vector3 force = Physics.gravity * rb.mass;
        Vector3 offset_position = transform.position + Quaternion.AngleAxis(transform.rotation.eulerAngles.z, -Vector3.forward) * offset;
        rb.AddForceAtPosition(force, offset_position);

        //�R�s�y
        Debug.DrawLine(transform.position, transform.position + transform.rotation * center);

        Debug.Log(Quaternion.AngleAxis(transform.rotation.eulerAngles.z, -Vector3.forward) * offset);
    }
    

    //�R�s�y
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + transform.rotation * center, 0.1f);
    }
}
