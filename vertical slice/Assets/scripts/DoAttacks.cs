using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class DoAttacks : MonoBehaviour
{
    private GameObject HitboxInstance;
    [SerializeField] private Attack Rollout;
    [SerializeField] private Attack UpSmash;
    [SerializeField] private Attack Jab;
    [SerializeField] private Attack Jab2;
    [SerializeField] private Attack attack;
    private float jab2Cooldown = 2f;
    private float UpsmashChargeCounter;
    private float RolloutChargeCounter;
    private float timer;
    private float RolloutChargeTimer;
    private float UpSmashChargeTimer;
    public Rigidbody rb;
    private float RolloutForce = 1;
    public Jigglypuff jigglypuffScript;
    public Animator animator;
    public Transform ME;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ExecuteAttack(Jab);
        }

        if (Input.GetKey(KeyCode.O))
        {
            RolloutChargeCounter += Time.deltaTime;
            RolloutChargeTimer += Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.O))
        {
            RolloutChargeTimer = 0;
            Rollout.Damage += (RolloutChargeCounter / 60);
            RolloutForce += RolloutChargeCounter * 60;
            RolloutChargeCounter = 0;
            ExecuteAttack(Rollout);
            rb.AddForce(RolloutForce, 0, 0);
        }

        if (RolloutChargeTimer >= 3.7)
        {
            RolloutForce += RolloutChargeCounter * 60;
            RolloutChargeTimer = 0;
            RolloutChargeCounter = 0;
            Rollout.Damage = 25.2f;
            ExecuteAttack(Rollout);
            rb.AddForce(RolloutForce, 0, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            UpsmashChargeCounter += Time.deltaTime;
            UpSmashChargeTimer += Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            UpSmashChargeTimer = 0;
            UpSmash.Damage = 15;
            UpSmash.Damage += UpsmashChargeCounter / 60;
            UpsmashChargeCounter = 0;
            ExecuteAttack(UpSmash);
        }

        if (UpSmashChargeTimer >= 3.7)
        {
            UpSmashChargeTimer = 0;
            UpsmashChargeCounter = 0;
            UpSmash.Damage = 25.2f;
            ExecuteAttack(UpSmash);
        }

        if (attack != null)
        {
            timer += Time.deltaTime;
            
            if (timer > attack.SpawnDelay && timer < attack.DespawnDelay)
            {
                if (HitboxInstance == null)
                {
                    HitboxInstance = Instantiate(attack.Hitbox,transform.position, Quaternion.identity);
                    HitboxInstance.transform.parent = this.transform;
                }
                
                if (attack.name == "rollout")
                {
                    Physics.IgnoreCollision(transform.GetComponent<Collider>(), HitboxInstance.GetComponent<Collider>(), true);
                    HitboxInstance.transform.position = rb.transform.position;
                }
                else
                {
                    Physics.IgnoreCollision(transform.GetComponent<Collider>(), HitboxInstance.GetComponent<Collider>(), true);
                    HitboxInstance.transform.position = (rb.transform.position + new Vector3(1f, 0.5f, 0));
                }
            }

            if (attack.name == "Jab")
            {
                timer += Time.deltaTime;
                if (timer < jab2Cooldown && (Input.GetKeyDown(KeyCode.P)))
                {
                    ExecuteAttack(Jab2);
                }
            }
            if (timer > attack.DespawnDelay)
            {
                Destroy(HitboxInstance);
                attack = null;
                timer = 0;
                if(attack.name == "upsmash")
                {
                    attack.Damage = 15;
                }
                if (attack.name == "rollout")
                {
                    attack.Damage = 10;
                }
            }

        }
    }

    public void ExecuteAttack(Attack attack)
    {
        this.attack = attack;
        Debug.Log(attack.name);
        if(attack.name == "upsmash")
        {
            animator.Play("upsmash");
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Jigglypuff")
        {
            jigglypuffScript.damage = attack.Damage;
            jigglypuffScript.Scaling = attack.Scaling;
            jigglypuffScript.BaseKnockBack = attack.BaseKnockBack;
            jigglypuffScript.AngleAttack = attack.AngleAttack;
            jigglypuffScript.attacked = true;
            Debug.Log("Aan raak");
            rb.velocity = Vector3.zero;

        }
    }
    
}
