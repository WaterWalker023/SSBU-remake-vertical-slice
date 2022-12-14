using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoAttacks : MonoBehaviour
{
    private GameObject HitboxInstance;
    [SerializeField] private Attack Rollout;
    [SerializeField] private Attack UpSmash;
    [SerializeField] private Attack Jab;
    [SerializeField] private Attack Jab2;
    [SerializeField] private Attack attack;
    private float jab2Cooldown;
    private float UpsmashChargeCounter;
    private float RolloutChargeCounter;
    private float timer;
    private float PlayerY2;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        PlayerY2 = Input.GetAxis("Vertical2");
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown("joystick button 2"))
        {
            ExecuteAttack(Jab);
        }
        if (Input.GetKey(KeyCode.Q) || Input.GetKey("joystick button 1"))
        {
            RolloutChargeCounter++;
        }
        if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp("joystick button 1"))
        {
            Rollout.Damage += RolloutChargeCounter / 60;
            
            RolloutChargeCounter = 0;
            ExecuteAttack(Rollout);
        }
        if (RolloutChargeCounter >= 222)
        {
            RolloutChargeCounter = 0;
            Rollout.Damage = 25.2f;
            ExecuteAttack(Rollout);
        }
        if (Input.GetKey(KeyCode.R) || PlayerY2 >= 0.8)
        {
            UpsmashChargeCounter += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.R) || PlayerY2 < 0)
        {
            UpSmash.Damage = 15;
            UpSmash.Damage += UpsmashChargeCounter / 60;
            UpsmashChargeCounter = 0;
            ExecuteAttack(UpSmash);
        }
        if (UpsmashChargeCounter >= 222)
        {
            UpsmashChargeCounter = 0;
            UpSmash.Damage = 25.2f;
            ExecuteAttack(UpSmash);
        }
        if (Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown("joystick button 2"))
        {
            ExecuteAttack(Jab2);
        }
        if (attack != null)
        {
            timer += Time.deltaTime;
            if (timer > attack.SpawnDelay && timer < attack.DespawnDelay)
            {
                HitboxInstance = Instantiate(attack.Hitbox, transform.position + new Vector3(0, 0, -0.923f), Quaternion.identity);
                Debug.Log(HitboxInstance);
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
                    timer = 0;
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
        /*jigglypuff.damage += attack.damage;
         * jigglypuff.Scaling = attack.Scaling;
         * jigglypuff.BaseKnockBack = attack.BaseKnockBack;
         * jigglypuff.AngleAttack = attack.AngleAttack;
         */
    }
}