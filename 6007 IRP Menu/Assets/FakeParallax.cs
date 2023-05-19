using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FakeParallax : MonoBehaviour
{
    [SerializeField]
    float lookDistance = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(Vector2.zero, new Vector2(mouseScreenPos.x, mouseScreenPos.y) * 2.5f, lookDistance);
    }
}
