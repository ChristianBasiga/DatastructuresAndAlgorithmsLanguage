using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//No instance of just visual node is possible, put in correct namespace later.
public abstract class VisualNode : MonoBehaviour {

    //Maybe make property later, do thiss, I forgot why needed but is important
    protected VisualNode prev, next;
    public GameObject activeBG;

    //The equations thought up work, but need this value to auto scale, instead of magic numbers, so this is magic spacing want,
    //but as increase size, should update this.
    public static readonly float veritcalSpacing = 100.0f;


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
    
    public string ID
    {
        get { return id; }
    
    }

    public void moveDown(RectTransform rt)
    {
        rt.offsetMin = new Vector2(rt.offsetMin.x, rt.offsetMin.y - veritcalSpacing);
        rt.offsetMax = new Vector2(rt.offsetMax.x, rt.offsetMax.y + veritcalSpacing);

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

