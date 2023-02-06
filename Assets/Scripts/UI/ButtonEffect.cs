using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEffect : MonoBehaviour
{
    [SerializeField]
    private Image button;
    [SerializeField]
    private string keyCode;

    [SerializeField]
    private Color normal, press;

    private void Start() {
        button = GetComponent<Image>();
    }

    private KeyCode stringToKeyCode(string keycode)
    {
        switch(keycode)
        {
            case "Up":
                return KeyCode.W;
            case "Down":
                return KeyCode.S;
            case "Forward":
                return KeyCode.UpArrow;
            case "Back":
                return KeyCode.DownArrow;
            case "Right":
                return KeyCode.RightArrow;
            case "Left":
                return KeyCode.LeftArrow;
        }

        return KeyCode.None;
    }

    void Update()
    {
        if (Input.GetKeyDown(stringToKeyCode(keyCode)))
        {
            button.color = press;
        }
        if (Input.GetKeyUp(stringToKeyCode(keyCode)))
        {
            button.color = normal;
        }
    }
}
