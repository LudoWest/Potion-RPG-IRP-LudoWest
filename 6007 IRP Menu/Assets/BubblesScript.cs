using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubblesScript : MonoBehaviour
{
    private RectTransform rect;
    private Vector2 startPos;
    private float randomOffset;

    [SerializeField]
    private float floatStrength = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        startPos = rect.anchoredPosition;
        randomOffset = Random.Range(0.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        rect.anchoredPosition = startPos + new Vector2(0.0f, Mathf.Sin(Time.time + randomOffset) * floatStrength);
    }
}
