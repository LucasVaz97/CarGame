using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphere : MonoBehaviour
{
    public Rigidbody theRB;

    public float forward=8f,reverseace=4f, maxspeed=10f, turnStreght=180f ;
    private float speedInput, turnInput;
    public float gravityForce = 10f;
    private bool grounded;
    public LayerMask whatisGround;
    public Transform groundRayPoint;
    public float dragOnGround;
    public ParticleSystem[] dustTrial;
    public float maxEmission = 25;
    public float emissionRate;
    public float checkpoint=0;
    public bool boosting;
    public float boostTime=-1f;

    public Transform wheel1, wheel2;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("Time", 1000);
        checkpoint = 0;
        theRB.transform.parent = null;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (boostTime > 0)
        {
            boosting = true;
            speedInput = 2.3f * forward * 1000f;
            boostTime = boostTime - Time.deltaTime;
           
        }
        else
        {
            boosting = false;
            speedInput = 0f;
        }



        if (Input.GetAxis("Vertical") > 0 && !boosting)
        {
            speedInput = Input.GetAxis("Vertical") * forward * 1000f;

        }
        else if (Input.GetAxis("Vertical") < 0 && !boosting)
        {
            speedInput = Input.GetAxis("Vertical") * reverseace * 500f;
        }

        turnInput = Input.GetAxis("Horizontal");

        if (grounded)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStreght * Time.deltaTime, 0f));
        }

        transform.position = theRB.transform.position+new Vector3(0,-0.3f,0);
        wheel1.localRotation = Quaternion.Euler(wheel1.localRotation.eulerAngles.x, (turnInput * 25) - 180, wheel1.localRotation.z);
        wheel2.localRotation = Quaternion.Euler(wheel2.localRotation.eulerAngles.x, (turnInput * 25) , wheel2.localRotation.z);

    }

    private void FixedUpdate()
    {

        emissionRate = 0;

        RaycastHit hit;
        if(Physics.Raycast(groundRayPoint.position,-transform.up,out hit, 1f, whatisGround))
        {
            grounded = true;

            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;

        }



        else
        {
            grounded = false;
        }

        if (grounded)
        {
            theRB.drag = dragOnGround;
            if (Mathf.Abs(speedInput) > 0)
            {
                emissionRate = maxEmission;
                theRB.AddForce(transform.forward * speedInput);
            }
        }
        else
        {
            theRB.drag = 0.1f;
            theRB.AddForce(Vector3.up * -gravityForce * 100f);
        }
        foreach(ParticleSystem part in dustTrial)
        {
            var emissionModule = part.emission;
            emissionModule.rateOverTime = emissionRate;
           
        }


    }

    public void StartBoost()
    {

        boostTime = 3f;

    }


}
