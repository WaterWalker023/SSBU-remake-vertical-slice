using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jigglypuff : MonoBehaviour
{
    public double force;
    public bool attacked;
    public float percentage; //     de percentage van gameobject counted after the attack's damage is added
    public float damage; //         damage van last attack 
    public float weight; //         de weight van gameobject
    public float scaling; //        the attack's knockback scaling (also known as knockback growth) divided by 100 (so a scaling of 110 is input as 1.1).
    public float baseknockback; //  attack's base knockback.
    public float angleatteck; //    de angle van de atteck 

    [SerializeField] Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (attacked || Input.GetKeyDown(KeyCode.T))
        {
            attacked = false;
            Debug.Log((((percentage / 10) + ((percentage * damage) / 20) * (200 / (weight + 100) * 1.4) + 18) * scaling) + baseknockback);
            force = (((percentage / 10) + ((percentage * damage) / 20) * (200 / (weight + 100) * 1.4) + 18) * scaling) + baseknockback;
            rb.AddForce(((float)force) * Mathf.Cos(angleatteck), ((float)force) * Mathf.Sin(angleatteck), 0);
            percentage += damage;
        }
        if (transform.position.y <= -30 || transform.position.x <= -30 || transform.position.x >= 30 ||transform.position.y >= 30)
        {
            transform.position = new Vector3(2.83f, 2.04f, 0f);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            percentage = 0;
        }
    }
}
