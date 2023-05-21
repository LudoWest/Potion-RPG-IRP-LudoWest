using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LightFlicker : MonoBehaviour
{

    private float lightOnTimer;
    private float lightOffTimer;
    private Image lightImage;
    private TextMeshProUGUI lightText;

    [SerializeField]
    private Color offColor;
    [SerializeField]
    private bool doesFlicker = true;

    // Start is called before the first frame update
    void Start()
    {
        lightImage = GetComponent<Image>();
        lightText = GetComponent<TextMeshProUGUI>();
        lightOnTimer = Random.Range(0.5f, 10.0f);
        lightOffTimer = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (doesFlicker)
        {
            lightOnTimer -= Time.deltaTime;
            lightOffTimer -= Time.deltaTime;

            if (lightOnTimer < 0.0f)
            {
                lightOnTimer = Random.Range(0.5f, 10.0f);
                lightOffTimer = Random.Range(0.1f, 0.15f);
                lightImage.color = offColor;
            }

            if (lightOffTimer < 0.0f)
            {
                lightOffTimer = 15.0f;
                lightImage.color = Color.white;
            }
        }
        
    }

    public void LightSwitch()
    {
        if (lightImage.color == Color.white)
        {
            lightImage.color = offColor;
        }
        else
        {
            lightImage.color = Color.white;
        }
    }

    public void LightText()
    {
        if (lightText.color == Color.white)
        {
            lightText.color = offColor;
        }
        else
        {
            lightText.color = Color.white;
        }
    }
}
