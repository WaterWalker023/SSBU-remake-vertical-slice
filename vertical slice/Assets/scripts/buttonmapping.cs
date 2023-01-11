using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "buttonmapping", menuName = "buttonmapping")]
public class buttonmapping : ScriptableObject
{
    public string controllername;
    public int joynumber;
    public string type;
    public string noord;
    public string oost;
    public string zuid;
    public string west;
}
