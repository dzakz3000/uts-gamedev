using UnityEngine;
using System;

public class BelajarDelegate : MonoBehaviour
{
    public delegate void AksiDelegate();

    void Start()
    {
        CobaDelegate1();
        CobaDelegate2();
        CobaDelegate3();
    }

    void CobaDelegate1()
    {
        AksiDelegate halo = PanggilHalo;
        halo();
    }

    void CobaDelegate2()
    {
        AksiDelegate halo = PanggilHalo;
        halo += PanggilWorld;
        halo();
    }

    void CobaDelegate3()
    {
        AksiDelegate halo = PanggilHalo;
        halo += PanggilWorld;
        halo -= PanggilHalo;
        halo();
    }

    void PanggilHalo()
    {
       Debug.Log("Halo");
    }

    void PanggilWorld()
    {
        Debug.Log("World");
    }

    void PanggilHalo2()
    {
        Debug.Log("Halo");
    }
}
