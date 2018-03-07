using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStructureLanguage.Syntax.SyntaxNodes;

namespace DataStructureLanguage.UserInterface
{
    public class VisualNodeMenu : MonoBehaviour
    {

        public int optionCount;
        //Instances of all kinds of visual nodes with default values, this will just be loading in prefabs and setting them inactive to active
        GameObject[] previews = new VisualNode[optionCount]
        {
            Instantiate(Resources.Load("Prefabs/VisualNodes/While") as GameObject,0,0),
            Instantiate(Resources.Load("Prefabs/VisualNodes/For") as GameObject,0,0),
            Instantiate(Resources.Load("Prefabs/VisualNodes/If") as GameObject,0,0),
            Instantiate(Resources.Load("Prefabs/VisualNodes/IfElse") as GameObject,0,0),
            Instantiate(Resources.Load("Prefabs/VisualNodes/BinaryOperation") as GameObject,0,0)

        };

        int previewIndex;

        void Start()
        {
            foreach (VisualNode node in previews)
            {
                node.gameObject.SetActive(false);
            }

            UserController uc = GameObject.Find("UserController").GetComponent<UserController>();

            //For setting to true will be onClick events on the buttons
            uc.clickedScreen += () => { previews[previewIndex].SetActive(false); };

        }

        public void instantiateVisualNode(int optionIndex)
        {
            //Actually creating new insance of node, could just keep with preview values insead of making empty
            GameObject node = Instantiate(previews[optionIndex], 0, 0);

            node.SetActive(true);

        }

        public void openPreview(int optionIndex)
        {
            previews[previewIndex].SetActive(true);
        }
    }
}