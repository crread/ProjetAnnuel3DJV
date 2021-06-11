using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class instantiateCube : MonoBehaviour
{
    public GameObject prefab;
    public instantiate inst;
    public InputField input;
    private bool hit;
    private bool detectCubeRef=false;
    public RaycastHit hitInfo = new RaycastHit();
    public RaycastHit hitInfo2 = new RaycastHit();
    GameObject clone;
    Transform clone2;
    public bool[] changeCol;
  



    float r, g, b;
    // Start is called before the first frame update
    public static int IntParseFast(string value)
    {
        int result = 0;
        for (int i = 0; i < value.Length; i++)
        {
            char letter = value[i];
            result = 10 * result + (letter - 48);
        }
        return result;
    }
    public void placerCube_base()
    {

        string x = input.text;
      
       
        for (int i = 0; i < IntParseFast(x); i++)
            for (int j = 0; j < IntParseFast(x); j++)
            {
                clone = Instantiate(prefab, new Vector3(IntParseFast(x) + (i * IntParseFast(x)), 0, IntParseFast(x) + (j * IntParseFast(x))), transform.rotation);
               
                clone.transform.localScale = new Vector3(IntParseFast(x), IntParseFast(x), IntParseFast(x));

                changeMaterialColor(clone.transform);


            }
    }
    public void destroy_map()
    {
        hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

     

        float inputMouseX = Input.mousePosition.x;
        string x = input.text;
        var placedObject = GameObject.FindWithTag("cubeDetect");

        if (Input.GetKey(KeyCode.X))
        {
            if (hit)
            {
                if (hitInfo.transform.gameObject.tag == "cubeDetect")
                {
                    changeCol[2] = true;
                }
                if (changeCol[2])
                {
                    print("hh");
                    Destroy(placedObject);

                }
            }
        }




    }
    private void changeMaterialColor(Transform pref)
    {
       
        var cubeRenderer = pref.GetComponent<Renderer>();

        r = Random.Range(0.0f, 1.0f);
        g = Random.Range(0.0f, 1.0f);
        b = Random.Range(0.0f, 1.0f);

        cubeRenderer.material.color = new Color(r, g,b);
    }
    private void changeMaterialColorRed(Transform pref)
    {

        var cubeRenderer = pref.GetComponent<Renderer>();

        cubeRenderer.material.color = new Color(100.5f,100.5f,100.5f);
    }
    private void controlObject()
    {

        hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
       // hit2 = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo2);


        float inputMouseX = Input.mousePosition.x;
        string x = input.text;


        if (Input.GetButton("Fire2"))
        {


            if (hit)
            {


                if(hitInfo.transform.gameObject.tag == "cubeRef")
                {
                    changeCol[0] = true;
                    changeCol[1] = false;
                }
                if (hitInfo.transform.gameObject.tag == "cubeRef2")
                {
                    changeCol[1] = true;
                    changeCol[0] = false;
                }

                if (hitInfo.transform.gameObject.tag == "cubeDetect" && changeCol[0])
                {
                    //hitInfo2.transform.Translate(new Vector3(20, 0, 0));

                    changeMaterialColorRed(hitInfo.transform);

                    inst.clone[0].localPosition = new Vector3(hitInfo.transform.position.x, hitInfo.transform.position.y + IntParseFast(x), hitInfo.transform.position.z);
                    inst.clone[0].localScale = new Vector3(IntParseFast(x), IntParseFast(x), IntParseFast(x));
                }
           

                if (hitInfo.transform.gameObject.tag == "cubeDetect" && changeCol[1])
                {
                    inst.clone[1].localPosition = new Vector3(hitInfo.transform.position.x, hitInfo.transform.position.y + IntParseFast(x), hitInfo.transform.position.z);
                    inst.clone[1].localScale = new Vector3(IntParseFast(x), IntParseFast(x), IntParseFast(x));

                }







            }
        }
        if (Input.GetButton("Fire3"))
        {


            if (hit)
            {
                if (hitInfo.transform.gameObject.tag == "cubeDetect")
                {


                    changeCol[0] = false;
                    changeCol[1] = false;

                    changeMaterialColor(hitInfo.transform);



                }

            }
        }


        }
    /*
    public void instance()
    {
        GameObject g = GameObject.Find("scripts");
        
        for (int i = 0; i < 1; i++)
            clone2 = Instantiate(prefab2, new Vector3(g.GetComponent<sliderTransform>().positionX, g.GetComponent<sliderTransform>().positionY + (i * 2), g.GetComponent<sliderTransform>().positionZ), transform.rotation);
    }
    */
    void Start()
    {
   
    }


    // Update is called once per frame
    void Update()
{
        destroy_map();
        controlObject();
      
      
    }
}
