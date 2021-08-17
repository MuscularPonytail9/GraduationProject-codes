using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadImage : MonoBehaviour
{
    public Image img;
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        byte[] bytes = System.IO.File.ReadAllBytes("C:/screenShot.png");
        Texture2D tex = new Texture2D(0, 0);
        tex.LoadImage(bytes);
        Rect rect = new Rect(0, 0, tex.width, tex.height);
        img.sprite = Sprite.Create(tex, rect, new Vector2(0.5f, 0.5f));
    }
}
