using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : Singleton<GameMgr>
{
    public int remainingMovement = 10;
    public bool isEnd = false;

    [Space(10f)]
    [SerializeField]
    private GameObject disableCanvas;
    [SerializeField]
    private GameObject ableCanvas;
    [SerializeField]
    private GameObject character;

    private void Start()
    {
        remainingMovement = (MapManager.Instance.width * MapManager.Instance.height * MapManager.Instance.depth) / 10;
        isEnd = false;
        Input.multiTouchEnabled = false;
    }

    private void Update()
    {
        if (!isEnd && remainingMovement <= 0) ending();
    }

    private void ending()
    {
        isEnd = true;

        SpotInfo[] spotList = MapManager.Instance.GetComponentsInChildren<SpotInfo>();
        foreach(SpotInfo s in spotList) s.gameObject.SetActive(false);

        LineInfo[] lineList = MapManager.Instance.GetComponentsInChildren<LineInfo>();
        foreach(LineInfo l in lineList) 
        {
            if (!l.alreadyVisit) l.gameObject.SetActive(false);
            else l.transform.localScale = new Vector3(1, 0.025f, 0.025f);
        }

        disableCanvas.SetActive(false);
        ableCanvas.SetActive(true);
        character.SetActive(false);

        BGMManager.Instance.PlayEndingAudio();
    }
}
