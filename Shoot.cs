using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Shoot : MonoBehaviour {

    [SerializeField]
    float pullSpeed;
    [SerializeField]
    GameObject arrowPrefab;
    [SerializeField]
    GameObject arrow;
    [SerializeField]
    int numberOfArrows = 10;
    [SerializeField]
    GameObject bow;
    bool arrowSlotted = false;
    float pullAmount = 0;

    [SerializeField]
    private GameObject[] balls;


    [SerializeField]
    public Transform target;
    [Header("Attributes")]
    public float range = 1045f;
    public float fireRate = 1f;
    public float fireCountdown = 0f;
    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public GameObject Arrow;
    public Transform firePoint;
    public float turnSpeed = 10f;


    public bool EenOfDrie = false;
    [SerializeField]
    public int i = 0;



    void Start()
    {
        SpawnArrow();

    }
	
	
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            EenOfDrie = !EenOfDrie;
        }

        if (EenOfDrie == false)
        {
            UpdateTarget();
            transform.LookAt(target);
            if (arrowSlotted == false)
            {
                SpawnArrow();

            }

            if (EenOfDrie == false)
            {
                ShootLogic();
            }
            fireCountdown -= Time.deltaTime;

        }

        if (EenOfDrie == true)
        {
            //Dan gebeurt er nog ff niks
        }


        

	}

  


    
    public void SpawnArrow()
    {
        if(numberOfArrows > 0)
        {
            Rigidbody _arrowRigidB = arrow.transform.GetComponent<Rigidbody>();
            ProjectileAddForce _arrowProjectile = arrow.transform.GetComponent<ProjectileAddForce>();
            arrowSlotted = true;
            arrow = Instantiate(arrowPrefab, transform.position, transform.rotation) as GameObject;
            arrow.transform.parent = transform;
        }
    }

    public void ShootLogic()
    {
        if(numberOfArrows > 0)
        {
            if (pullAmount > 100)
                pullAmount = 100;
            
           Rigidbody _arrowRigidB = arrow.transform.GetComponent<Rigidbody>();
            ProjectileAddForce _arrowProjectile = arrow.transform.GetComponent<ProjectileAddForce>();


         //*  if (Input.GetMouseButtonDown(0) && arrowSlotted == false)
          //  {
          //      SpawnArrow();
          //      pullAmount += Time.deltaTime * pullSpeed;
           // }

            if (Input.GetMouseButtonUp(0))
            {
                arrowSlotted = false;
                _arrowRigidB.isKinematic = false;
                arrow.transform.parent = null;
                _arrowProjectile.shootForce = _arrowProjectile.shootForce * ((pullAmount / 100) + .05f);
                numberOfArrows -= 1;

                pullAmount = 0;

                _arrowProjectile.enabled = true;
            }

            

        }
    }



    //Third person shooting
    void UpdateTarget()
    {

            if (Input.GetKeyDown("f"))
            {
                if ( i < 1)
                {
                 i++;
                target = balls[i].transform;
            }

                else
                {
                i = 0;
                target = balls[i].transform;
            }

            }
        

    }


}
