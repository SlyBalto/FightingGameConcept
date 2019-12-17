using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{

    public int AttackID = 1;

    // Start is called before the first frame update
    void Start()
    {
        Object.Destroy(this.gameObject, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
