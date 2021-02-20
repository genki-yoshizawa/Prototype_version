using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Sc : MonoBehaviour
{

    [SerializeField] private GameObject LeftBlock = null;
    [SerializeField] private GameObject RightBlock = null;
    [SerializeField] private GameObject UpBlock = null;
    [SerializeField] private GameObject DownBlock = null;


    [SerializeField] private Quaternion curRotation;
    [SerializeField] private Quaternion strRotation;
    [SerializeField] private Quaternion endRotation;
    [SerializeField] private float curTime;
    [SerializeField] private bool nowRotate;


    [SerializeField] public Vector3 defaultPosition;

    void Start()
    {
        defaultPosition = this.transform.position;
    }

    void Update()
    {
        UpdateKeyDownRotate();
    }

    public void OnKeyDownHorizonalRotate(int direction)
    {
        if (nowRotate)
            return;

        curTime = 0f;
        strRotation = Quaternion.identity;
        endRotation = Quaternion.Euler(0, 90 * direction, 0);
        nowRotate = true;

    }

    public void OnKeyDownVerticalRotate(int direction)
    {
        if (nowRotate)
            return;

        curTime = 0f;
        strRotation = Quaternion.identity;
        endRotation = Quaternion.Euler(90 * direction,0, 0);
        nowRotate = true;
    }

    private void UpdateKeyDownRotate()
    {
        if (nowRotate == false)
        {
            return;
        }
        curTime = Mathf.Clamp(curTime + Time.deltaTime, 0f, 0.5f);
        float rate = curTime / 0.5f;
        this.transform.rotation = Quaternion.Lerp(strRotation, endRotation, rate);

        if (rate >= 1f)
        {
            curTime = 0.0f;
            nowRotate = false;
        }
    }





    public GameObject GetLeftBlock() { 
        if(LeftBlock == null)
            return null;

        return LeftBlock;
    }
    public GameObject GetRightBlock() {
        if (RightBlock == null)
            return null;

        return RightBlock; 
    }
    public GameObject GetUpBlock() {
        if (UpBlock == null)
            return null;

        return UpBlock;
    }
    public GameObject GetDownBlock() {
        if (DownBlock == null)
            return null;

        return DownBlock;
    }


}
