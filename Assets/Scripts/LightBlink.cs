using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlink : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] Vector2 hiddenTimeRange = new Vector2(1, 30);
    [SerializeField] Vector2 shownTimeRange = new Vector2(1, 1);

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowingAndHiding());
    }

    IEnumerator ShowingAndHiding()
    {
        while (true)
        {
            target.SetActive(true);
            float showTime = Random.Range(shownTimeRange.x, shownTimeRange.y);
            print(showTime);
            yield return new WaitForSeconds(showTime);
            target.SetActive(false);
            float hideTime = Random.Range(hiddenTimeRange.x, hiddenTimeRange.y);
            print(hideTime);
            yield return new WaitForSeconds(hideTime);
        }
    }
}