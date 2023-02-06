using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionObject : MonoBehaviour
{
    [SerializeField]
    private NearDetection character;

    [SerializeField]
    private EnumManager.detection detectionPos;

    [SerializeField]
    private Collider[] nearObjList;

    void Update()
    {
        nearObjList = Physics.OverlapSphere(transform.position, 0.1f);

        for (int i=0; i<nearObjList.Length; i++)
        {
            if (nearObjList[i].tag == "Line" || nearObjList[i].tag == "Spot")
            {
                character.SetGameObject(detectionPos, nearObjList[i].gameObject);
                return;
            }
        }

        character.SetGameObject(detectionPos, null);
    }
}
