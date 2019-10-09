using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowstickManager : MonoBehaviour
{
    [SerializeField]
    private Light light1;
    [SerializeField]
    private Light light2;

    public void RedLight()
    {
        Renderer renderer = GetComponent<Renderer>();
        Material mat = renderer.material;
        float emission = Mathf.PingPong(Time.time, 0.9f);
        Color baseColor = Color.red;
        Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);
        mat.SetColor("_EmissionColor", finalColor);
        light1.color = Color.red;
        light2.color = Color.red;
        light1.enabled = true;
        light2.enabled = true;
    }

    public void GreenLight()
    {
        Renderer renderer = GetComponent<Renderer>();
        Material mat = renderer.material;
        float emission = Mathf.PingPong(Time.time, 0.2f);
        Color baseColor = Color.green;
        Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);
        mat.SetColor("_EmissionColor", finalColor);
        light1.color = Color.green;
        light2.color = Color.green;
        light1.enabled = true;
        light2.enabled = true;
    }

    public void DeadLight()
    {
        Renderer renderer = GetComponent<Renderer>();
        Material mat = renderer.material;
        float emission = Mathf.PingPong(Time.time, 0.1f);
        Color baseColor = Color.gray;
        Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);
        mat.SetColor("_EmissionColor", finalColor);
        light1.enabled = false;
        light2.enabled = false;
    }
}
