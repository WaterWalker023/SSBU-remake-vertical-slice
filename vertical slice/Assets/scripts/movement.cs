using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class movement : MonoBehaviour
{
    public bool attacked;
    public float percentage; //     de percentage van gameobject counted after the attack's damage is added
    public float damage; //         damage van last attack 
    public float weight; //         de weight van gameobject
    public float scaling; //        the attack's knockback scaling (also known as knockback growth) divided by 100 (so a scaling of 110 is input as 1.1).
    public float baseknockback; //  attack's base knockback.
    public float angleatteck; //    de angle van de atteck 

    [SerializeField] float walkingspeed;
    [SerializeField] float runningspeed;
    [SerializeField] float jumpstrength;
    [SerializeField] int jumpsleft;
    [SerializeField] bool isjumping;
    [SerializeField] float isjumpingtimer;
    [SerializeField] Rigidbody rb;
    //buttonmapping buttons;
    //[SerializeField] bool playerY08;
    //[SerializeField] bool playerY082;
    public float offset;

    //[SerializeField] float gravity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundLayerMask;
    public bool isGrounded;
    public List<GameObject> grounds;
    public List<GameObject> platform;
    public double force;
    bool movedoorplatform;
    float movedoorplatformtimer;

    // Start is called before the first frame update
    void Start()
    {
        //buttons = GameObject.Find("Main Camera").GetComponent<controllerdetector>().player1;
    }

    // Update is called once per frame
    void Update()
    { 

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayerMask);
        /*
        playerX = Input.GetAxis("Horizontal");
        playerY = Input.GetAxis("Vertical");
        playerX2 = Input.GetAxis("Horizontal2");
        playerY2 = Input.GetAxis("Vertical2");
        
        
        if (playerX == 0)// standing stil
        {

        }
        else  if (playerX == 1) // running rechts
        {
            transform.position += new Vector3(runningspeed, 0, 0) * Time.deltaTime;
        }
        else if (playerX == -1) // running links
        {
            transform.position += new Vector3(-runningspeed, 0, 0) * Time.deltaTime;
        }
        else if (playerX >= -1 && playerX <= 0) // walking links
        {
            transform.position += new Vector3(-walkingspeed, 0, 0) * Time.deltaTime;
        }
        else if (playerX <= 1 && playerX >= 0) // walking rechts
        {
            transform.position += new Vector3(walkingspeed, 0, 0) * Time.deltaTime;
        }
        */
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += new Vector3(runningspeed, 0, 0) * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(walkingspeed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += new Vector3(-runningspeed, 0, 0) * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-walkingspeed, 0, 0) * Time.deltaTime;
        }

        isjumpingtimer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))  
        {
            //jump();
            isjumping = true;
            //Debug.Log("jump");
        }
        if (isjumping)
        {
            isjumping = false;
            if(isjumpingtimer > 0.8f)
            {
                isjumpingtimer = 0;
                jump();
            }
            else if (isjumpingtimer > 0.6f)
            {
                isjumping = true;
            }
        }
        if (isGrounded && grounds.Count > 0)
        {
            jumpsleft = 5;
        }
        if (attacked || Input.GetKeyDown(KeyCode.R))
        {
            attacked = false;
            //Debug.Log((((percentage / 10) + ((percentage * damage) / 20) * (200 / (weight + 100) * 1.4) + 18) * scaling) + baseknockback);
            force = (((percentage / 10) + ((percentage * damage) / 20) * (200 / (weight + 100) * 1.4) + 18) * scaling) + baseknockback;
            rb.AddForce(((float)force) * Mathf.Cos(angleatteck), ((float)force) * Mathf.Sin(angleatteck), 0);
            percentage += damage;
        }
        if (transform.position.y <= -30 || transform.position.x <= -30 || transform.position.x >= 30 || transform.position.y >= 30)
        {
            transform.position = new Vector3(-2.97f, 2.24f, 0f);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            percentage = 0;
        }
        movedoorplatformtimer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!movedoorplatform)
            {
                movedoorplatformtimer = 0;
                for (int i = 0; i < platform.Count; i++)
                {
                    Physics.IgnoreCollision(transform.GetComponent<Collider>(), platform[i].GetComponent<Collider>(), true);
                }
            }
            movedoorplatform = true;
        }
        else if (movedoorplatform && movedoorplatformtimer >= 0.5f && !Input.GetKey(KeyCode.S))
        {
            movedoorplatform = false;
            for (int i = 0; i < platform.Count; i++)
            {
                Physics.IgnoreCollision(transform.GetComponent<Collider>(), platform[i].GetComponent<Collider>(), false);
            }

        }
        


    }
    void jump()
    {
        if (jumpsleft > 0)
        {
            jumpsleft--;
            rb.AddForce(0, jumpstrength, 0);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Solidground" || collision.transform.tag == "Platform")
        {
            grounds.Add(collision.gameObject);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Solidground" || collision.transform.tag == "Platform")
        {
            grounds.Remove(collision.gameObject);
        }
    }

}