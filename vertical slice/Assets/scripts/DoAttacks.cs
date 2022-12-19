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

    private float jab2Cooldown;
    private float UpsmashChargeCounter;
    private float RolloutChargeCounter;
    private float timer;
    private float RolloutChargeTimer;
    private float UpSmashChargeTimer;

    private float PlayerY2;
    public Rigidbody rb;
    private float RolloutForce = 1;
    public InputAction ExecuteAction;



    private float lastFrameInputY = 0;
    private float currentInputY = 0;
    // Start is called before the first frame update
    void Start()
    {
       // ExecuteAction.performed += ctx => ExecuteAttack(UpSmash);
    }
    /*private void OnEnable()
    {
        ExecuteAction.Enable();
    }
    private void OnDisable()
    {
        ExecuteAction.Disable();
    }*/
    // Update is called once per frame
    void Update()
    {

       // currentInputY = Input.GetAxis("Vertical2");
        PlayerY2 = Input.GetAxis("Vertical2");


        if (lastFrameInputY > 0f && currentInputY == 0f) {
            Debug.Log("released stick");
        } 

        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown("joystick button 2"))
        {
            ExecuteAttack(Jab);
        }
        if (Input.GetKey(KeyCode.Q) || Input.GetKey("joystick button 1"))
        {
            RolloutChargeCounter += Time.deltaTime;
            RolloutChargeTimer += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp("joystick button 1"))
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
            rb.AddForce(RolloutForce, 0,0);
        }
        if (PlayerY2 >= 0.8)
        {
            UpsmashChargeCounter += Time.deltaTime;
            UpSmashChargeTimer += Time.deltaTime;
        }
        Debug.Log("playery2" + PlayerY2);
        if (PlayerY2 < 0)
        {
            Debug.Log("hallo");
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
        if (Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown("joystick button 2"))
        {
            ExecuteAttack(Jab2);
        }
        if (attack != null)
        {
            timer += Time.deltaTime;
            if (timer > attack.SpawnDelay && timer < attack.DespawnDelay)
            {
                Debug.Log("hoi");
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


        lastFrameInputY = currentInputY;
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