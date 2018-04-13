using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMYK
{
    public float c;
    public float m;
    public float y;
    public float k;
    /*
    public CMYK()
    {

    }
    public CMYK(float c, float m, float y, float k)
    {
        this.c = c;
        this.m = m;
        this.y = y;
        this.k = k;
    }
    */
    public CMYK add(CMYK cmyk)
    {
        CMYK val = new CMYK();
        val.c = this.c + cmyk.c;
        val.m = this.m + cmyk.m;
        val.y = this.y + cmyk.y;
        val.k = (this.k > cmyk.k ? cmyk.k : this.k);
        if (val.c > 1) val.c = 1;
        if (val.m > 1) val.m = 1;
        if (val.y > 1) val.y = 1;
        //if (val.k > 1) val.k = 1;
        return val;
    }
    public void print()
    {
        Debug.Log("C: " + this.c);
        Debug.Log("M: " + this.m);
        Debug.Log("Y: " + this.y);
        Debug.Log("K: " + this.k);
    }
}

public class WDColor {
    public bool self = true;
    public CMYK rtoC(UnityEngine.Color rgb)
    {
        CMYK cmy = new CMYK();
        float inR = rgb.r;
        float inG = rgb.g;
        float inB = rgb.b;
        float r = inR / 255;
        float g = inG / 255;
        float b = inB / 255;
        float k;
        if (r > g)
        {
            if (r > b) { k = 1 - r; }
            else { k = 1 - b; }
        }
        else if (g > b) { k = 1 - g; }
        else { k = 1 - b; }
        cmy.c = (1 - r - k) / (1 - k);
        cmy.m = (1 - g - k) / (1 - k);
        cmy.y = (1 - b - k) / (1 - k);
        cmy.k = k;
        if (cmy.c > 1) cmy.c = 1;
        if (cmy.c < 0) cmy.c = 0;
        if (cmy.m > 1) cmy.m = 1;
        if (cmy.m < 0) cmy.m = 0;
        if (cmy.y > 1) cmy.y = 1;
        if (cmy.y < 0) cmy.y = 0;
        if (cmy.k > 1) cmy.k = 1;
        if (cmy.k < 0) cmy.k = 0;
        return cmy;
    }

    public UnityEngine.Color ctoR(CMYK cmyk)
    {
        float c = cmyk.c;
        float m = cmyk.m;
        float y = cmyk.y;
        float k = cmyk.k;
        UnityEngine.Color rgb = new UnityEngine.Color();
        rgb.r = 255 * (1 - c) * (1 - k);
        rgb.g = 255 * (1 - m) * (1 - k);
        rgb.b = 255 * (1 - y) * (1 - k);
        if (rgb.r > 255) rgb.r = 255;
        else if (rgb.r < 0) rgb.r = 0;
        if (rgb.g > 255) rgb.g = 255;
        else if (rgb.g < 0) rgb.g = 0;
        if (rgb.b > 255) rgb.b = 255;
        else if (rgb.b < 0) rgb.b = 0;
        return rgb;
    }
}
