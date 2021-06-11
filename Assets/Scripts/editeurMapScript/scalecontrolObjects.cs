using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scalecontrolObjects : MonoBehaviour
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
        controlObjectScaling();


    }
    private void controlObjectScaling()
    {

        hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
        GameObject g = GameObject.Find("scripts");

        float inputMouseX = Input.mousePosition.x;

        if (Input.GetButton("Fire2"))
        {
            if (g.GetComponent<operation>().scale == true)
            {

                if (hit)
                {
                    if (hitInfo.transform.gameObject.tag == "sol")
                    {
                        combineScaling();
                    }


                }
            }
        }

    }

    private void combineScaling()
    {
        scaleX();
        scaleY();
        scaleZ();
        scaleXYZ();
        scaleXmoins_();
        scaleYmoins_();
        scaleZmoins_();
        scaleXYZmoins_();
    }
    private void scaleX()
    {
        GameObject t = GameObject.Find("scripts");
        GameObject g = GameObject.Find("scripts");
        if (t.GetComponent<transform>().X == true)
        {
            hitInfo.transform.gameObject.transform.localScale+=new Vector3(g.transform.GetComponent<sliderSpeedControl>().speedScale, 0, 0);
        }
    }
    private void scaleY()
    {
        GameObject t = GameObject.Find("scripts");
        GameObject g = GameObject.Find("scripts");
        if (t.GetComponent<transform>().Y == true)
        {
            hitInfo.transform.gameObject.transform.localScale += new Vector3(g.transform.GetComponent<sliderSpeedControl>().speedScale,0, 0);
        }
    }
    private void scaleZ()
    {
        GameObject t = GameObject.Find("scripts");
        GameObject g = GameObject.Find("scripts");
        if (t.GetComponent<transform>().Z == true)
        {
            hitInfo.transform.gameObject.transform.localScale += new Vector3(0, 0, g.transform.GetComponent<sliderSpeedControl>().speedScale);
    }
}
    private void scaleXYZ()
    {
        GameObject t = GameObject.Find("scripts");
        GameObject g = GameObject.Find("scripts");
        if (t.GetComponent<transform>().XYZ == true)
        {
            hitInfo.transform.gameObject.transform.localScale += new Vector3(g.transform.GetComponent<sliderSpeedControl>().speedScale, g.transform.GetComponent<sliderSpeedControl>().speedScale, g.transform.GetComponent<sliderSpeedControl>().speedScale);
        }
    }


    private void scaleXmoins_()
    {
        GameObject t = GameObject.Find("scripts");
        GameObject g = GameObject.Find("scripts");
        if (t.GetComponent<transform>().Xmoins == true)
        {
            hitInfo.transform.gameObject.transform.localScale += new Vector3(-g.transform.GetComponent<sliderSpeedControl>().speedScale, 0, 0);
        }
    }
    private void scaleYmoins_()
    {
        GameObject t = GameObject.Find("scripts");
        GameObject g = GameObject.Find("scripts");
        if (t.GetComponent<transform>().Ymoins == true)
        {
            hitInfo.transform.gameObject.transform.localScale += new Vector3(0, -g.transform.GetComponent<sliderSpeedControl>().speedScale, 0);
        }
    }
    private void scaleZmoins_()
    {
        GameObject t = GameObject.Find("scripts");
        GameObject g = GameObject.Find("scripts");
        if (t.GetComponent<transform>().Zmoins == true)
        {
            hitInfo.transform.gameObject.transform.localScale += new Vector3(0, 0, -g.transform.GetComponent<sliderSpeedControl>().speedScale);
        }
    }
    private void scaleXYZmoins_()
    {
        GameObject t = GameObject.Find("scripts");
        GameObject g = GameObject.Find("scripts");
        if (t.GetComponent<transform>().XYZmoins == true)
        {
            hitInfo.transform.gameObject.transform.localScale += new Vector3(-g.transform.GetComponent<sliderSpeedControl>().speedScale, -g.transform.GetComponent<sliderSpeedControl>().speedScale, -g.transform.GetComponent<sliderSpeedControl>().speedScale);
        }
    }




}
