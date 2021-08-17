using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Main
{
    public class FadeCursor : MonoBehaviour
    {
        public Image Panel;
        float time = 0f;
        float fade_T = 2f;

        void Start()
        {
            if(GameManager.isEnviro && GameManager.isDate && GameManager.isSuicide && GameManager.isAnimal && GameManager.isFamily)
            {
                return;
            }
            else if (!GameManager.beforStart)
            {
                Invoke("CursorA", 3f);
            }
        }

        void Update()
        {
            // FadeOut
            if (Input.GetKeyDown(KeyCode.C))
            {
                Invoke("CursorA", 3f);
            }
        }

        IEnumerator FadeFlowOUT()
        {
            time = 0f;
            Color alpha = Panel.color;
            while (alpha.a < 1f)
            {
                time += Time.deltaTime / fade_T;
                alpha.a = Mathf.Lerp(0, 1, time);
                Panel.color = alpha;
                yield return null;
            }
            time = 0f;
            yield return null;
        }

        void CursorA()
        {
            StartCoroutine("FadeFlowOUT");
        }
    }

}

