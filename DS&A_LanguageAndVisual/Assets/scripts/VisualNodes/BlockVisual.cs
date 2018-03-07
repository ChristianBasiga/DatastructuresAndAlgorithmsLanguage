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
	
	// Update is called once per frame
	void Update () {
		
	}

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
