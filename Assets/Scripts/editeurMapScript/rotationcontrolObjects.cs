using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationcontrolObjects : MonoBehaviour
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
        controlObjectRot();


    }
    private void controlObjectRot()
    {

        hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
        GameObject g = GameObject.Find("scripts");

        float inputMouseX = Input.mousePosition.x;

        if (Input.GetButton("Fire2"))
        {
            if (g.GetComponent<operation>().rotate == true)
            {

                if (hit)
                {
                    if (hitInfo.transform.gameObject.tag == "sol")
                    {
                        combineRotation();
                    }


                }
            }
        }

    }

    private void combineRotation()
    {
        rotateX();
        rotateY();
        rotateZ();
        rotateXYZ();
        rotateXmoins_();
        rotateYmoins_();
        rotateZmoins_();
        rotateXYZmoins_();
    }
    private void rotateX()
    {
        GameObject t = GameObject.Find("scripts");
        GameObject g = GameObject.Find("scripts");
        if (t.GetComponent<transform>().X == true)
        {
            hitInfo.transform.gameObject.transform.Rotate(g.transform.GetComponent<sliderSpeedControl>().speedRotate, 0, 0);
        }
    }
    private void rotateY()
    {
        GameObject t = GameObject.Find("scripts");
        GameObject g = GameObject.Find("scripts");
        if (t.GetComponent<transform>().Y == true)
        {
            hitInfo.transform.gameObject.transform.Rotate(0, g.transform.GetComponent<sliderSpeedControl>().speedRotate, 0);
        }
    }
    private void rotateZ()
    {
        GameObject t = GameObject.Find("scripts");
        GameObject g = GameObject.Find("scripts");
        if (t.GetComponent<transform>().Z == true)
        {
            hitInfo.transform.gameObject.transform.Rotate(0, 0, g.transform.GetComponent<sliderSpeedControl>().speedRotate);
    }
}
    private void rotateXYZ()
    {
        GameObject t = GameObject.Find("scripts");
        GameObject g = GameObject.Find("scripts");
        if (t.GetComponent<transform>().XYZ == true)
        {
            hitInfo.transform.gameObject.transform.Rotate(g.transform.GetComponent<sliderSpeedControl>().speedRotate, g.transform.GetComponent<sliderSpeedControl>().speedRotate, g.transform.GetComponent<sliderSpeedControl>().speedRotate);
        }
    }


    private void rotateXmoins_()
    {
        GameObject t = GameObject.Find("scripts");
        GameObject g = GameObject.Find("scripts");
        if (t.GetComponent<transform>().Xmoins == true)
        {
            hitInfo.transform.gameObject.transform.Rotate(-g.transform.GetComponent<sliderSpeedControl>().speedRotate, 0, 0);
        }
    }
    private void rotateYmoins_()
    {
        GameObject t = GameObject.Find("scripts");
        GameObject g = GameObject.Find("scripts");
        if (t.GetComponent<transform>().Ymoins == true)
        {
            hitInfo.transform.gameObject.transform.Rotate(0, -g.transform.GetComponent<sliderSpeedControl>().speedRotate, 0);
        }
    }
    private void rotateZmoins_()
    {
        GameObject t = GameObject.Find("scripts");
        GameObject g = GameObject.Find("scripts");
        if (t.GetComponent<transform>().Zmoins == true)
        {
            hitInfo.transform.gameObject.transform.Rotate(0, 0, -g.transform.GetComponent<sliderSpeedControl>().speedRotate);
        }
    }
    private void rotateXYZmoins_()
    {
        GameObject t = GameObject.Find("scripts");
        GameObject g = GameObject.Find("scripts");
        if (t.GetComponent<transform>().XYZmoins == true)
        {
            hitInfo.transform.gameObject.transform.Rotate(-g.transform.GetComponent<sliderSpeedControl>().speedRotate, -g.transform.GetComponent<sliderSpeedControl>().speedRotate, -g.transform.GetComponent<sliderSpeedControl>().speedRotate);
        }
    }




}
