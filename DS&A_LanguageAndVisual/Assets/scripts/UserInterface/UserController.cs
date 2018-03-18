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
        Vector3 lastTouched;


        // Use this for initialization
        void Start()
        {
            
            //Getting pretty big to be just lambda, but eh.
            placeNode += (VisualNode toPlaceWith) => {

                //So if it's a block node I want to attach it to head of that node not append to head of root node.
                if (toPlaceWith is BlockVisual)
                {
                    BlockVisual block = (BlockVisual)toPlaceWith;
                    

                    //May have to change this logic, we'll see though.

                    //If where touched is in opening block of block visual, then it's inside it's body
                    if (block.OpeningBlock.GetComponent<Collider>().bounds.Contains(lastTouched))
                    {
                        Debug.Log("Will go inside block");
                        block.append(currentlyClicked);
                    }
                    //Or if it's in closing block then appends to next of actual.
                    else if (block.ClosingBlock.GetComponent<Collider>().bounds.Contains(lastTouched))
                    {
                        Debug.Log("Will go to next statement after this block");

                        //Then the next property will handle placing the block directly below something
                        block.Next = currentlyClicked;
                    }
                    else if (block is ConditionalVisual)
                    {
                        //So the conditionalVisual always has a condition block with collider set up, but that block will also have a fiel
                        ConditionalVisual cv = (ConditionalVisual)block;
                        
                        //If they touched it there, then set the currentClicked VisualNode to be the binary visual node placed inside this condition
                        if (cv.ConditionBlock.GetComponent<Collider>().bounds.Contains(lastTouched))
                        {
                            //Because putting another block visual there wouldn't make any sense
                            //I could enforce logical too with tags, or just let numbers happen too
                            if (currentlyClicked is BinaryOperationVisual && currentlyClicked.gameObject.CompareTag("logical"))
                            {
                                Debug.Log("Will go inside condition of this block");
                                cv.condition = (BinaryOperationVisual)currentlyClicked;
                            }
                            else
                            {
                                Debug.Log("Invalid block");
                            }
                        }
                    }
                }
                else
                {
                    toPlaceWith.Next = currentlyClicked;
                }

            };
        }

        // Update is called once per frame
        void Update()
        {
            //There's some breach of responsibility, this has touch position

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