using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStructureLanguage.Syntax.SyntaxNodes;
using UnityEngine.UI;

namespace DataStructureLanguage.UserInterface
{
    public class VisualNodeMenu : MonoBehaviour
    {

        List<VisualNodeOption> previews;
    
        int previewIndex;

        void Start()
        { 
            previews = new List<VisualNodeOption>();

            //Adds the previews into array and sets up all of the onclick events for previewing and instnatiating visual nodes
            for (int i = 0; i < transform.childCount; ++i)
            {
               //Those prefabs honestly don't even need to have VisualNode / BlockVisual scripts just similiar prefabs
               //just means I won't instantiate the option, but a different prefab.

                
                VisualNodeOption obj = transform.GetChild(i).gameObject.GetComponent<VisualNodeOption>();
                previews.Add(obj);
                obj.optionNumber = i;

             
                previews[i].transform.GetChild(0).gameObject.SetActive(false);
            }

           

            UserController uc = GameObject.Find("UserController").GetComponent<UserController>();

            //For setting to true will be onClick events on the buttons
            uc.clickedScreen += () => {
                previews[previewIndex].transform.GetChild(0).gameObject.SetActive(false);
            };

        }
        /*
        //I need to spend time to make this more visually appealing, functionality is all working
        public void createVisualNode(int optionIndex)
        {
            //Instantiating the referencing node instead, once I create pool for this, will be taking from pool instead
            //but that's polish
            GameObject node = Instantiate(previews[optionIndex].referencing, Vector3.zero, Quaternion.identity).gameObject;

            //Not at same position but just at "origin" of canvas probably.
            node.transform.position = previews[optionIndex].transform.position;
            node.transform.GetChild(0).gameObject.SetActive(true);
            node.SetActive(true);

        }

        public void openPreview(int optionIndex)
        {
            //This fine just need extra dereference to gameObject
            Debug.Log("Option index is " + optionIndex);
            previews[optionIndex].gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }

    */
    }
}