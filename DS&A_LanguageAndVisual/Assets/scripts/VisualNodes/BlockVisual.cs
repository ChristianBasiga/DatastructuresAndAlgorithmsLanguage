using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockVisual : VisualNode {

    VisualNode head;
    VisualNode current;
    VisualNode tail;

    //Don't need attribute for tailGraphic, just part of prefab


	// Use this for initialization
	void Start () {

        head = current;
        tail = null;
	}
	
	public void append(VisualNode node)
    {
        VisualNode curr = head;

        while (curr.next != null)
        {
            curr = curr.next;
        }

        curr.next = node;
        node.next = null;
    }

    //This is why I need to make method for Next, so that I can override it, this is definitely high on TODO

    public void nextNode()
    {
        current = current.next;

    }

    public void prevNode()
    {
        current = current.prev;
    }

    public VisualNode CurrentNode
    {
        get
        {
            return current;
        }
    }
}
