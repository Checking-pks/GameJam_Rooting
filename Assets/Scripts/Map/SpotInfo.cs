using UnityEngine;

public class SpotInfo : MonoBehaviour
{
    public int recoverMovement = 3;
    [SerializeField]
    private int itemProbability = 50;
    private int valueProbability;
    [SerializeField]
    private GameObject item;

    public GameObject Item
    {
        get { return item; }
        set 
        {
            item = value;
            GetComponent<MeshRenderer>().material.color = (item != null) ? haveItemColor : defaultColor;
        }
    }

    [Space(20f)]
    [SerializeField]
    private Color defaultColor = Color.white;
    [SerializeField]
    private Color haveItemColor = Color.red;

    void Start()
    {
        valueProbability = Random.Range(0, 100);

        if (valueProbability < itemProbability && TreeManager.Instance.itemList.Length > 0 && transform.position != Vector3.zero)
        {
            int itemCode = Random.Range(0, TreeManager.Instance.itemList.Length);
            item = TreeManager.Instance.itemList[itemCode];
            GetComponent<MeshRenderer>().material.color = haveItemColor;
        }
        else
        {
            GetComponent<MeshRenderer>().material.color = defaultColor;
        }
    }
}
