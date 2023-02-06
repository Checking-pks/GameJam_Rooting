using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineInfo : MonoBehaviour
{
    public int needMovement = 1;
    public bool alreadyVisit = false;
    [SerializeField]
    private Material lineDefaultMaterial;
    [SerializeField]
    private Material lineAlreadyVisitMaterial;

    private void Start() {
        UpdateMeshRenderer();
    }

    public bool AlreadyVisit{
        get{ return alreadyVisit; }
        set
        {
            alreadyVisit = value;
        }
    }

    public void UpdateMeshRenderer(float time = 0)
    {
        Invoke("updateMeshRenderer", time);
    }

    private void updateMeshRenderer()
    {
        GetComponent<MeshRenderer>().material = (alreadyVisit) ? lineAlreadyVisitMaterial : lineDefaultMaterial;
    }
}
