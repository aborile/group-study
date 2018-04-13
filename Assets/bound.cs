using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bound : MonoBehaviour
{
    
    //public float thrust = 1;
    public Rigidbody player;
    public Renderer pRen, cRen;
    public WDColor chg;

    /*
    public static float gravy = Physics.gravity.y;
    public static float len = (float)1.9 * 6;
    public static float v = Mathf.Sqrt(2 * len * gravy / Mathf.Sqrt(3));
    public float valy = v * Mathf.Sqrt(3) / 2;
    public float valz = v / 2;
    */
    public float gos, gou;
    // Use this for initialization
    void Start()
    {
        gos = (float)5.2886338279088022816502776210371;
        gou = (float)9.1601824925655238128142625022436;
        chg = new WDColor();
        player = GetComponent<Rigidbody>();
        //player.velocity = new Vector3(0, 0, valz);
        player.velocity = new Vector3(0, 0, gos);

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
            player.AddForce(Vector3.left * 3f);
            //거리길어질수잇음
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
            player.AddForce(Vector3.right * 3f);
            //Debug.Log(player.velocity);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Land")
        {
            //Debug.Log(player.velocity);
            //player.velocity = new Vector3(player.velocity.x, valy, valz);
            player.velocity = new Vector3(player.velocity.x, gou, player.velocity.z);
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