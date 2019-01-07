using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeFromBlack : MonoBehaviour {

    Texture2D blk;
    public bool fade;
    public float alph;
    void Start()
    {
        //make a tiny black texture
        blk = new Texture2D(1, 1);
        blk.SetPixel(0, 0, new Color(0, 0, 0, 0));
        blk.Apply();
    }
    // put it on your screen
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blk);
    }

    void Update()
    {
        if (Input.GetKeyDown("space")) { fade = !fade; }


        if (!fade)
        {
            if (alph > 0)
            {
                alph -= Time.deltaTime * .4f;
                if (alph < 0) { alph = 0f; }
                blk.SetPixel(0, 0, new Color(0, 0, 0, alph));
                blk.Apply();
            }
        }
        if (fade)
        {
            if (alph < 1)
            {
                alph += Time.deltaTime * .4f;
                if (alph > 1) { alph = 1f; }
                blk.SetPixel(0, 0, new Color(0, 0, 0, alph));
                blk.Apply();
            }
        }
    }
}
