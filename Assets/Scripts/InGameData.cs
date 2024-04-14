using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameData : MonoBehaviour
{

    public int attackAnimIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        attackAnimIndex = 0;        
    }


    public void AddToAttackCountIndex()
    {
        attackAnimIndex++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
