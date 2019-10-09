using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAddForce : MonoBehaviour {

    Rigidbody rigidB;
    public float shootForce = 33000;


    public Shoot NF;

    void OnEnable () {
        rigidB = GetComponent<Rigidbody>();
        rigidB.velocity = Vector3.zero;
        ApplyForce();
	}
	
	
	void Update () {
        SpinObjectInAir();

	}

    void ApplyForce()
    {
        rigidB.AddRelativeForce(Vector3.forward * shootForce);
    }

    void SpinObjectInAir()
    {
        float _yVelocity = rigidB.velocity.y;
        float _xVelocity = rigidB.velocity.x;
        float _zVelocity = rigidB.velocity.z;
        float _combinedVelocity = Mathf.Sqrt(_xVelocity * _xVelocity + _zVelocity * _zVelocity);
        float _fallAngle = -1*Mathf.Atan2(_yVelocity, _combinedVelocity) * 180 / Mathf.PI;

        transform.eulerAngles = new Vector3(_fallAngle, transform.eulerAngles.y, transform.eulerAngles.x);
    }

    void OnTriggerEnter(Collider col)
    {
       

        if (col.gameObject.name == "EyeRight" || col.gameObject.tag == "EyeRight")
        {
            Debug.Log("EyeRight");
            DestroyProjectile();

        }

        if (col.gameObject.name == "EyeLeft" || col.gameObject.tag == "EyeLeft")
        {
            Debug.Log("EyeLeft");
            DestroyProjectile();
        }

        if (col.gameObject.name== "HandRight")
        {
            DestroyProjectile();
        }

        if (col.gameObject.name == "HandLeft")
        {
            DestroyProjectile();
        }
        
    }

    void DestroyProjectile()
    {
        StartCoroutine(Blijf(0.01f));
    }

    IEnumerator Blijf(float waitTime)
    { 
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
        GameObject.Destroy(gameObject);
        Destroy(this.gameObject);
    }

}
