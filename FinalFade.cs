using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalFade : MonoBehaviour
{
    public Image Panel;
    float time = 0f;
    float fade_T = 1f;

    private void Start()
    {
        FadeOUT();
    }

    public void FadeOUT()
    {
        StartCoroutine(FadeFlowOUT());
    }

    IEnumerator FadeFlowOUT()
    {
        Panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = Panel.color;

        while (alpha.a > 0f)
        {
            time += Time.deltaTime / fade_T;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }

        Panel.gameObject.SetActive(false);
        yield return null;
    }
}
