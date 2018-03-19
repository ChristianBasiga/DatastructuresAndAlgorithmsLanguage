using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
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
        Vector3 lastTouched;


        // Use this for initialization
        void Start()
        {

            placeNode += (VisualNode toPlaceOnto) =>
            {

                if (toPlaceOnto is BlockVisual)
                {
                    BlockVisual bv = (BlockVisual)toPlaceOnto;
                    bv.append(currentlyClicked);
                }
                else
                {
                    toPlaceOnto.Next = currentlyClicked;
                }
                currentlyClicked = null;
            };
        }

        // Update is called once per frame
        void Update()
        {
            //There's some breach of responsibility, this has touch position

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                lastTouched = Input.mousePosition;
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null)
                    {

                        if (hit.collider.gameObject.GetComponent<VisualNode>() || hit.collider.gameObject.name == "Begin" || hit.collider.gameObject.name == "End")
                        {
                            OnClickedNode(hit.collider.gameObject);
                        }
                        else if (hit.collider.gameObject.name == "Compile")
                        {
                            clickedCompile();
                        }

                    }

                }
                else
                {
                    currentlyClicked = null;

                }
            }
          
            for (int i = 0; i < Input.touchCount; ++i) {

                Touch touch = Input.GetTouch(i);
                //If done touching, then check if touched visual node

             

                if (touch.phase == TouchPhase.Ended) {

                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    lastTouched = touch.position;
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider != null)
                        {                   
                            if (hit.collider.gameObject.GetComponent<VisualNode>())
                            {
                                Debug.Log("I touched visual");
                                OnClickedNode(hit.collider.gameObject);
                            }
                            else if (hit.collider.gameObject.name == "Compile")
                            {
                                clickedCompile();
                            }
                        
                        }

                    }
                }
            }
        }

        public void Clicked(PointerEventData data)
        {

        }

        public void OnClickedNode(GameObject clicked)
        {

            //I Suppose I could check it here.
            if (clicked.GetComponent<VisualNode>() && currentlyClicked == null)
            {
                currentlyClicked = clicked.GetComponent<VisualNode>();
                //Triggers all the subscribe events
                if (holdNode != null)
                    holdNode(currentlyClicked);
            }
            else if (currentlyClicked != null)
            {

                if (currentlyClicked.gameObject.name == clicked.name)
                {
                    currentlyClicked = null;
                    return;
                }

                //So if not placed then place node with respect to newly clicked node
                if (placeNode != null)
                {
                    VisualNode newlyClicked = clicked.GetComponent<VisualNode>();

                    if (newlyClicked == currentlyClicked)
                    {
                        currentlyClicked = null;
                        return;
                    }


                    //If clicked on a begin, then must append
                    if (clicked.name == "Begin")
                    {
                        newlyClicked = clicked.transform.parent.GetComponent<BlockVisual>();
                        ((BlockVisual)newlyClicked).append(currentlyClicked);
                    }
                    else if (clicked.name == "End")
                    {
                        newlyClicked = clicked.transform.parent.GetComponent<BlockVisual>();
                        newlyClicked.Next = currentlyClicked;
                        return;

                    }

                    if (newlyClicked != currentlyClicked)
                    {
                        placeNode(newlyClicked);

                    }
                }

             
            } 
        }

    }
}