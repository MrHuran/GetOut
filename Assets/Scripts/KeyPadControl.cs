using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadControl : MonoBehaviour
{
    public int correctCombination;
    public bool accessGranted = false;

    private SceneLoader sceneLoader;

    private void Start()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        sceneLoader = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>();
    }

    private void Update()
    {
        if (accessGranted) accessGranted = false;
    }

    public bool CheckIfCorrect(int combination)
    {
        if (combination == correctCombination)
        {
            accessGranted = true;
            gameObject.GetComponent<BoxCollider>().enabled = true;
            return true;
        }
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            sceneLoader.LoadScene("EndScreen");
        }
    }
}
