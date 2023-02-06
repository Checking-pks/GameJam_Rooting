using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIReset : MonoBehaviour
{
    [SerializeField]
    private GameObject character;
    [SerializeField]
    private GameObject playCanvas;
    [SerializeField]
    private GameObject endingCanavs;
    [SerializeField]
    private GameObject title;

    public void GameReset()
    {
        GameMgr.Instance.isEnd = false;

        character.gameObject.SetActive(true);
        character.transform.position = Vector3.zero;
        character.GetComponent<MoveCharacter>().reset();

        Transform[] maps = MapManager.Instance.transform.GetComponentsInChildren<Transform>(true);
        foreach (Transform m in maps) if(m.tag == "Spot" || m.tag == "Line") Destroy(m.gameObject);
        MapManager.Instance.transform.rotation = Quaternion.Euler(0,0,0);
        MapManager.Instance.makeMap();

        playCanvas.SetActive(true);

        GameMgr.Instance.remainingMovement = (MapManager.Instance.width * MapManager.Instance.height * MapManager.Instance.depth) / 10;

        Transform[] items = TreeManager.Instance.transform.GetComponentsInChildren<Transform>(true);
        foreach (Transform i in items) if(i.tag == "Item") Destroy(i.gameObject);
        TreeManager.Instance.maxHeight = 0;
        TreeManager.Instance.getItems = new List<GameObject>();
        TreeManager.Instance.transform.rotation = Quaternion.Euler(0,0,0);
        TreeManager.Instance.joint = new List<Transform>{TreeManager.Instance.gameObject.transform};

        BGMManager.Instance.PlayDefaultAudio();

        title.SetActive(true);

        endingCanavs.SetActive(false);
    }
}
