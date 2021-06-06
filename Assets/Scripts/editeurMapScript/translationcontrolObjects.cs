using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translationcontrolObjects : MonoBehaviour
{
    // Start is called before the first frame update
    
    private bool hit;
    private RaycastHit hitInfo = new RaycastHit();
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        controlObjectPos();


    }
    private void controlObjectPos()
    {

        hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
        GameObject g = GameObject.Find("scripts");

        float inputMouseX = Input.mousePosition.x;

        if (Input.GetButton("Fire2"))
        {
            if (g.GetComponent<operation>().translate == true)
            {

                if (hit)
                {
                    if (hitInfo.transform.gameObject.tag == "sol")
                    {
                        combineTranslation();
                    }


                }
            }
        }

    }

    private void combineTranslation()
    {
        translateX();
        translateY();
        translateZ();
        translateXYZ();
        translateXmoins_();
        translateYmoins_();
        translateZmoins_();
        translateXYZmoins_();
    }
    private void translateX()
    {
        GameObject t = GameObject.Find("scripts");
        GameObject g = GameObject.Find("scripts");
        if (t.GetComponent<transform>().X == true)
        {
            hitInfo.transform.gameObject.transform.Translate(g.transform.GetComponent<sliderSpeedControl>().speedTranslate, 0, 0);
        }
    }
    private void translateY()
    {
        GameObject t = GameObject.Find("scripts");
        GameObject g = GameObject.Find("scripts");
        if (t.GetComponent<transform>().Y == true)
        {
            hitInfo.transform.gameObject.transform.Translate(0, g.transform.GetComponent<sliderSpeedControl>().speedTranslate, 0);
        }
    }
    private void translateZ()
    {
        GameObject t = GameObject.Find("scripts");
        GameObject g = GameObject.Find("scripts");
        if (t.GetComponent<transform>().Z == true)
        {
            hitInfo.transform.gameObject.transform.Translate(0, 0, g.transform.GetComponent<sliderSpeedControl>().speedTranslate);
    }
}
    private void translateXYZ()
    {
        GameObject t = GameObject.Find("scripts");
        GameObject g = GameObject.Find("scripts");
        if (t.GetComponent<transform>().XYZ == true)
        {
            hitInfo.transform.gameObject.transform.Translate(g.transform.GetComponent<sliderSpeedControl>().speedTranslate, g.transform.GetComponent<sliderSpeedControl>().speedTranslate, g.transform.GetComponent<sliderSpeedControl>().speedTranslate);
        }
    }


    private void translateXmoins_()
    {
        GameObject t = GameObject.Find("scripts");
        GameObject g = GameObject.Find("scripts");
        if (t.GetComponent<transform>().Xmoins == true)
        {
            hitInfo.transform.gameObject.transform.Translate(-g.transform.GetComponent<sliderSpeedControl>().speedTranslate, 0, 0);
        }
    }
    private void translateYmoins_()
    {
        GameObject t = GameObject.Find("scripts");
        GameObject g = GameObject.Find("scripts");
        if (t.GetComponent<transform>().Ymoins == true)
        {
            hitInfo.transform.gameObject.transform.Translate(0, -g.transform.GetComponent<sliderSpeedControl>().speedTranslate, 0);
        }
    }
    private void translateZmoins_()
    {
        GameObject t = GameObject.Find("scripts");
        GameObject g = GameObject.Find("scripts");
        if (t.GetComponent<transform>().Zmoins == true)
        {
            hitInfo.transform.gameObject.transform.Translate(0, 0, -g.transform.GetComponent<sliderSpeedControl>().speedTranslate);
        }
    }
    private void translateXYZmoins_()
    {
        GameObject t = GameObject.Find("scripts");
        GameObject g = GameObject.Find("scripts");
        if (t.GetComponent<transform>().XYZmoins == true)
        {
            hitInfo.transform.gameObject.transform.Translate(-g.transform.GetComponent<sliderSpeedControl>().speedTranslate, -g.transform.GetComponent<sliderSpeedControl>().speedTranslate, -g.transform.GetComponent<sliderSpeedControl>().speedTranslate);
        }
    }




}
