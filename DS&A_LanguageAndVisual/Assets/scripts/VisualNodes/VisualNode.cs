using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//No instance of just visual node is possible, put in correct namespace later.
public abstract class VisualNode : MonoBehaviour {

    //Maybe make property later, do thiss, I forgot why needed but is important
    protected VisualNode prev, next;

    public static readonly float veritcalSpacing = 200.0f;


    public virtual VisualNode Next
    {
        set
        {
            //Theoritcally this should work.
            if (next != null)
            {
                VisualNode newNext = value;
                newNext.transform.position = next.transform.position;
                //Then recur down, this process should be coroutine, maybe, nah it's okay if this thread get's held up, cause don't want new inputs
                //while processing their last inputs.

                //Temp will be previous
                VisualNode temp = next;

                //Sets the current next to new next attached to this code block
                next = newNext;


                //Actually just really need to move everything down, don't need to swap at all
                while (temp != null)
                {
                    moveDown(temp.gameObject.GetComponent<RectTransform>());

                    //So this is next of old next,
                    temp = temp.Next;
                }
            }
            else
            {
                next = value;
                //Place in same position. (Assuming this works for RectTransform as seemed to before.
                next.transform.position = transform.position;

                //Then move down to be directly below it,
                moveDown(next.GetComponent<RectTransform>());
            }

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
    string id;

    //I suppose IfElse prefab will just be GameObject with two GameObjects parented under it, an If and an Else Visual Node. Think that makes
    //most sense
    public string ID
    {
        get { return id; }
    
    }

    public void moveDown(RectTransform rectTransform)
    {
        rectTransform.offsetMin = new Vector2(rt.offsetMin.x, rt.offsetMin.y - veritcalSpacing);
        rectTransform.offsetMax = new Vector2(rt.offsetMax.x, rt.offsetMax.y + veritcalSpacing);

    }
}

