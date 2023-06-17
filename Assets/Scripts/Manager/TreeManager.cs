using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : Singleton<TreeManager>
{
    public GameObject[] itemList;

    public float maxHeight = 0;
    public List<GameObject> getItems;
    [Space(10f)]
    public List<Transform> joint;
    private static int BANDING_WEIGHT = 7;
    private static float TURN_SPEED = 80.0f;

    private void Start() 
    {
        joint.Add(transform);
    }

    private void Update()
    {
        if (GameManager.Instance.isEnd) transform.Rotate(Vector3.up * TURN_SPEED * Time.deltaTime);
    }
    
    public int itemCount()
    {
        return getItems.Count;
    }

    public float Score
    {
        get { return maxHeight * getItems.Count * 0.73f; }
    }

    public GameObject GetItems
    {
        set
        {
            getItems.Add(value);

            int selectIdx = Random.Range(0, joint.Count);
            Transform selectJoint = joint[selectIdx];
            joint.RemoveAt(selectIdx);
            
            GameObject nowItem = Instantiate(value, selectJoint.position, selectJoint.rotation);
            nowItem.transform.parent = transform;
            Joint = nowItem;
        }
    }

    public GameObject Joint
    {
        set
        {
            Transform[] nowJoints = value.transform.GetComponentsInChildren<Transform>();
            List<Transform> m_JointLower = new List<Transform>(), m_JointUpper = new List<Transform>();

            for (int i=1; i<nowJoints.Length; i++)
            {
                if (nowJoints[i].tag == "JointLower")
                {
                    m_JointLower.Add(nowJoints[i]);
                }
                else if (nowJoints[i].tag == "JointUpper")
                {
                    m_JointUpper.Add(nowJoints[i]);
                }
            }

            int idx = Random.Range(0, m_JointLower.Count);
            value.transform.position -= m_JointLower[idx].localPosition;
            value.transform.rotation = Quaternion.Euler(Random.Range(0 - getItems.Count * BANDING_WEIGHT, 0 + getItems.Count * BANDING_WEIGHT), Random.Range(0, 360), Random.Range(0 - getItems.Count * BANDING_WEIGHT, 0 + getItems.Count * BANDING_WEIGHT));

            for (int i=0; i<m_JointUpper.Count; i++)
            {
                joint.Add(m_JointUpper[i]);
            }

            if (Random.Range(0, 100) < 50)
            {
                joint.Sort(Operation);

                while (joint.Count > 5)
                    joint.RemoveAt(0);
            }

            if (maxHeight < value.transform.position.y)
                maxHeight = value.transform.position.y;
        }
    }

    private int Operation(Transform A, Transform B)
    {
        if (A.localPosition.y > B.localPosition.y)
            return 1;
        else if (A.localPosition.y < B.localPosition.y)
            return -1;
        else
            return 0;
    }
}
