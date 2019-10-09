using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHit : MonoBehaviour {


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "EyeRight")
        {
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "EyeLeft")
        {
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "HandRight")
        {
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "HandLeft")
        {
            Destroy(col.gameObject);
        }
    }
}
