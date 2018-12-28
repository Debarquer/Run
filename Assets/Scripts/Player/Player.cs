using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    
    [Tooltip("Default is 0.8")] public float trailFadeRate;

    [FMODUnity.EventRef]
    public string LandingSound;

    [FMODUnity.EventRef]
    public string DashSound;

    [FMODUnity.EventRef]
    public string JumpingSound;

    public bool canMove;

    //[FMODUnity.EventRef]
    //public string playerMoveSound;
    //FMOD.Studio.EventInstance WalkingSound;

    //FMOD.Studio.ParameterInstance stopOrGo;



    [Header("Stamina")]
    [Tooltip("Whether nor not the player will move up or down during a dash")]public bool fixedDashY = false;
    [Tooltip("Requires fixedDashY to be false. Whether or not the player will be affected by gravity during a dash.")]public bool dashGravity = false;
    bool isRunning = false;

    public float maxStamina;
    float stamina;

    float alpha;
    bool endedSprint;

    public float staminaGainSpeed = 1f;
    public float staminaDecaySpeed = 1f;

    public Color maxStaminaColor;
    public Color noStaminaColor;

    public Vector3 runningVelocity = Vector3.zero;

    MeshRenderer mr;
    TrailRenderer tr;

    [SerializeField] ParticleSystem jumpEffect;
    [SerializeField] ParticleSystem landEffect;
 
    [Header("Jumping")]
    public bool velocityBasedGrounded = true;
    public bool grounded = true;
    [Tooltip("The time between grounded being set to true and it being possible to be set to false again.")]public float groundedPhysicsTimeOffsetMax = 0.2f;
    float groundedPhysicsTimeOffsetCurr = 0;
    public float jumpPower = 8;

    public Vector3 gravity = new Vector3(0, -9.81f * 1.5f, 0);
    public Vector3 maxVelocity;
    public Vector3 minVelocity;

    [Header("Walking")]
    public Vector3 friction;
    public bool dashing = false;
    public float dashSpeedMod = 2f;
    public float speed = 6;
    public Vector3 velocity;
    public Vector3 lastFrameVelocity;
    //public Vector3 scriptVelocty;

    [Header("On death")]
    public string nextScene;

    Vector3 lastPosition;

    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody>().useGravity = false;
        mr = GetComponent<MeshRenderer>();
        tr = GetComponent<TrailRenderer>();

        lastPosition = transform.position;
        //WalkingSound = FMODUnity.RuntimeManager.CreateInstance(playerMoveSound);
        //WalkingSound.getParameter("Stoporgo", out stopOrGo);
        //WalkingSound.start();
    }

    // Update is called once per frame
    void Update () {
        CheckPlayerInput();

        Stamina();

        if (endedSprint) {
            FadeTrail();
        }

        if (!fixedDashY || !dashing)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            FixedMovement();
        }
        else
        {
            Vector3 previousVelocity = GetComponent<Rigidbody>().velocity;
            GetComponent<Rigidbody>().velocity = new Vector3(0, previousVelocity.y, 0);
        }

        if ((!fixedDashY && dashGravity) || !dashing)
        {
            AddGravity();
        }
    }

    private void CheckPlayerInput()
    {
        if ((Input.GetButton("KeyboardSprint") || Input.GetAxisRaw("ControllerSprint") > 0.19f))
        {
            StartSprint();
        }
        //else if (Input.GetKeyUp(KeyCode.LeftShift))
        //{
        //    EndSprint();
        //}
    }

    private void StartSprint()
    {
        if (!dashing && maxStamina - stamina < 0.1f)
        {
            dashing = true;
            tr.enabled = true;
            alpha = 1;
            //speed *= speedMod;
            runningVelocity = GetComponent<Rigidbody>().velocity;
            runningVelocity.y = 0;
            runningVelocity *= dashSpeedMod;
            FMODUnity.RuntimeManager.PlayOneShot(DashSound);
        }
    }

    private void EndSprint()
    {
        if (dashing)
        {
            dashing = false;
            //speed /= speedMod;
            endedSprint = true;
            runningVelocity = Vector3.zero;
        }
    }

    void FadeTrail() {
        alpha -= trailFadeRate * Time.deltaTime;
        tr.startColor = new Color(mr.material.color.r, mr.material.color.g, mr.material.color.b, alpha);
        if (alpha <= trailFadeRate) { 
            endedSprint = false;
            tr.enabled = false;
        }
    }

    void Stamina()
    {
        //public float staminaStartRecoverMax = 1f;
        //public float staminaStartRecover;
        //public float staminaRecoverMax = 5f;
        //public float staminaRecover;
        if (dashing)
        {
            stamina -= staminaDecaySpeed * Time.deltaTime;
            if (stamina <= 0)
            {
                stamina = 0;
                EndSprint();
            }
        }
        else
        {
            stamina += staminaGainSpeed * Time.deltaTime;

            if (stamina >= maxStamina)
                stamina = maxStamina;
        }

        mr.material.color = Color.Lerp(noStaminaColor, maxStaminaColor, stamina / maxStamina);
        tr.startColor = mr.material.color;
    }

    void Jump()
    {
        velocity = GetComponent<Rigidbody>().velocity;

        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                FMODUnity.RuntimeManager.PlayOneShot(JumpingSound);
                //GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 1.0f, 0.0f) * 2f, ForceMode.Impulse);
                velocity = new Vector3(velocity.x, jumpPower, velocity.z);
                Object ps = Instantiate(jumpEffect, transform.position, Quaternion.identity);
                Destroy(ps, 1);
            }
        }

        if (!velocityBasedGrounded)
        {
            Ray ray = new Ray(new Vector3(transform.position.x, transform.position.y - 0.501f, transform.position.z), Vector3.down);
            RaycastHit hitinfo;
            Physics.Raycast(ray, out hitinfo);

            //if (hitinfo.collider == null)
            //{
            //    return;
            //}
            //if (hitinfo.collider.isTrigger)
            //{
            //    return;
            //}


            Ray rayA = new Ray(new Vector3(transform.position.x + 0.49f, transform.position.y, transform.position.z + 0.49f), Vector3.down);
            RaycastHit hitinfoA;
            Physics.Raycast(rayA, out hitinfoA);

            Ray rayB = new Ray(new Vector3(transform.position.x + 0.49f, transform.position.y, transform.position.z - 0.49f), Vector3.down);
            RaycastHit hitinfoB;
            Physics.Raycast(rayB, out hitinfoB);

            Ray rayC = new Ray(new Vector3(transform.position.x - 0.49f, transform.position.y, transform.position.z + 0.49f), Vector3.down);
            RaycastHit hitinfoC;
            Physics.Raycast(rayC, out hitinfoC);

            Ray rayD = new Ray(new Vector3(transform.position.x - 0.49f, transform.position.y, transform.position.z - 0.49f), Vector3.down);
            RaycastHit hitinfoD;
            Physics.Raycast(rayD, out hitinfoD);

            if (Mathf.Abs(transform.position.y - hitinfoA.point.y) < 1.01f ||
                Mathf.Abs(transform.position.y - hitinfoB.point.y) < 1.01f ||
                Mathf.Abs(transform.position.y - hitinfoC.point.y) < 1.01f ||
                Mathf.Abs(transform.position.y - hitinfoD.point.y) < 1.01f)
            {
                if (grounded != true)
                {
                    grounded = true;
                    FMODUnity.RuntimeManager.PlayOneShot(LandingSound);
                }
                //GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 0, GetComponent<Rigidbody>().velocity.z);
            }
            else
            {
                grounded = false;
            }
        }
        else
        {
            if (velocity.y > 0)
            {
                groundedPhysicsTimeOffsetCurr += Time.deltaTime;
                if (groundedPhysicsTimeOffsetCurr > groundedPhysicsTimeOffsetMax)
                {
                    if (grounded)
                    {
                        grounded = false;
                    }
                }
            }
            else if (Mathf.Abs(velocity.y) < 0.5f && lastFrameVelocity.y < 0.1f)
            {
                groundedPhysicsTimeOffsetCurr = 0;

                if (!grounded)
                {
                    grounded = true;
                    Debug.Log("Hit th ground");
                    Instantiate(landEffect, transform.position, Quaternion.identity);
                    FMODUnity.RuntimeManager.PlayOneShot(LandingSound);
                }
            }
        }

        if (velocity.x > maxVelocity.x)
        {
            velocity.x = maxVelocity.x;
        }
        if (velocity.x < minVelocity.x)
        {
            velocity.x = minVelocity.x;
        }

        if (velocity.y > maxVelocity.y)
        {
            velocity.y = maxVelocity.y;
        }
        if (velocity.y < minVelocity.y)
        {
            velocity.y = minVelocity.y;
        }

        if (velocity.z > maxVelocity.z)
        {
            velocity.z = maxVelocity.z;
        }
        if (velocity.z < minVelocity.z)
        {
            velocity.z = minVelocity.z;
        }

        GetComponent<Rigidbody>().velocity = velocity;
    }

    void AddGravity()
    {
        GetComponent<Rigidbody>().AddForce(gravity);
    }

    void FixedMovement()
    {
        AddForceMovement();

        lastFrameVelocity = velocity;
        velocity = GetComponent<Rigidbody>().velocity;
        if ((velocity.x != 0 || velocity.z != 0) && grounded)
        {
            if (!isRunning)
            {
                isRunning = true;

                //Debug.Log("SPAMMING");
                //stopOrGo.setValue(1f);
                //Debug.Log(stopOrGo.ToString());

            }
        }
        else
        {
            //stopOrGo.setValue( 0f);
            if (isRunning)
            {
                isRunning = false;
                //Debug.Log(stopOrGo.ToString());
            }
        }

        if (dashing)
        {
            //Vector3 newSpeed = new Vector3(velocity.x * dashSpeedMod,
            //                               0,
            //                               velocity.z * dashSpeedMod);
            if(!fixedDashY){
                GetComponent<Rigidbody>().velocity = new Vector3(runningVelocity.x, GetComponent<Rigidbody>().velocity.y, runningVelocity.z);
            }
            else{
                GetComponent<Rigidbody>().velocity = runningVelocity;
            }
            return;
        }
        
        float x = GetComponent<Rigidbody>().velocity.x;
        float z = GetComponent<Rigidbody>().velocity.z;

        x /= friction.x;
        z /= friction.z;

        if(x < 0.1f)
        {
            x = 0;
        }
        if (z < 0.1f)
        {
            z = 0;
        }

        GetComponent<Rigidbody>().velocity = new Vector3(x, velocity.y, z);
    }

    void AddForceMovement()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal") + Input.GetAxisRaw("DPadHorizontal"), 0, Input.GetAxisRaw("Vertical") + Input.GetAxisRaw("DPadVertical"));

        direction.Normalize();
        GetComponent<Rigidbody>().AddForce(direction * speed * Time.deltaTime, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Destroy(GameObject.FindWithTag("Player"));
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene, UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.parent != null && collision.transform.parent.name == "PushingPillar")
        {
            Debug.Log("Collided with pillar");
            GetComponent<Rigidbody>().AddForce(collision.transform.right * 10, ForceMode.Impulse);
        }
    }
}
