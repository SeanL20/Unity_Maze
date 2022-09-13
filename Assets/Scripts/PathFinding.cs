using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System;

public class PathFinding : MonoBehaviour {

	PathRequestManager requestManager;
	Grid grid;

	void Awake () {
		requestManager = GetComponent<PathRequestManager> ();
		grid = GetComponent<Grid> ();
	}

	//start finding paths
	public void StartFindPath(Vector3 startPos, Vector3 targetPos){
		StartCoroutine (FindPath (startPos, targetPos));
	}

	//finding the shortest paths
	IEnumerator FindPath(Vector3 startPos, Vector3 targetPos){
		Stopwatch sw = new Stopwatch ();
		sw.Start();
		Vector3[] waypoints = new Vector3[0];
		bool pathSuccess = false;
		Node startNode = grid.NodefromWorldPoint (startPos);
		Node targetNode = grid.NodefromWorldPoint (targetPos);
		if (startNode.walkable && targetNode.walkable) {
			List<Node> openSet = new List<Node> (grid.MaxSize);
			HashSet<Node> closeSet = new HashSet<Node> ();
			openSet.Add (startNode);
			while (openSet.Count > 0) {
				Node currentNode = openSet[0];
				for (int i = 1; i < openSet.Count; i ++) {
					if (openSet[i].fCost < currentNode.fCost || openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost) {
						currentNode = openSet[i];
					}
				}
				openSet.Remove(currentNode);
				closeSet.Add (currentNode);

				if (currentNode == targetNode) {
					sw.Stop ();
					print ("Path Found: " + sw.ElapsedMilliseconds + " ms");
					pathSuccess = true;
					break;
				}
				foreach (Node neighbour in grid.GetNeighbours(currentNode)) {
					if (!neighbour.walkable || closeSet.Contains (neighbour)) {
						continue;
					}
					int newMovementCostToNeighbour = currentNode.gCost + GetDistance (currentNode, neighbour);
					if (newMovementCostToNeighbour < neighbour.gCost || !openSet.Contains (neighbour)) {
						neighbour.gCost = newMovementCostToNeighbour;
						neighbour.hCost = GetDistance (neighbour, targetNode);
						neighbour.parent = currentNode;
					}
					if (!openSet.Contains (neighbour)) {
						openSet.Add (neighbour);
					}
				}
			}
		}
		yield return null;
		if (pathSuccess) {
			waypoints = RetracePath(startNode,targetNode);
		}
		requestManager.FinishedProcessingPath (waypoints, pathSuccess);
	}
	
	Vector3[] RetracePath(Node startNode, Node endNode){
		List<Node> path = new List<Node> ();
		Node currentNode = endNode;
		path.Add(currentNode);
		while (currentNode != startNode) {
			path.Add(currentNode);
			currentNode = currentNode.parent;
		}
		Vector3[] waypoints = simplifyPath (path);
		Array.Reverse (waypoints);
		return waypoints;
	}

	Vector3[] simplifyPath(List<Node> path){
		List<Vector3> waypoints = new List<Vector3>();
		//Vector2 directionOld = Vector2.zero;
		int i;
		for(i = 1; i < path.Count; i++){
			waypoints.Add(path[i].worldPosition);
		}
		return waypoints.ToArray ();
	}

	int GetDistance (Node nodeA, Node nodeB) {
		int distX = Mathf.Abs (nodeA.gridX - nodeB.gridX);
		int distY = Mathf.Abs (nodeA.gridY - nodeB.gridY);
		
		if (distX > distY) {
			return 14 * distY + 10 * (distX - distY);
		} else {
			return 14 * distX + 10 * (distY - distX);
		}
	}
}
