using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownGimmick : MonoBehaviour
{
    //pos01から02の間を行ったり来たりする
    [SerializeField]
    private GameObject rail01;
    [SerializeField]
    private GameObject rail02;

    [SerializeField]
    private float time;     //何秒でrail間を行き来するか
    private int timeCount;

    private bool railPos;   //trueなら01から02に向かっている状態

    private Vector3 moveDistance;

    void Start()
    {
        //rail02に格納されているオブジェクト位置から移動を開始する
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
