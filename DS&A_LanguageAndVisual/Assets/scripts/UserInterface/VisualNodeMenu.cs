using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStructureLanguage.Syntax.SyntaxNodes;
using UnityEngine.UI;

namespace DataStructureLanguage.UserInterface
{
    public class VisualNodeMenu : MonoBehaviour
    {

        //Instances of all kinds of visual nodes with default values, this will just be loading in prefabs and setting them inactive to active
        List<GameObject> previews;
        //They'll share ta tag with actual non preview objects
        //it should be just decorator pattern, preview extending from actual ones to add those buttons
        //actually yeah, wtf yo.
        int previewIndex;

        void Start()
        { 
            previews = new List<GameObject>();

            //Adds the previews into array and sets up all of the onclick events for previewing and instnatiating visual nodes
            for (int i = 0; i < transform.childCount; ++i)
            {
               //Those prefabs honestly don't even need to have VisualNode / BlockVisual scripts just similiar prefabs
               //just means I won't instantiate the option, but a different prefab.

                GameObject obj = transform.GetChild(i).gameObject;
                previews.Add(obj);

                Button[] buttons = previews[i].GetComponentsInChildren<Button>();

                if (buttons[0].name == "Preview")
                {
                    //Oh fuck me, I remember this same problem in java script, it keeps state of what i was  so it's at end 3
                    buttons[0].onClick.AddListener( () => { this.openPreview(previews.IndexOf(obj)); });
                    buttons[1].onClick.AddListener( () => { this.instantiateVisualNode(previews.IndexOf(obj)); });
                }
                else
                {
                    buttons[0].onClick.AddListener( () => { this.instantiateVisualNode(previews.IndexOf(obj)); });
                    buttons[1].onClick.AddListener( () => { this.openPreview(previews.IndexOf(obj)); });
                }

                previews[i].transform.GetChild(0).gameObject.SetActive(false);
            }

           

            UserController uc = GameObject.Find("UserController").GetComponent<UserController>();

            //For setting to true will be onClick events on the buttons
            uc.clickedScreen += () => {
                previews[previewIndex].transform.GetChild(0).gameObject.SetActive(false);
            };

        }

        //I need to spend time to make this more visually appealing, functionality is all working
        public void instantiateVisualNode(int optionIndex)
        {
            //Actually creating new insance of node, could just keep with preview values insead of making empty
            GameObject node = Instantiate(previews[optionIndex], Vector3.zero, Quaternion.identity);

            //Not at same position but just randomly on the canvas.
            node.transform.position = previews[optionIndex].transform.position;
            node.transform.GetChild(0).gameObject.SetActive(true);
            node.SetActive(true);

        }

        public void openPreview(int optionIndex)
        {
            Debug.Log("Option index is " + optionIndex);
            previews[optionIndex].transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}