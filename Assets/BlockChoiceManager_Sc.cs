using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockChoiceManager_Sc : MonoBehaviour
{
    // Start is called before the first frame update

    enum CHOICE_STATE
    {
        BLOCK = 0,
        ROTATE,
        DECISION
    };

    [SerializeField] private CHOICE_STATE choiceState;

    [SerializeField] private GameObject curBlock;
    [SerializeField] private GameObject marker = null;

    private float curTime;



    void Start()
    {
        choiceState = CHOICE_STATE.BLOCK;//ブロック選択から開始

        marker.SetActive(false);//マーカーは最初非表示
    }

    // Update is called once per frame
    void Update()
    {
        BlockRotate();

        BlockZoom();

        BlockChoice();

       
    }

    private void BlockChoice()
    {
        if (choiceState != CHOICE_STATE.BLOCK)
            return;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameObject block = curBlock.GetComponent<Block_Sc>().GetLeftBlock();

            //移動先にブロックが存在するか
            if (block)
            {
                curBlock = block;
                LookatBlock();
            }
            else
            {
                Debug.Log("ない！");
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameObject block = curBlock.GetComponent<Block_Sc>().GetRightBlock();

            //移動先にブロックが存在するか
            if (block)
            {
                curBlock = block;
                LookatBlock();
            }
            else
            {
                Debug.Log("ない！");
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GameObject block = curBlock.GetComponent<Block_Sc>().GetUpBlock();

            //移動先にブロックが存在するか
            if (block)
            {
                curBlock = block;
                LookatBlock();
            }
            else
            {
                Debug.Log("ない！");
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GameObject block = curBlock.GetComponent<Block_Sc>().GetDownBlock();

            //移動先にブロックが存在するか
            if (block)
            {
                curBlock = block;
                LookatBlock();
            }
            else
            {
                Debug.Log("ない！");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            choiceState = CHOICE_STATE.ROTATE;
        }
    }

    private void BlockRotate()
    {
        if (choiceState != CHOICE_STATE.ROTATE)
            return;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            curBlock.GetComponent<Block_Sc>().OnKeyDownHorizonalRotate(1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            curBlock.GetComponent<Block_Sc>().OnKeyDownHorizonalRotate(-1);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            curBlock.GetComponent<Block_Sc>().OnKeyDownVerticalRotate(1);

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            curBlock.GetComponent<Block_Sc>().OnKeyDownVerticalRotate(-1);

        }
        else if(Input.GetKeyDown(KeyCode.Backspace))
        {
            choiceState = CHOICE_STATE.BLOCK;
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            choiceState = CHOICE_STATE.DECISION;

            Debug.Log("決定!!");
        }

    }

    private void BlockZoom()//名前キモイ
    {
        //if(choiceState == CHOICE_STATE.BLOCK)
        //{
        //    curBlock.transform.position = curBlock.GetComponent<Block_Sc>().defaultPosition;

        //    marker.transform.position = curBlock.GetComponent<Block_Sc>().defaultPosition + new Vector3(0, 0, -0.5f);
        //    marker.SetActive(true);
        //}
        //else if (choiceState == CHOICE_STATE.ROTATE)
        //{
        //    curBlock.transform.position = curBlock.GetComponent<Block_Sc>().defaultPosition + new Vector3(0,0,-0.75f);
        //    marker.SetActive(false);
        //}
        //else
        //{
        //    curBlock.transform.position = curBlock.GetComponent<Block_Sc>().defaultPosition;
        //}

        return;
    }

    public void LookatBlock()
    {

        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");

        curTime = Mathf.Clamp(curTime + Time.deltaTime, 0f, 0.5f);
        float rate = curTime / 0.5f;
        camera.transform.LookAt(Vector3.Lerp(camera.transform.position,curBlock.transform.position,rate));
        if (rate >= 1f)
        {
            curTime = 0.0f;
        }
        //return curBlock.transform.position;
    }
}
