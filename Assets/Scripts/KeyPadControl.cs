using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadControl : MonoBehaviour
{
    public int correctCombination;
    public bool accessGranted = false;

    public static bool isDone = false;

    private SceneLoader sceneLoader;

    public FadeScreen fade;

    private void Awake()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        sceneLoader = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>();
        correctCombination = Random.Range(1000, 9999);
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
            isDone = true;
            sceneLoader.LoadScene("Menu", fade);
        }
    }
}
