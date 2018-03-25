using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//No instance of just visual node is possible, put in correct namespace later.
//removed abstract for root
public class VisualNode : MonoBehaviour {

    //Maybe make property later, do thiss, I forgot why needed but is important
    protected VisualNode prev, next;
    public GameObject activeBG;

    //The equations thought up work, but need this value to auto scale, instead of magic numbers, so this is magic spacing want,
    //but as increase size, should update this, magic numbersss
    public static readonly float veritcalSpacing = 45;
    //Just get rid of indenting, actual logic and connections are solid
    public static readonly float horizontalSpacing = (veritcalSpacing * 2) - 1.3f;

    private void Start()
    {
        
    }

    public virtual VisualNode Next
    {
        set
        {
            if (value == this ) return;

            if (value == null)
            {
                next = null;
                return;
            }
            //if already has a next then replace that next and set old next to this new next
             if (next != null)
            {
                if (next == value) return;

                VisualNode newNext = value;

                newNext.gameObject.transform.position = transform.position;
                moveDown(newNext.gameObject);

                if (newNext.prev != null)
                {
                    newNext.prev.Next = null;
                }

                //For swapping node places, if just two of them ie: 1->2 2->1 it will be infinite loop when enters the while loop
                if (newNext.Next == this)
                {
                    newNext.prev = this;
                    newNext.Next = null;
                    next = newNext;
                    return;
                }               

                //Then need to move all of the next of this new next as well this this itself.

                VisualNode current = newNext;
                VisualNode previousNode = current;

                //Okay this works for getting rest of nexts
                while (current.Next != null)
                {
                    
                   current = current.Next;
                   current.gameObject.transform.position = previousNode.gameObject.transform.position;
                   previousNode = current;
                   moveDown(current.gameObject);
                }

                if (current.Next == this)
                {
                    current.Next = null;
                }

                //If had no next then my prev is next to new next, if did then it's next to the last node attached to new next.
                current.Next = next;
                next = newNext;


            }
            else
            {
                VisualNode newNext = value;

                if (newNext.prev != null)
                {
                    newNext.prev.next = null;
                }
                if (newNext.Next == this)
                {
                    newNext.prev = this;
                    newNext.Next = null;
                    next = newNext;
                }
                next = newNext;



                next.gameObject.transform.position = transform.position;
                moveDown(next.gameObject);

                VisualNode current = newNext;
                VisualNode previousNode = current;

                //This is to make sure gets all the next of new next.
                while (current.Next != null)
                {

                    current = current.Next;
                    current.gameObject.transform.position = previousNode.gameObject.transform.position;
                    previousNode = current;
                    moveDown(current.gameObject);
                }

              
               
            }

            Debug.Log("next of " + gameObject.name + "is " + next.gameObject.name);
            next.prev = this;

        }
        get
        {
            return next;
        }
    }

    public virtual VisualNode Prev
    {
        set
        {
            prev = value;
        }
        get
        {
            return prev;
        }
    }

    //Representing kind of Visual Node
    protected string id;
    
    public string ID
    {
        get { return id; }
    
    }

    public void moveDown(GameObject toMove)
    {
        // rt.offsetMin = new Vector2(rt.offsetMin.x, rt.offsetMin.y - veritcalSpacing);
        // rt.offsetMax = new Vector2(rt.offsetMax.x, rt.offsetMax.y + veritcalSpacing);

        toMove.transform.Translate(new Vector3(0, -veritcalSpacing, 0));

    }

    public void moveLeft(GameObject toMove)
    {
        toMove.transform.Translate(new Vector3(-horizontalSpacing, 0, 0));
    }

    public void highlight()
    {
        activeBG.SetActive(true);
    }

    public void unhighlight()
    {
        activeBG.SetActive(false);
    }

    //Incase they change their mind and want to delete, then visual nodes get rid of them selves.
    public virtual void delete()
    {

        //Maybe make pool later, but not sure how big to make them, and that's efficieny later, also would be better since
        //recursiveley deleting all inner blocks of visual block will be costly.
        Destroy(this);
    }
}

