using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewAttack", menuName = "Magifence/Attack")]
public class Attack : ScriptableObject
{
    public string AttackName;
    public float Scaling;
    public float BaseKncokBack;
    public float AngleAttack;
    public float SpawnDelay;
    public float DespawnDelay;
    public GameObject Hitbox;
    public float Damage;
}
