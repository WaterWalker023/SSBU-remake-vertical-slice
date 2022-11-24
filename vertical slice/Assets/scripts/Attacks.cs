using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    private float timer;
    public float delay;
    public float secondDelay;
    public GameObject Hitbox;
    private GameObject HitboxInstance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(timer > delay && timer < secondDelay)
        {
            HitboxInstance = Instantiate(Hitbox, new Vector3(0, 0, -0.923f), Quaternion.identity, gameObject.transform);
        }
        if (timer > secondDelay)
        {
            Destroy(HitboxInstance);
        }
    }

    void ExecuteAttack()
    {
        Debug.Log("test");
        //animatie doen
    }

    /*IEnumerator punch2()
    {
        yield return new WaitUntil(AnimationDone == true);
        HasPunched = false;
        Debug.Log("test");
        //animatie doen
        yield return new WaitForSeconds(0.048f); //wacht 3 frames
        HitboxInstance = Instantiate(PunchHitbox2, new Vector3(0, 0, -0.923f), Quaternion.identity, gameObject.transform);
        Destroy(HitboxInstance, 0.016f);
        StopAllCoroutines();
    }

    IEnumerator upsmash()
    {
        Debug.Log("test");
        //de animatie doen
            yield return new WaitForSeconds(0.192f); //wacht 12 frames
            HitboxInstance = Instantiate(UpsmashHitbox, new Vector3(0,0,-0.923f), Quaternion.identity, gameObject.transform);
            Destroy(HitboxInstance, 1.4f);
            StopAllCoroutines();
        
    }*/
}
