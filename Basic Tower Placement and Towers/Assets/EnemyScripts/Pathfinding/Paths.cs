using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paths : MonoBehaviour {
	public Color rayColor = Color.white;
	public List<Transform> pathObject = new List<Transform> ();
	Transform[] oneArray;
		
	
	void OnDrawGizmos()
	{
		Gizmos.color = rayColor;
		oneArray = GetComponentsInChildren<Transform> ();
		pathObject.Clear ();

		foreach (Transform path_Object in oneArray) 
		{
			if (path_Object != this.transform) 
			{
				pathObject.Add (path_Object);	
			}
		}
		for (int i = 0; i < pathObject.Count; i++) 
		{
			Vector3 position = pathObject [i].position;
			if (i > 0) 
			{
				Vector3 Previous = pathObject [i - 1].position;
				Gizmos.DrawLine (Previous, position);
				Gizmos.DrawWireSphere (position, 0.3f);
					
			}
		}
			
			
			
	}

}
