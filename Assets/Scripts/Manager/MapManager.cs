using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : Singleton<MapManager>
{
    [SerializeField]
    private GameObject spot;
    [SerializeField]
    private GameObject line;

    [Space(20f)]
    [SerializeField]
    public int width;
    [SerializeField]
    public int height;
    [SerializeField]
    public int depth;
    [SerializeField]
    private float betweenDistance = 1.0f;
    private static float TURN_SPEED = 80.0f;

    private void Start() 
    {
        makeMap();
    }

    private void Update()
    {
        if (GameMgr.Instance.isEnd) transform.Rotate(Vector3.up * TURN_SPEED * Time.deltaTime);
    }

    public void makeMap()
    {
        SummonSpot();
        SummonLine();
    }

    private void SummonSpot()
    {
        for (int i=-(int)(1.0f*width/2-0.5); i<(int)(1.0f*width/2+0.5); i++) {
            for (int j=-(int)(1.0f*height/2-0.5); j<(int)(1.0f*height/2+0.5); j++) {
                for (int k=0; k<depth; k++) {
                    GameObject nowSpot = Instantiate(spot, new Vector3(i * betweenDistance, -k * betweenDistance, j * betweenDistance), Quaternion.Euler(0, 0, 0));
                    nowSpot.transform.SetParent(gameObject.transform);
                }
            }
        }
    }

    private void SummonLine()
    {
        for (int i=-(int)(1.0f*width/2-0.5); i<(int)(1.0f*width/2+0.5); i++) {
            for (int j=-(int)(1.0f*height/2-0.5); j<(int)(1.0f*height/2-0.5); j++) {
                for (int k=0; k<depth; k++) {
                    GameObject nowLine = Instantiate(line, new Vector3(i * betweenDistance, -k * betweenDistance, j * betweenDistance +0.5f), Quaternion.Euler(0, 90, 0));
                    nowLine.transform.SetParent(gameObject.transform);
                }
            }
        }

        for (int i=-(int)(1.0f*width/2-0.5); i<(int)(1.0f*width/2-0.5); i++) {
            for (int j=-(int)(1.0f*height/2-0.5); j<(int)(1.0f*height/2+0.5); j++) {
                for (int k=0; k<depth; k++) {
                    GameObject nowLine = Instantiate(line, new Vector3(i * betweenDistance +0.5f, -k * betweenDistance, j * betweenDistance), Quaternion.Euler(0, 180, 0));
                    nowLine.transform.SetParent(gameObject.transform);
                }
            }
        }

        for (int i=-(int)(1.0f*width/2-0.5); i<(int)(1.0f*width/2+0.5); i++) {
            for (int j=-(int)(1.0f*height/2-0.5); j<(int)(1.0f*height/2+0.5); j++) {
                for (int k=0; k<depth-1; k++) {
                    GameObject nowLine = Instantiate(line, new Vector3(i * betweenDistance, -k * betweenDistance -0.5f, j * betweenDistance), Quaternion.Euler(0, 0, 90));
                    nowLine.transform.SetParent(gameObject.transform);
                }
            }
        }
    }
}
