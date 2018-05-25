using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bound : MonoBehaviour
{
    
    //public float thrust = 1;
    public Rigidbody player;
    public Renderer pRen, cRen;
    public WDColor chg;
    public GameObject plane;
    
    public float valx, valy, valz, xz, val, len;
    /*
    void Vec()
    {
        float g = Physics.gravity.y;
        float h = 3 * Mathf.Sqrt(3);
        float len = (float) 1.9 * h;
        float v = Mathf.Sqrt(2 * len * g / Mathf.Sqrt(3));
        float y = v * Mathf.Sqrt(3) / 2;
        float xz = v / 2;

        v = 10.573353772573771211921517960743
        y = 9.1567929702489178861460072896
        xz = 5.2866768862868856059607589803715
    }
    */
    // Use this for initialization
    void Start()
    {
        valz = (float)5.2866768862868856059607589803715;
        xz = valz;
        valy = (float)9.1567929702489178861460072896;
        val = Mathf.Sqrt(valz * valz + valy * valy) / 2;
        len = (float)9.7726896031426005731064441465835;
        chg = new WDColor();
        player = GetComponent<Rigidbody>();
        plane = GameObject.Find("Plane");
        //player.velocity = new Vector3(0, 0, valz);
        player.velocity = new Vector3(0, 0, valz);
        plane.transform.position = new Vector3(0, (float)1.21, len/2 - (float)0.5);
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(transform.forward * thrust);
        //rb.AddForce(0, 0, thrust, ForceMode.Impulse);
        //transform.position += Vector3.forward;
        //if (Input.GetButtonDown("Jump"))
        /*
        if (player.position.y <= 1)
        {
            player.velocity = new Vector3(0, 10, 5);
        }
        */
        if (Input.GetKey(KeyCode.A)){
            /*
            Vector3 tmpv = player.velocity;
            tmpv[0] -= (float)0.2;
            player.velocity = tmpv;
            */
            //Debug.Log(player.velocity);
            float curx = player.velocity.x;
            float curz = player.velocity.z;
            float dx;
            if (-1 * curx < xz)
            {
                if (-1 * curx < xz - 0.1)
                {
                    dx = (float)0.1 * (-1);
                    curx += dx;
                }
                else
                {
                    dx = -1 * xz - curx;
                    curx = -1 * xz;
                }
                float newz = Mathf.Sqrt(xz * xz - curx * curx);
                player.velocity = new Vector3(curx, player.velocity.y, newz);
                plane.transform.Translate(len / val * dx / (float)1.5, 0, (newz - curz) * len / val / (float)1.5);
            }
            //Debug.Log(player.velocity);
        }
        if (Input.GetKey(KeyCode.D))
        {
            /*
            Vector3 tmpv = player.velocity;
            tmpv[0] += (float)0.2;
            player.velocity = tmpv;
            */
            //Debug.Log(player.velocity);
            float curx = player.velocity.x;
            float curz = player.velocity.z;
            float dx;
            if (curx < xz)
            {
                if (curx < xz - 0.1)
                {
                    dx = (float)0.1;
                    curx += dx;
                }
                else
                {
                    dx = xz - curx;
                    curx = xz;
                }
                float newz = Mathf.Sqrt(xz * xz - curx * curx);
                player.velocity = new Vector3(curx, player.velocity.y, newz);

                plane.transform.Translate(len/val*dx/(float)1.5, 0, (newz-curz)*len/val/(float)1.5);
            }
            //Debug.Log(player.velocity);
        }
        //Debug.Log(player.position.y);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Land")
        {
            Debug.Log(player.position);
            Debug.Log(plane.transform.position);
            //Debug.Log(player.velocity);
            //player.velocity = new Vector3(player.velocity.x, valy, valz);
            player.velocity = new Vector3(player.velocity.x, valy, player.velocity.z);
            //player.AddForce(0, (-1)*player.velocity.y, 0);
            //Debug.Log(player.velocity);

            pRen = player.gameObject.GetComponent<Renderer>();
            Color pcRGB = pRen.material.GetColor("_Color");
            CMYK pcCMY = chg.rtoC(pcRGB);

            cRen = col.gameObject.GetComponent<Renderer>();
            Color ccRGB = cRen.material.GetColor("_Color");
            CMYK ccCMY = chg.rtoC(ccRGB);

            Color newc = chg.ctoR(pcCMY.add(ccCMY));
            pRen.material.SetColor("_Color", newc);

            //Debug.Log(player.transform.position.z);

            plane.transform.Translate(player.velocity.x/val*len, 0, player.velocity.z/val*len);
        }
        if(col.tag == "Respawn")
        {
            Debug.Log("great");
        }
    }
}