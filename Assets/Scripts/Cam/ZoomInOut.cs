using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ZoomInOut : MonoBehaviour
{
    public float speed = 10.0f;
    public void PressKey(string arrow)
    {
        switch(arrow){
            case "Left" : // left
                transform.position -= transform.right * speed * Time.deltaTime;
                break;

            case "Right" : // right
                transform.position += transform.right * speed * Time.deltaTime;
                break;

            case "Forward" : // forward
                transform.position += transform.forward * speed * Time.deltaTime;
                break;

            case "Back" :
                transform.position -= transform.forward * speed * Time.deltaTime;
                break;

            case "Up" : // w
                transform.position += transform.up * speed * Time.deltaTime;
                break;

            case "Down" : // s
                transform.position -= transform.up * speed * Time.deltaTime;
                break;
        }
    }
}