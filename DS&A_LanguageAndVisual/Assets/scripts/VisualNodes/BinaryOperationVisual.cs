using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class BinaryOperationVisual : VisualNode {


    public Text firstOperand;
    public Text secondOperand;
    //Use operations dictionary keys to fill out options, do this at start, or since they're static just always have it, prob latter
    public Dropdown operators;

    // Use this for initialization
	void Start () {

        operators = transform.GetChild(0).GetComponent<Dropdown>();
        firstOperand = transform.GetChild(1).GetComponent<InputField>().textComponent;
        secondOperand = transform.GetChild(2).GetComponent<InputField>().textComponent;


        operators.options.Clear();

        foreach (string operation in Operators.arithmeticOperations.Keys)
        {
            Dropdown.OptionData data = new Dropdown.OptionData(operation);
            operators.options.Add(data);
        }


        foreach (string operation in Operators.logicalOperations.Keys)
        {
            Dropdown.OptionData data = new Dropdown.OptionData(operation);
            operators.options.Add(data);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
