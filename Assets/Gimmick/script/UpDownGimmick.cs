using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownGimmick : MonoBehaviour
{
    //pos01����02�̊Ԃ��s�����藈���肷��
    [SerializeField]
    private GameObject rail01;
    [SerializeField]
    private GameObject rail02;

    [SerializeField]
    private float time;     //���b��rail�Ԃ��s�������邩
    private int timeCount;

    private bool railPos;   //true�Ȃ�01����02�Ɍ������Ă�����

    private Vector3 moveDistance;

    void Start()
    {
        //rail02�Ɋi�[����Ă���I�u�W�F�N�g�ʒu����ړ����J�n����
        Vector3 rail01Pos = rail01.GetComponent<Transform>().position;
        Vector3 rail02Pos = rail02.GetComponent<Transform>().position;

        this.gameObject.transform.position = rail01Pos;
        railPos = true;

        moveDistance = (rail01Pos - rail02Pos) / time;
        timeCount = 0;
    }

    void Update()
    {
        timeCount++;
        if (railPos)
        {
            this.gameObject.transform.position -= moveDistance;
            if (timeCount >= time)
            {
                railPos = false;
                timeCount = 0;
            }
        }
        else
        {
            this.gameObject.transform.position += moveDistance;
            if (timeCount >= time)
            {
                railPos = true;
                timeCount = 0;
            }
        }
    }
}
