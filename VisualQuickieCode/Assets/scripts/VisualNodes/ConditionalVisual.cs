using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ConditionalVisual : BlockVisual {

    GameObject conditionBlock;

    //Okay should I have them drag and drop like that? Or should I just force the operation onto the conditionals.
    //If I do the latter, that basically makes all the code I did for checking if clicked that specific area completely useless.
    //But also easier to do
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
