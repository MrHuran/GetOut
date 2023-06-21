using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showDone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (KeyPadControl.isDone) transform.gameObject.SetActive(true);
        else transform.gameObject.SetActive(false);
    }
}
