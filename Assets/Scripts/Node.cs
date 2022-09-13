using UnityEngine;
using System.Collections;

//nodes for the pathfinding
public class Node{
	
	public bool walkable;
	public Vector3 worldPosition;
	public int gridX;
	public int gridY;

	public int gCost;
	public int hCost;
	public Node parent;

	// Use this for initialization
	public Node(bool walk, Vector3 worpos, int _gridx, int _gridy){
		walkable = walk;
		worldPosition = worpos;
		gridX = _gridx;
		gridY = _gridy;
	}
	
	public int fCost {
		get {
			return gCost + hCost;
		}
	}

	//comparing the cost of finding each nodes
	public int CompareTo(Node nodeToCompare){
		int compare = fCost.CompareTo (nodeToCompare.fCost);
		if (compare == 0) {
			compare = hCost.CompareTo(nodeToCompare.hCost);
		}
		return -compare;
	}
}
