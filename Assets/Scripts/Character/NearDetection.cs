using UnityEngine;

public class NearDetection : MonoBehaviour
{
    
    [Header("- Spot")]
    [SerializeField]
    private GameObject spotCenter;

    [Header("- Road")]
    [SerializeField]
    private GameObject roadFront;
    [SerializeField]
    private GameObject roadBack;
    [SerializeField]
    private GameObject roadLeft;
    [SerializeField]
    private GameObject roadRight;
    [SerializeField]
    private GameObject roadUp;
    [SerializeField]
    private GameObject roadDown;

    public GameObject GetGameObject(EnumManager.detection type)
    {
        switch(type)
        {
            case EnumManager.detection.front:
                return roadFront;
            case EnumManager.detection.back:
                return roadBack;
            case EnumManager.detection.left:
                return roadLeft;
            case EnumManager.detection.right:
                return roadRight;
            case EnumManager.detection.up:
                return roadUp;
            case EnumManager.detection.down:
                return roadDown;
            case EnumManager.detection.center:
                return spotCenter;
            default:
                return null;
        }
    }
    public void SetGameObject(EnumManager.detection type, GameObject obj)
    {
        switch(type)
        {
            case EnumManager.detection.front:
                roadFront = obj;
                break;
            case EnumManager.detection.back:
                roadBack = obj;
                break;
            case EnumManager.detection.left:
                roadLeft = obj;
                break;
            case EnumManager.detection.right:
                roadRight = obj;
                break;
            case EnumManager.detection.up:
                roadUp = obj;
                break;
            case EnumManager.detection.down:
                roadDown = obj;
                break;
            case EnumManager.detection.center:
                spotCenter = obj;
                break;
        }
    }
}
