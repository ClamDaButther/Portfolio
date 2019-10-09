using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenManager : MonoBehaviour
{
    [SerializeField]
    private Light light1;
    [SerializeField]
    private Light light2;

    public void RedLight()
    {
        light1.color = Color.red;
        light2.color = Color.red;
        light1.enabled = true;
        light2.enabled = true;
    }

    public void YellowLight()
    {
        light1.color = Color.yellow;
        light2.color = Color.yellow;
        light1.enabled = true;
        light2.enabled = true;
    }

    public void DeadLight()
    {
        light1.enabled = false;
        light2.enabled = false;
    }
}
