using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockVisual : VisualNode {


    //Not neccessarily...neccesarry because else has no condition but is technically a block visual
    GameObject openingBlock;
    GameObject closingBlock;

    //This should just be there
    
    VisualNode head;

    
    //Basically forcing state on these, now when would I reset current? I guess leave that up to develeoper
    //but that's for sure a design flaw.
    VisualNode current;
    VisualNode tail;

    public Text label;

    //Don't need attribute for tailGraphic, just part of prefab


    // Use this for initialization
    void Start() {


        //Head is always just this visualNode itself
        head = this;


        for (int i = 1; i < transform.childCount; ++i)
        {
            //not needed but just incase change heirarchy, it doesn't mess everything up.
            if (transform.GetChild(i).gameObject.name == "Start")
            {
                openingBlock = transform.GetChild(i).gameObject;
            }
            else if (transform.GetChild(i).gameObject.name == "End")
            {
                closingBlock = transform.GetChild(i).gameObject;

            }
        }
        

        head = current;
        tail = null;
    }

    public GameObject OpeningBlock
    {
        get
        {
            return openingBlock;
        }
    }

    public GameObject ClosingBlock
    {
        get
        {
            return closingBlock;
        }
    }
   
    public override VisualNode Next{

        set
        {
            //Have append method for adding onto inner list, then this would be actual next
            //But kinda seems fucked up, getting Next will not be same Next you are expecting
            //me overriding this makes it more streamlined, but at the cost of ambiguity, should I change it to next child instead?
            //Again this is semantics and causes only slight changes in code, but think latter is definitely better.
            VisualNode newNext = value;

            if (this.next != null)
            {
                newNext.Next = next;
                next = newNext;
            }
        }
        get
        {
            //Should Documentation just mention this? Actually kinda does feel stupid but it's okay.
            if (current.Next == null)
            {
                //Actully would I end up calling my own Next end up causing recursion, instead of calling base one, we'll see if this works
                //this definietly something to test in isolation
                return base.Next;
            }
            current = current.Next;
            return current;
        }
     }
	
    public VisualNode Head
    {
        get
        {
            return head;
        }
    }

    //So need to detect if touching head of block visual when do this is key point, update that in the UserController
    public void setHead(VisualNode visualNode)
    {
        //Can't put something that's not a value inside here
        if (visualNode is BlockVisual)
        {
            return;
        }

        if (head != null)
            visualNode.Next = head.Next;

        head = visualNode;

    }

	public void append(VisualNode node)
    {
        //Always start off at head's next
        VisualNode curr = head;//.Next;

        while (curr.Next != null)
        {
            curr = curr.Next;
        }

        curr.Next = node;
        node.Next = null;

        //Updating the collider boxes.

        RectTransform rt = closingBlock.GetComponent<RectTransform>();

        this.moveDown(rt);

        //Increasing collider of this block visual, for newly added block
        BoxCollider boxCollider = GetComponent<BoxCollider>();

        boxCollider.size = new Vector3(boxCollider.size.x, boxCollider.size.y + veritcalSpacing, 0);
        boxCollider.center = new Vector3(boxCollider.center.x, boxCollider.center.y - (veritcalSpacing / 2), 0);
       
    }

    //This is why I need to make method for Next, so that I can override it, this is definitely high on TODO

    //Have these already set, just change to nextChild to make explicit
    public VisualNode nextChild()
    {
        current = current.Next;
        return current;
    }

    public VisualNode prevChild()
    {
        current = current.Prev;
        return current;
    }

    public VisualNode CurrentNode
    {
        get
        {
            return current;
        }
    }

    public override void delete()
    {
        VisualNode current = head;
        VisualNode prev = null;


        //Deletes everything nested under it.
        while (current != null)
        {
            //Okay this is where next is wanted to overriden, cause nested loops also recursively deleted.
            prev = current;
            current = current.Next;
            Destroy(prev);
            prev = null;
        }

        //To delete itself
        base.delete();

    }
}
