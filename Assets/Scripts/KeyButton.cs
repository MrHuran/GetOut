using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyButton : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip keySound;
    public bool keyHit = false;

    private Color originalColor;
    private Renderer rend;

    private float colorReturnTime = 0.1f;
    private float returnColor;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.spatialBlend = 1;
        audioSource.volume = 1;
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    private void Update()
    {
        if (keyHit && returnColor < Time.time)
        {
            audioSource.PlayOneShot(keySound);
            returnColor = Time.time + colorReturnTime;
            rend.material.color = Color.green;
            keyHit = false;
        }
        if (rend.material.color != originalColor && returnColor < Time.time) rend.material.color = originalColor;
    }
}
