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
    [SerializeField] private float jab2Cooldown;
    [SerializeField] private float ChargeCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetButton("a"))
        {
            ExecuteAttack(Jab);
        }

        if (Input.GetKey(KeyCode.Q) || Input.GetButton("b"))
        {
            ChargeCounter++;
        }

        if (Input.GetKeyUp(KeyCode.Q) || Input.GetButton("b"))
        {
            if (ChargeCounter <= 19 && ChargeCounter >= 10)
            {
                Rollout.Damage = 11;
            }

            if (ChargeCounter <= 29 && ChargeCounter >= 20)
            {
                Rollout.Damage = 12;
            }

            if (ChargeCounter <= 39 && ChargeCounter >= 30)
            {
                Rollout.Damage = 13;
            }

            if (ChargeCounter <= 49 && ChargeCounter >= 40)
            {
                Rollout.Damage = 14;
            }

            if (ChargeCounter <= 59 && ChargeCounter >= 50)
            {
                Rollout.Damage = 15;
            }

            if (ChargeCounter <= 69 && ChargeCounter >= 60)
            {
                Rollout.Damage = 16;
            }

            if (ChargeCounter <= 79 && ChargeCounter >= 70)
            {
                Rollout.Damage = 17;
            }

            if (ChargeCounter <= 89 && ChargeCounter >= 80)
            {
                Rollout.Damage = 18;
            }

            if (ChargeCounter <= 99 && ChargeCounter >= 90)
            {
                Rollout.Damage = 19;
            }

            if (ChargeCounter >= 100)
            {
                Rollout.Damage = 20;
            }

            ChargeCounter = 0;

            ExecuteAttack(Rollout);
        }

        if (Input.GetKey(KeyCode.R) /*|| Input.GetAxis("")*/)
        {
            ChargeCounter++;
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            if(ChargeCounter <= 32 && ChargeCounter >= 10)
            {
                UpSmash.Damage = 13;
            }

            if (ChargeCounter <= 66 && ChargeCounter >= 33)
            {
                UpSmash.Damage = 14;
            }

            if (ChargeCounter >= 66)
            {
                UpSmash.Damage = 15;
            }

            ChargeCounter = 0;

            ExecuteAttack(UpSmash);
        }

        if (Input.GetKeyDown(KeyCode.T) || Input.GetButton("a"))
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

            if (attack.name == "Jab")
            {
                timer += Time.deltaTime;

                if (timer < jab2Cooldown && (Input.GetKeyDown(KeyCode.E) || Input.GetButton("a")))
                {
                    ExecuteAttack(Jab2);
                }
            }

            attack = null;
        }
    }

    public void ExecuteAttack(Attack attack)
    {
        this.attack = attack;
        Debug.Log(attack.name);
        //animatie doen
        //jigglypuff.damage = attack.damage;
    }
}