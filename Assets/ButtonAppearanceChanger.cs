using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAppearanceChanger : MonoBehaviour {

    public Material standard;
    public Material hover;
    public Material click;

    Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void SetStandard()
    {
        image.material = standard;
    }

    public void SetHover()
    {
        image.material = hover;
    }
    public void SetClick()
    {
        image.material = click;
    }
}
