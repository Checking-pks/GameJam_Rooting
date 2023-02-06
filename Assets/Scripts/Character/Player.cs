
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject rotObj;
    Vector2 Presspoint;
    private int rot = 0;
    private bool isRotX = false;

    void Update()
    {
        StartCoroutine(RotateObj());
    }
    IEnumerator RotateObj()
    {        
        if (Input.GetMouseButtonDown(0))
        {
            Presspoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            while (Input.GetMouseButton(0))
            {
                Vector2 mouseDragPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

                float diff_x = (mouseDragPosition - Presspoint).x;
                float diff_y = (mouseDragPosition - Presspoint).y;

                if(diff_x > diff_y){
                    isRotX = true;

                    if(diff_x < 0)
                        rot = -90;

                    else if(diff_x > 0)
                        rot = 90;
                }
                else{
                    isRotX = false;
                    if(diff_y < 0)
                        rot = -90;

                    else if(diff_y > 0)
                        rot = 90;
                }

                yield return null;
            }
            if(isRotX == true){
                rotObj.transform.eulerAngles = rotObj.transform.eulerAngles - new Vector3(0, rot, 0);
            }
            else
                rotObj.transform.eulerAngles = rotObj.transform.eulerAngles - new Vector3(0, 0, rot);


        }        
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject rotObj;

    void Update()
    {
        StartCoroutine(RotateObj());
    }
    IEnumerator RotateObj()
    {        
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 Presspoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            while (Input.GetMouseButton(0))
            {
                Vector2 mouseDragPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                float diff = (mouseDragPosition - Presspoint).x / Screen.width * 360;

                if(diff <= 90 && diff >= -90)
                    rotObj.transform.eulerAngles = - new Vector3(0, diff, 0);

                yield return null;
            }
        }        
    }
}

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    enum rotateDir{
        Up,
        Down,
        Left,
        Right
    };

    Vector2 startPoint;
    Vector2 endPoint;

    rotateDir rotateMode;

    public float moveTime = 1.0f;
    public Vector3 target;
    public Vector3 start;
    public float nowTime = 0;

    void Start()
    {
        target = transform.eulerAngles;
        start = transform.eulerAngles;
    }

    void Update()
    {
        transform.eulerAngles = Vector3.Lerp(start, target, nowTime);
        if (nowTime <= 1)
        {
            nowTime += moveTime * Time.deltaTime;
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
            {
                startPoint = Input.mousePosition;
            }

            if (Input.GetMouseButtonUp(0))
            {
                endPoint = Input.mousePosition;
                
                rotateMode = GetrotateDir(endPoint - startPoint);

                switch(rotateMode)
                {
                    case rotateDir.Up:
                        target = transform.eulerAngles + Vector3.right * 90;
                        start = transform.eulerAngles;
                        nowTime = 0;
                        break;
                    case rotateDir.Down:
                        target = transform.eulerAngles - Vector3.right * 90;
                        start = transform.eulerAngles;
                        nowTime = 0;
                        break;
                    case rotateDir.Right:
                        target = transform.eulerAngles + Vector3.up * 90;
                        start = transform.eulerAngles;
                        nowTime = 0;
                        break;
                    case rotateDir.Left:
                        target = transform.eulerAngles - Vector3.up * 90;
                        start = transform.eulerAngles;
                        nowTime = 0;
                        break;
                }
            }
        }
    }

    private rotateDir GetrotateDir(Vector2 value)
    {
        if (Mathf.Abs(value.x) < Mathf.Abs(value.y))
            return (value.y > 0) ? rotateDir.Up : rotateDir.Down;
        else
            return (value.x > 0) ? rotateDir.Right : rotateDir.Left;
    }


}