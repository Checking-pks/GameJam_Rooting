using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRemainingMovement : MonoBehaviour
{
    private Text m_text; 
    void Start()
    {
        m_text = GetComponent<Text>();
    }

    void Update()
    {
        m_text.text = GameMgr.Instance.remainingMovement.ToString();
    }
}
