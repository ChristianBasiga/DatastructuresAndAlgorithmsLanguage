using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//These are the objects placed in the menu. They'll have a refernce to actual VisualNodeOption using.
//and when create is clicked will instantiate what this is referring to. Fucking Decorator yo. I think.
public class VisualNodeOption : MonoBehaviour {

    //This will be the actual node this option is referencing.
    //The gameobjects themselves will be carbon copies of VisualNode prefabs
    //could just make this string later on cause of pool, so no more extra to do here.
    //Actually not string, cause this needs to exist not just as string because will have default values to be preview
    public VisualNode referencing;
    public int optionNumber;

    void Start()
    {

        //Setting example values for referencing...Might just set this via inspector instead. Taking the prefabs of actual ones, yeah.

        //Setting up the buttons.
        Button previewButton = transform.GetChild(0).GetComponent<Button>();
        Button createButton = transform.GetChild(1).GetComponent<Button>();

        //Menu should now just hold the VisualNodeOptions, and these objects deal with
        //opening previews and creating the nodes.

        //This is more logically sound, and each option has own set of buttons so will only one copy of these methods for each onClick on the buttons yo.
        previewButton.onClick.AddListener((int optionIndex) => {
            if (optionIndex == optionNumber)
                openPreview();
        });
        
        createButton.onClick.AddListener((int optionIndex) => {
            if (optionIndex == optionNumber)
                menu.createVisualNode(optionNumber);
        });

        referencing.gameObject.SetActive(false);
    }

    //Actually pulls from pool / instantiates the visualNode this option is referring to.
    void createVisualNode()
    {
        
    }

    void openPreview()
    {
        referencing.gameObject.SetActive(true);
    }

}
