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




    float playerX;
    float playerY;
    float playerX2;
    float playerY2;
    [SerializeField] float walkingspeed;
    [SerializeField] float runningspeed;
    [SerializeField] float jumpstrength;
    [SerializeField] int jumpsleft;
    [SerializeField] Rigidbody rb;
    buttonmapping buttons;
    [SerializeField] bool playerY08;
    [SerializeField] bool playerY082;

    //[SerializeField] float gravity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundLayerMask;
    public bool isGrounded;
    public List<GameObject> grounds;
    //public float force;
    public double force;

    // Start is called before the first frame update
    void Start()
    {
        buttons = GameObject.Find("Main Camera").GetComponent<controllerdetector>().player1;
    }

    // Update is called once per frame
    void Update()
    { 

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayerMask);
        playerX = Input.GetAxis("Horizontal");
        playerY = Input.GetAxis("Vertical");
        playerX2 = Input.GetAxis("Horizontal2");
        playerY2 = Input.GetAxis("Vertical2");
        
        //Debug.Log("("+playerX + ", " +playerY+ ", " + playerX2 + ", " + playerY2 + ")");
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
        /*
        if (playerY > 0.8 && playerY08)
        {
            playerY08 = true;
            playerY082 = true;
        }
        else if (playerY < 0.8 || playerY082)
        {
            playerY082 = false;
        }
        */
        if ((Input.GetKeyDown("joystick " + buttons.noord) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick " + buttons.west) || (playerY08 && playerY082)) && jumpsleft != 0)  
        {
            playerY08 = false;
            jumpsleft--;
            jump();
            //Debug.Log("jump");
        }

        if (isGrounded && grounds.Count > 0)
        {
            jumpsleft = 5;
        }
        if (attacked)
        {
            attacked = false;
            Debug.Log((((percentage / 10)+((percentage*damage)/20)*(200/(weight+100)*1.4)+18)*scaling)+baseknockback);
            force = (((percentage / 10) + ((percentage * damage) / 20) * (200 / (weight + 100) * 1.4) + 18) * scaling) + baseknockback;
            rb.AddForce(((float)force) * Mathf.Cos(angleatteck), ((float)force) * Mathf.Sin(angleatteck), 0);
        }

    }
    void jump()
    {
        rb.velocity = new Vector3(0, jumpstrength, 0);
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