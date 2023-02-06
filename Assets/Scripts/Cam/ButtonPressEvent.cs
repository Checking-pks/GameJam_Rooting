using UnityEngine;

public class ButtonPressEvent : MonoBehaviour
{
    [SerializeField]
    private ZoomInOut zoom;
    [SerializeField]
    private string keyCode;
    [SerializeField]
    private bool m_IsButtonDowning;

    void Update()
    {
        if(m_IsButtonDowning)
        {
            zoom.PressKey(keyCode);
        }
    }

    public void PointerDown()
    {
        m_IsButtonDowning = true;
    }

    public void PointerUp()
    {
        m_IsButtonDowning = false;
    }
}