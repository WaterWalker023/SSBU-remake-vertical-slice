using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoAttacks : MonoBehaviour
{
    private float timer;
    private GameObject HitboxInstance;
    [SerializeField] private Attack Rollout;
    [SerializeField] private Attack UpSmash;
    [SerializeField] private Attack Jab;
    [SerializeField] private Attack Jab2;
    [SerializeField] private Attack attack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ExecuteAttack(Jab);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            ExecuteAttack(Rollout);
        }

        if (Input.GetKey(KeyCode.R))
        {
            ExecuteAttack(UpSmash);
        }

        if (Input.GetKey(KeyCode.T))
        {
            ExecuteAttack(Jab2);
        }

        if (attack != null)
        {
            timer += Time.deltaTime;
            if (timer > attack.SpawnDelay && timer < attack.DespawnDelay)
            {
                HitboxInstance = Instantiate(attack.Hitbox, transform.position + new Vector3(0, 0, -0.923f), Quaternion.identity);
            }

            if (timer > attack.DespawnDelay)
            {
                Destroy(HitboxInstance);
            }
            timer = 0;
        }
    }

    public void ExecuteAttack(Attack attack)
    {
        this.attack = attack;
        Debug.Log(attack.name);
        //animatie doen
        //doe damage
    }
}
