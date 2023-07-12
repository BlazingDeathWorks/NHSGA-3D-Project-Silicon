using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMaterial : MonoBehaviour
{
    public Material material1;
    public Material material2;
    public void setToMaterial1()
    {
        GetComponent<Renderer>().material = material1;
    }
    public void setToMaterial2()
    {
        GetComponent<Renderer>().material = material2;
    }
}
