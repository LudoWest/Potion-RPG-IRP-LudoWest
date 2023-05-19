using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDarkener : MonoBehaviour
{
    //Serialize Variables
    [SerializeField]
    List<Image> toDarken = new List<Image>();
    [SerializeField]
    List<Image> toGhost = new List<Image>();
    [SerializeField]
    List<GameObject> toSwitch = new List<GameObject>();
    [SerializeField]
    float changeSpeed = 0.1f;
    [SerializeField]
    Color darkColour;
    [Range(-0.5f, 1.5f)]
    [SerializeField]
    float changeProgress;


    //Other Variables
    bool turningNight = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Slowly change day to night, if it's been long enough on one or another, start changing it back the other way.
        if (turningNight)
        {
            changeProgress += changeSpeed * Time.deltaTime;
            if(changeProgress > 1.5f)
            {
                turningNight = false;
            }
        }
        else
        {
            changeProgress -= changeSpeed * Time.deltaTime;
            if(changeProgress < -0.5f)
            {
                turningNight = true;
            }
        }
        foreach(Image currentImage in toDarken)
        {
            Color currentColour = currentImage.color;

            //Darken each colour component by lerping it towards the darkened colour.
            currentColour.r = Mathf.Lerp(Color.white.r, darkColour.r, changeProgress);
            currentColour.g = Mathf.Lerp(Color.white.g, darkColour.g, changeProgress);
            currentColour.b = Mathf.Lerp(Color.white.b, darkColour.b, changeProgress);

            currentImage.color = currentColour;
        }
        foreach(Image currentImage in toGhost)
        {
            Color currentColour = currentImage.color;

            //Ghostify the colour component by lerping it towards 0. (Transparent)
            currentColour.a = Mathf.Lerp(1.0f, 0.0f, changeProgress);
            currentImage.color = currentColour;
        }
    }

    public void MassSwitch()
    {
        StartCoroutine(WaitSwitch(0.2f));
    }

    IEnumerator WaitSwitch(float inputSeconds)
    {
        foreach(GameObject currentSwitch in toSwitch)
        {
            yield return new WaitForSeconds(inputSeconds);
            currentSwitch.GetComponent<SpringDynamics>().SwitchPos();
        }
        toSwitch.Reverse();
    }
}
