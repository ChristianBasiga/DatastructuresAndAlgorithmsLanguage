using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class BinaryOperationVisual : VisualNode {


    public Text operand1;
    public Text operand2;
    //Use operations dictionary keys to fill out options, do this at start, or since they're static just always have it, prob latter
    public Dropdown operators;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
