using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorController : MonoBehaviour
{

    [SerializeField]
    private GameObject stage;

    [SerializeField]
    private Texture2D originalCursor;

    [SerializeField]
    private GameObject button;


    [SerializeField]
    private GameObject blockPointer;

    private Vector3 sPos;

    private float lerpValue;
    private Quaternion q1;
    private Quaternion q2;
    private Quaternion startRot;

    private float doubleClickTime;
    private bool doubleClick = false;

    private float ZAngleRot;

    void Start()
    {
        
        Cursor.SetCursor(originalCursor, Vector2.zero, CursorMode.Auto);
        button.SetActive(false);

        blockPointer = null;
    }

    void Update()
    {
        CursorOn();
    }

    void CursorOn()
    {


       

        Ray ray;
        RaycastHit hit = new RaycastHit();
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {


            if (hit.collider.gameObject.GetComponent<Block>())
            {
                //ブロック上で左クリック
                //if (Input.GetMouseButtonDown(0) && blockPointer == null)
                //{

                //    blockPointer = hit.collider.gameObject;


                //    blockPointer.GetComponent<Block>().BlockDecision();
                //    blockPointer.GetComponent<faceManager>().Set3DMap();
                //    startRot = q1 = q2 = blockPointer.transform.rotation;


                //    button.SetActive(true);

                //}

                if(blockPointer == null)
                {
                    //ダブルクリックで決定
                    if (doubleClick)
                    {
                        doubleClickTime += Time.deltaTime;
                        if (doubleClickTime < 0.2f)
                        {
                            if (Input.GetMouseButtonDown(0))
                            {
                                doubleClick = false;

                                blockPointer = hit.collider.gameObject;
                                blockPointer.GetComponent<Block>().BlockDecision();
                                blockPointer.GetComponent<faceManager>().Set3DMap();
                                startRot = q1 = q2 = blockPointer.transform.rotation;
                                button.SetActive(true);


                                doubleClickTime = 0.0f;
                            }
                        }
                        else
                        {
                            doubleClick = false;
                            doubleClickTime = 0.0f;
                        }
                    }
                    else
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            doubleClick = true;
                        }
                    }
                }

                

                

            }

        }

        //回転操作
        if (blockPointer != null)
        {

           
            if(Input.GetMouseButtonDown(0))
            {
                sPos = Input.mousePosition;
                startRot = blockPointer.transform.rotation;
                lerpValue = 0;
                
            }
            else if(Input.GetMouseButton(0))
            {
                

                Vector3 v3Dis = Input.mousePosition - sPos;
                v3Dis.z = 0;
                float dis = v3Dis.magnitude;

                if(dis > 0)
                {
                    Vector3 axis = Quaternion.Euler(0, 0, -90) * v3Dis;

                    lerpValue += 0.01f;
                    
                    q2 = Quaternion.AngleAxis(dis / 3, axis) * startRot;
                    blockPointer.transform.rotation = Quaternion.Lerp(q1, q2, lerpValue); // 線形補間
                }

            }
            else if(Input.GetMouseButtonUp(0))
            {
               
                q1 = blockPointer.transform.rotation;

               
            }
            //右クリックでステージごと移動
            else if(Input.GetMouseButtonDown(1))
            {
            }
            else if(Input.GetMouseButton(1))
            {
               
                

                Vector3 v3Dis = this.gameObject.GetComponent<mouseDrag>().GetCursorDifference();
                v3Dis.z = 0;
                float dis = v3Dis.magnitude;

                if (dis != 0)
                {




                    //q2 = Quaternion.AngleAxis(dis / 3, axis) * startRot;
                    //blockPointer.transform.rotation *= Quaternion.Inverse(q);
                    //Vector3 axis = Quaternion.Euler(0, 0, 1) * Space.World;
                    blockPointer.transform.Rotate(0, 0, dis/10, Space.World);




                    //q2 = Quaternion.AngleAxis(dis / 3, axis) * startRot;
                    //blockPointer.transform.rotation = Quaternion.Lerp(q1, q2, lerpValue); // 線形補間
                }




            }
            else if (Input.GetMouseButtonUp(1))
            {
                q1 = blockPointer.transform.rotation;
            }


            //ダブルクリックで決定
            if(doubleClick)
            {
                doubleClickTime += Time.deltaTime;
                if(doubleClickTime < 0.2f)
                {
                    if(Input.GetMouseButtonDown(0))
                    {
                        doubleClick = false;
                        BlockChoiceButton();
                        doubleClickTime = 0.0f;
                    }
                }
                else
                {
                    doubleClick = false;
                    doubleClickTime = 0.0f;
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    doubleClick = true;
                }
            }

            if(Input.GetMouseButtonDown(0))
            {

            }

            return;
        }




    }

    //ブロック選択移動ボタン
    public void BlockChoiceButton()
    {
        //
        blockPointer.GetComponent<faceManager>().FaceDecision();
        startRot = q1 = q2 = blockPointer.transform.rotation;

        blockPointer.GetComponent<Block>().BlockChoice();


        blockPointer.GetComponent<faceManager>().Set2DMap();

        button.SetActive(false);
        blockPointer = null;
    }
}
