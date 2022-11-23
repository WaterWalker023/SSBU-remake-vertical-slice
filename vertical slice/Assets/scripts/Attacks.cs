using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    public float playerY2;
    public GameObject hitbox;
    private GameObject HitboxInstance;
    private float frameWait= 0.016f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        playerY2 = Input.GetAxis("Vertical2");
        if (playerY2 >= 0.8||Input.GetKey(KeyCode.UpArrow))
        {
            upsmash();
        }
        Debug.Log(playerY2);
        if (Input.GetKeyDown("joystick button 2")||Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("punch");
            punch();
        }
        
    }

    IEnumerator punch()
    {
        Debug.Log("test");
        //animatie doen
        yield return new WaitForSeconds(0.016f);
        HitboxInstance = Instantiate(hitbox, new Vector3(0, 0, -0.923f), Quaternion.identity, gameObject.transform);
        Destroy(HitboxInstance, 0.05f);

    }

    public void upsmash()
    {
        //de animatie doen
    }
}
