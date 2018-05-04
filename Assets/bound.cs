using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bound : MonoBehaviour
{
    
    //public float thrust = 1;
    public Rigidbody player;
    public Renderer pRen, cRen;
    public WDColor chg;
    
    public float valx, valy, valz, xz;
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
        chg = new WDColor();
        player = GetComponent<Rigidbody>();
        //player.velocity = new Vector3(0, 0, valz);
        player.velocity = new Vector3(0, 0, valz);
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
            if (-1 * curx < xz)
            {
                if (-1 * curx < xz - 0.1)
                {
                    curx -= (float)0.1;
                }
                else
                {
                    curx = -1 * xz;
                }
            }
            float newz = Mathf.Sqrt(xz * xz - curx * curx);
            player.velocity = new Vector3(curx, player.velocity.y, newz);
            Debug.Log(player.velocity);
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
            if (curx < xz)
            {
                if (curx < xz - 0.1)
                {
                    curx += (float)0.1;
                }
                else
                {
                    curx = xz;
                }
            }
            float newz = Mathf.Sqrt(xz * xz - curx * curx);
            player.velocity = new Vector3(curx, player.velocity.y, newz);
            //Debug.Log(player.velocity);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Land")
        {
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
            //그리고 타일높이는 6이 맞을까 거지같은 포물선...
        }
    }
}