using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITreeView : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    bool isOn = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)) cam.gameObject.SetActive(true);
        if(Input.GetKeyUp(KeyCode.Tab)) cam.gameObject.SetActive(false); 

        cam.transform.position = new Vector3(cam.transform.position.x, TreeManager.Instance.maxHeight * 0.6f, cam.transform.position.z);
    }

    public void OnTouch()
    {
        isOn = !isOn;
        cam.gameObject.SetActive(isOn);
    }
}
