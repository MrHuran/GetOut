using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyDetector : MonoBehaviour
{
    private TextMeshPro display;

    private KeyPadControl keyPadControl;

    private void Start()
    {
        display = GameObject.FindGameObjectWithTag("Display").GetComponentInChildren<TextMeshPro>();
        display.text = "";

        keyPadControl = GameObject.FindGameObjectWithTag("Keypad").GetComponent<KeyPadControl>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "KeypadButton")
        {
            var key = other.GetComponentInChildren<TextMeshPro>();
            if (key != null)
            {
                var keyButton = other.gameObject.GetComponent<KeyButton>();
                if (key.text == "Cancel") display.text = "";
                else if (key.text == "Enter")
                {
                    var accessGranted = false;
                    bool onlyNumbers = int.TryParse(display.text, out int value);
                    if (onlyNumbers == true && display.text.Length > 0) accessGranted = keyPadControl.CheckIfCorrect(int.Parse(display.text));
                    if (accessGranted == true) display.text = "GOOD";
                    else display.text = "WRONG";
                }
                else
                {
                    bool onlyNumbers = int.TryParse(display.text, out int value);
                    if (onlyNumbers == false) display.text = "";
                    if (display.text.Length < 4) display.text += key.text;
                }
                keyButton.keyHit = true;
            }
        }
    }
}
