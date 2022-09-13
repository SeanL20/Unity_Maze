using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour {

	public bool onlyDisplayGridGizmos;
	public LayerMask unwalkableMask;
	public Vector2 gridWorldSize;
	public float nodeRadius;
	Node[,] grid;
	bool walkable;

	float nodeDiameter;
	int gridSizey, gridSizex;

	void Awake(){
		nodeDiameter = nodeRadius * 2;
		gridSizex = Mathf.RoundToInt (gridWorldSize.x / nodeDiameter);
		gridSizey = Mathf.RoundToInt (gridWorldSize.y / nodeDiameter);
		CreateGrid ();
	}

	public int MaxSize{
		get{
			return gridSizex * gridSizey;
		}
	}

	//creating the gride for where the ai is able to walk
	void CreateGrid (){
		grid = new Node[gridSizex, gridSizey];
		Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x/2 - Vector3.up * gridWorldSize.y/2;

		for (int x = 0; x < gridSizex; x++) {
			for (int y = 0; y < gridSizey; y++) {
				Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.up * (y * nodeDiameter + nodeRadius) ;
				Collider2D[] colliders = Physics2D.OverlapPointAll(worldPoint, unwalkableMask);
				if(colliders.Length > 0){
					walkable = false;
				} else {
					walkable = true;
				}
				grid[x,y] = new Node(walkable, worldPoint, x, y);
			}
		}
	}

	public List<Node> GetNeighbours(Node node){
		List<Node> neighbour = new List<Node> ();
		for (int x = -1; x <= 1; x++) {
			for (int y = -1; y <= 1; y++) {
				if (x == 0 && y == 0|| x == -1 && y == -1 || x == 1 && y == 1 || x == -1 && y == 1 || x == 1 && y == -1){
					continue;
				}
				int checkX = node.gridX + x;
				int checkY = node.gridY + y;

				if (checkX >= 0 && checkX < gridSizex && checkY >= 0 && checkY < gridSizey ){
					neighbour.Add(grid[checkX, checkY]);
				}
			}
		}
		return neighbour;
	}

	//finding out the position of node the ai is on
	public Node NodefromWorldPoint(Vector3 worldPosition){
		float percentX = (worldPosition.x + gridWorldSize.x/2) / gridSizex;
		float percentY = (worldPosition.y + gridWorldSize.y/2) / gridSizey;
		percentX = Mathf.Clamp01(percentX);
		percentY = Mathf.Clamp01(percentY);

		int x = Mathf.RoundToInt((gridSizex - 1) * percentX);
		int y = Mathf.RoundToInt((gridSizey - 1) * percentY);
		return grid [x, y];
	}

	public List<Node> path;
	//draw up grid
	void OnDrawGizmos() {
		Gizmos.DrawWireCube (transform.position, new Vector3 (gridWorldSize.x, gridWorldSize.y));
		if (grid != null && onlyDisplayGridGizmos) {
			foreach (Node n in grid) {
				Gizmos.color = (n.walkable) ? Color.white : Color.red;
				Gizmos.DrawCube (n.worldPosition, Vector3.one * (nodeDiameter - 0.1f));
			}
		}
	}
}
