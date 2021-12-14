using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour
{
/*	Mesh mesh;
	MeshRenderer meshRenderer;
	Vector3[] vertices;
	int[] triangles;
	
	public Material material;

	// Use this for initialization
	void Start () {
	
		gameObject.AddComponent<MeshFilter>();
		meshRenderer = gameObject.AddComponent<MeshRenderer>();
		
		meshRenderer.material = material;
		
		mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;
		
		vertices = new[] {
			new Vector3(0,0,0),
			new Vector3(0.5f,0.866025404f,0), 
			new Vector3(1,0,0),

		};
		
		mesh.vertices = vertices;
		
		triangles = new[]{0, 1, 2};
		
		mesh.triangles = triangles;
		
		
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
*/

    void Start() // OnDrawGizmos to see it in the editor, Start to see it  only during the game
    {


        Mesh mesh = GetComponent<MeshFilter>().mesh;

        mesh.Clear();

        // make changes to the Mesh by creating arrays which contain the new values
        mesh.vertices = new Vector3[] {new Vector3(-1, 2, 0), new Vector3(1, 2, 0), new Vector3(0, 0, 0)};
        mesh.uv = new Vector2[] {new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1)};
        mesh.triangles =  new int[] {0, 1, 2};
    }
}