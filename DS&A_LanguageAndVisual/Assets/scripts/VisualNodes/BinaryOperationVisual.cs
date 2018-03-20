using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Might need to extend this for Logical, but it's just changing what's inside operators, so really just different instances
//not different objects
public class BinaryOperationVisual : VisualNode {


    public InputField firstOperand;
    public InputField secondOperand;
    //Use operations dictionary keys to fill out options, do this at start, or since they're static just always have it, prob latter
    public Dropdown operators;

    // Use this for initialization
	void Start () {

        /*  operators = transform.GetChild(2).GetComponent<Dropdown>();
          firstOperand = transform.GetChild(3).GetComponent<InputField>().textComponent;
          secondOperand = transform.GetChild(4).GetComponent<InputField>().textComponent;
          */

     //   operators.options = new List<Dropdown.OptionData>();
        /*

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
        */
    }

    // Update is called once per frame
    void Update () {
		
	}
}
