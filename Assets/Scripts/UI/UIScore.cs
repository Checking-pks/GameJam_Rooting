using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    [SerializeField]
    private string type;
    private Text m_text;
    private int score;
    void Start()
    {
        m_text = GetComponent<Text>();
    }
    void Update()
    {
        if (type == "score")
            m_text.text = ((int)TreeManager.Instance.Score).ToString();
        else if (type == "item")
            m_text.text = ((int)TreeManager.Instance.itemCount()).ToString();
        else if (type == "height")
            m_text.text = ((float)Mathf.Round(TreeManager.Instance.maxHeight * 10)/10).ToString();
    }
}
