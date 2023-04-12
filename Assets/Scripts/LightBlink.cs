using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlink : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] Vector2 hiddenTimeRange;
    [SerializeField] Vector2 shownTimeRange;

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
