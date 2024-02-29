using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statPanel : MonoBehaviour
{
    public string ballType;
    public Sprite ballImage;
    public Color imageColor;

    public GameObject ImageObject;
    public GameObject TextObject;

    public Text BallNameText;
    public Image image;

    private void Awake()
    {
        BallNameText = TextObject.GetComponent<Text>();
        image = ImageObject.GetComponent<Image>();
    }

    public void SetPanel()
    {
        BallNameText.text = ballType;
        image.sprite = ballImage;
        image.color = imageColor;
    }

    public void deactivate()
    {
        this.gameObject.SetActive(false);
    }
}