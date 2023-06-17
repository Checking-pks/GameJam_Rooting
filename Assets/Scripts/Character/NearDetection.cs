using UnityEngine;
using Define;

public class NearDetection : MonoBehaviour
{
    
    [Header("- Spot")]
    public GameObject spotCenter;

    [Header("- Road")]
    public GameObject roadFront;
    public GameObject roadBack, roadLeft, roadRight, roadUp, roadDown;
    private Ray rayFront, rayBack, rayLeft, rayRight, rayUp, rayDown;
    private detection[] detections = {detection.front, detection.back, detection.left, detection.right, detection.up, detection.down, detection.center};

    private void Update()
    {
        UpdateRay();
        foreach (detection d in detections)
            UpdateRayHit(d);
    }

    private void UpdateRay()
    {
        rayFront    = new Ray(transform.position, transform.forward);
        rayBack     = new Ray(transform.position, -transform.forward);
        rayLeft     = new Ray(transform.position, -transform.right);
        rayRight    = new Ray(transform.position, transform.right);
        rayUp       = new Ray(transform.position, transform.up);
        rayDown     = new Ray(transform.position, -transform.up);
    }

    private void UpdateRayHit(detection type)
    {
        switch(type)
        {
            case detection.front:
                roadFront = GetGameObject(rayFront);
                break;
            case detection.back:
                roadBack = GetGameObject(rayBack);
                break;
            case detection.left:
                roadLeft = GetGameObject(rayLeft);
                break;
            case detection.right:
                roadRight = GetGameObject(rayRight);
                break;
            case detection.up:
                roadUp = GetGameObject(rayUp);
                break;
            case detection.down:
                roadDown = GetGameObject(rayDown);
                break;
            case detection.center:
                spotCenter = Physics.OverlapSphere(transform.position, 0.1f)?[0].gameObject;
                break;
            default:
                return;
        } 
    }

    private GameObject GetGameObject(Ray ray)
    {
        RaycastHit hitData;

        if (Physics.Raycast(ray, out hitData, LayerMask.NameToLayer("Map")))
            return hitData.transform.gameObject;
        else
            return null;
    }
}
