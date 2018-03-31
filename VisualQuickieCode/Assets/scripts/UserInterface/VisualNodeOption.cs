using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

//These are the objects placed in the menu. They'll have a refernce to actual VisualNodeOption using.
//and when create is clicked will instantiate what this is referring to. Fucking Decorator yo. I think.
public class VisualNodeOption : MonoBehaviour {


    public VisualNode referencing;
    public int optionNumber;
    //Panel containing preview and create buttons
    public GameObject actionPanel;
    

    public Button menuButton;


    void Start()
    {

        //Setting up the buttons.
        Button previewButton = actionPanel.transform.GetChild(1).GetComponent<Button>();
        Button createButton = actionPanel.transform.GetChild(0).GetComponent<Button>();
        Button closeButton = actionPanel.transform.GetChild(2).GetComponent<Button>();

        previewButton.onClick.AddListener(openPreview);

        createButton.onClick.AddListener(createVisualNode);

        closeButton.onClick.AddListener(() => { actionPanel.SetActive(false);
            closePreview();
        });


        actionPanel.SetActive(false);

        menuButton.onClick.AddListener(() => { actionPanel.SetActive(true); });

        referencing.gameObject.SetActive(false);
    }

   


    void createVisualNode()
    {
        GameObject spawnPoint = GameObject.Find("spawnpoint");
        GameObject node = Instantiate(referencing, Vector3.zero, Quaternion.identity).gameObject;

        GameObject codecanvas = GameObject.Find("CodeCanvas");
        node.transform.parent = codecanvas.transform;
        node.transform.localPosition = spawnPoint.transform.localPosition;
        //It needs head, and tail stuff, ut don't think actually needs head to contain all that shiz.
        //node.transform.GetChild(0).gameObject.SetActive(true);
        node.SetActive(true);
        actionPanel.SetActive(false);
    }

    void openPreview()
    {
        referencing.gameObject.SetActive(true);
    }

    void closePreview()
    {
        referencing.gameObject.SetActive(false);

    }

}
