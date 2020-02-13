using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        bobing = new Vector2( Random.Range(0f, Mathf.PI*2), Random.Range(0f, Mathf.PI*2));
	}
	
    public Vector3 Acceleration;

    public Quaternion Facing
    {
        get { return _Facing; }
        set {
            _Facing = value;
            facingSet = true;
        }
    }
    Quaternion _Facing = Quaternion.identity;
    bool facingSet = false;

    public GameObject WakePrefab;

    float wakeThreshold = 4f;
    float wakeCooldown = 0;

    Rigidbody rb;

    Vector2 bobing;
    public float bobIntensity = 20f;
    public float bobSpeed = 1f;

    public float waterLevel = 0;

    public bool AffectedByExplosions = true;

    public bool Ropeable = false;

	// Update is called once per frame
	void FixedUpdate () {
        //if(GameManager.isPaused)
        //    return;

        //if(GetComponent<Health>() != null && GetComponent<Health>().isDead == true)
        //{
        //    return;
        //}

        wakeCooldown -= Time.deltaTime;

        // Do buoyancy
        if(this.transform.position.y < waterLevel)
        {
            //Acceleration.y = 10 * Time.deltaTime;
            Vector3 v = rb.velocity;
            v.y = 100 * Time.deltaTime * (waterLevel - this.transform.position.y);
            rb.velocity = v;
        }
        else {
            // Apply gravity, since we're overriding otherwise.
            //Acceleration.y = rb.velocity.y;

            if(OnSurface())
            {
                rb.drag = 1;
            }
            else {
                rb.drag = 0;
            }
        }

        //rb.velocity = Acceleration;
        Acceleration.y = 0;
        //rb.AddForce(Acceleration, ForceMode.Force);

        // Keep upright

        bobing.x += Time.deltaTime * bobSpeed;
        bobing.y += Time.deltaTime * bobSpeed / 3f;

        Quaternion upRot = Quaternion.Euler(
            Mathf.Sin(bobing.x) * bobIntensity,
            rb.rotation.eulerAngles.y,
            Mathf.Sin(bobing.y) * bobIntensity
        );

        if(facingSet == true)
        {
            upRot = Quaternion.Euler(
                Mathf.Sin(bobing.x) * bobIntensity,
                Facing.eulerAngles.y,
                Mathf.Sin(bobing.y) * bobIntensity
            );
            facingSet = false;
        }

        rb.rotation = upRot;
            
        if(WakePrefab != null && 
            rb.velocity.magnitude > wakeThreshold &&
            OnSurface()
        )
        {
            SpawnWake();
        }

	}

    public bool OnSurface()
    {
        return (this.transform.position.y - 1) <= waterLevel;
    }

    void SpawnWake()
    {
        if(wakeCooldown > 0)
            return;

        wakeCooldown = 0.1f;

        Vector3 pos = this.transform.position;
        pos.y = waterLevel;

        //Instantiate(WakePrefab, pos, Quaternion.Euler(0, this.transform.rotation.eulerAngles.y, 0));
    }
}
