using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ConditionalVisual : BlockVisual {

    GameObject conditionBlock;

    public BinaryOperationVisual condition;

    public GameObject ConditionBlock
    {
        get
        {
            return conditionBlock;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
