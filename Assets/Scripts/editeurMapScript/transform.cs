using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transform : MonoBehaviour
{
    public bool X;
    public bool Y;
    public bool Z;
    public bool XYZ;
    public bool Xmoins;
    public bool Ymoins;
    public bool Zmoins;
    public bool XYZmoins;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void X_()
    {
        X = true;
        Y = false;
        Z = false;
        XYZ = false;
        Xmoins = false;
        Ymoins = false;
        Zmoins = false;
        XYZmoins = false;
    }
    public void Y_()
    {
        Y = true;
        X = false;
        Z = false;
        XYZ = false;
        Xmoins = false;
        Ymoins = false;
        Zmoins = false;
        XYZmoins = false;
    }
    public void Z_()
    {
        Z = true;
        Y = false;
        X = false;
        XYZ = false;
        Xmoins = false;
        Ymoins = false;
        Zmoins = false;
        XYZmoins = false;

    }
    public void XYZ_()
    {
        XYZ = true;
        X = false;
        Y = false;
        Z = false;
        Xmoins = false;
        Ymoins = false;
        Zmoins = false;
        XYZmoins = false;


    }

    public void Xmoins_()
    {
        Xmoins = true;
        X = false;
        Y = false;
        Z = false;
        XYZ = false;
        Ymoins = false;
        Zmoins = false;
        XYZmoins = false;

    }
    public void Ymoins_()
    {
        Ymoins = true;
        X = false;
        Y = false;
        Z = false;
        XYZ = false;
        Xmoins = false;
        XYZmoins = false;
        Zmoins = false;
        XYZmoins = false;

    }
    public void Zmoins_()
    {
        Zmoins = true;
        X = false;
        Y = false;
        Z = false;
        XYZ = false;
        Xmoins = false;
        Ymoins = false;
        XYZmoins = false;

    }
    public void XYZmoins_()
    {
        XYZmoins = true;
        X = false;
        Y = false;
        Z = false;
        XYZ = false;
        Xmoins = false;
        Zmoins = false;
        Ymoins = false;
      

    }


}
