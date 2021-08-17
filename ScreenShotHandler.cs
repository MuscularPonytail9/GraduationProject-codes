using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShotHandler : MonoBehaviour
{
	int t = 0;
	IEnumerator Start()
	{
		yield return UploadPNG();
	}

	IEnumerator UploadPNG()
	{
		yield return new WaitForEndOfFrame();

		int width = Screen.width;
		int height = Screen.height;
		Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);

		tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
		tex.Apply();

		byte[] bytes = tex.EncodeToPNG();
		UnityEngine.Object.Destroy(tex);

		System.IO.File.WriteAllBytes(Application.dataPath + "/SavedScreen.png", bytes);
	}
	void Update()
    {
		t++;
		if (t == 400)
        {
			StartCoroutine("Start");
		}
    }
}

