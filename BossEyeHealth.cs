using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEyeHealth : MonoBehaviour {

    private int health = 2;

    [SerializeField]
    private string nameOfAmmo;

	private void Update () {
        if (health == 0)
        {
            gameObject.SetActive(false);
        }
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == nameOfAmmo)
        {
            health--;
        }
    }
}
