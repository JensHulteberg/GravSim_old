using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float speed = 4;
    public float JumpHeight = 1.2f;
    public Rigidbody rb;

    float distanceToGround;
    bool OnGround;
    Vector3 Groundnormal;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
        Attractor[] attractors = FindObjectsOfType<Attractor>();
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        float dist;
        foreach (Attractor attractor in attractors)
        {
            
        }

        //Movement
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(x, 0, z);

        //jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * 40000 * JumpHeight);

        }

        //Ground control
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(transform.position, -transform.up, out hit, 10))
        {

            distanceToGround = hit.distance;
            Groundnormal = hit.normal;

            if (distanceToGround <= 1f)
            {
                OnGround = true;
            }
            else
            {
                OnGround = false;
            }

        }
    }
}
