using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class percentage : MonoBehaviour
{
    public Jigglypuff Jigglypuff;
    public movement kirby;
    public bool kirbypercentage;
    public TMP_Text textMeshPro;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (kirbypercentage)
        {
            textMeshPro.text = kirby.percentage + "%";
        }
        else
        {
            textMeshPro.text = Jigglypuff.percentage + "%";
        }
    }
}
