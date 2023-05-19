using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    float cloudSpeed;
    // Start is called before the first frame update
    void Start()
    {
        cloudSpeed = Random.Range(25.0f, 125.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<RectTransform>().anchoredPosition -= new Vector2(cloudSpeed * Time.deltaTime, 0);
        if(GetComponent<RectTransform>().anchoredPosition.x < -1300.0f)
        {
            GetComponent<RectTransform>().anchoredPosition = new Vector2(1300.0f, GetComponent<RectTransform>().anchoredPosition.y);
        }
    }
}
