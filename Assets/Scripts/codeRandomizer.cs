using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class codeRandomizer : MonoBehaviour
{
    private KeyPadControl keyPadControl;
    public TMP_Text textMeshPro;

    public Transform[] codeSpots;
    public int randomCodeSpot;

    // Start is called before the first frame update
    void Start()
    {
        keyPadControl = GameObject.FindGameObjectWithTag("Keypad").GetComponent<KeyPadControl>();
        textMeshPro.text = keyPadControl.correctCombination.ToString();

        randomCodeSpot = Random.Range(0, codeSpots.Length);
        transform.position = codeSpots[randomCodeSpot].position;
        transform.rotation = codeSpots[randomCodeSpot].rotation;
    }
}
