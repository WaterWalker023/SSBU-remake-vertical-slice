using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementProto : MonoBehaviour
{
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

    //[SerializeField] float gravity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundLayerMask;
    public bool isGrounded;
    public List<GameObject> grounds;

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
        else if (playerX == 1) // running rechts
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
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)) && jumpsleft != 0)
        {
            jumpsleft--;
            jump();
            //Debug.Log("jump");
        }
        if (isGrounded && grounds.Count > 0)
        {
            jumpsleft = 5;
        }
    }
    void jump()
    {
        rb.velocity = new Vector3(0, jumpstrength, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Solidground" || collision.transform.tag == "Platform")
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