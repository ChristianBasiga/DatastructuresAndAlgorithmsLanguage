using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStructureLanguage.Syntax.SyntaxNodes;

namespace DataStructureLanguage.UserInterface
{
    public delegate void UserAction();
    public delegate void VisualNodeInteraction(VisualNode visualNode);
    public class UserController : MonoBehaviour
    {

        public event UserAction clickedScreen;
        public event UserAction clickedCompile;
        public event UserAction clickedStart;

        public event VisualNodeInteraction holdNode;
        public event VisualNodeInteraction placeNode;

        VisualNode currentlyClicked = null;



        // Use this for initialization
        void Start()
        {
            //Should work theoritically, see nothing wrong with logic, though do need to change it so set through property instead so I can trigger events of placement, like spacing with 
            placeNode += (VisualNode toPlaceWith) => { toPlaceWith.Next = currentlyClicked; };
        }

        // Update is called once per frame
        void Update()
        {

            for (int i = 0; i < Input.touchCount; ++i) {

                Touch touch = Input.GetTouch(i);

                if (touch.phase == TouchPhase.Ended) {

                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RayCastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit != null)
                        {
                            //So if hit visual Node then trigger the event OnClick
                            if (hit.collider.gameObject.GetComponent<VisualNode>())
                            {
                                OnClick(hit.collider.gameObject);
                            }
                            else if (hit.collider.gameObject.name == "Compile")
                            {

                            }
                        
                        }

                    }
                }
            }
        }

        //Everytime press use raycast 
        public void OnClickedNode(GameObject clicked)
        {
            if (currentlyClicked == null)
            {
                currentlyClicked = clicked.GetComponent<VisualNode>();

                //Triggers all the subscribe events
                if (holdNode != null)
                    holdNode(currentlyClicked);
            }
            else
            {

                //So if not placed then place node with respect to newly clicked node
                if (placeNode != null)
                {
                    VisualNode newlyClicked = clicked.GetComponent<VisualNode>();

                    if (newlyClicked != currentlyClicked)
                    {
                        placeNode(newlyClicked);
                    }
                }

                currentlyClicked = null;
            } 
        }

    }
}