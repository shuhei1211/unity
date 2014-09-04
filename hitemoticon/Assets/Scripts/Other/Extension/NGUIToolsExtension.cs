using UnityEngine;
using System.Collections;

public static class NGUIToolsExtension
{

		static public GameObject AddChild (GameObject parent, GameObject prefab)
		{
				GameObject go = GameObject.Instantiate (prefab) as GameObject;
				#if UNITY_EDITOR
				UnityEditor.Undo.RegisterCreatedObjectUndo (go, "Create Object");
				#endif
				if (go != null && parent != null) {
						Transform t = go.transform;
						t.parent = parent.transform;
						t.localPosition = Vector3.zero;
						t.localRotation = Quaternion.identity;
						t.localScale = Vector3.one;
						go.layer = parent.layer;
				}
				return go;
		}

		static public GameObject AddChild (GameObject parent, GameObject prefab, string parentName)
		{
				GameObject go = GameObject.Instantiate (prefab) as GameObject;
				go.name = parentName;
				#if UNITY_EDITOR
				UnityEditor.Undo.RegisterCreatedObjectUndo (go, "Create Object");
				#endif
				if (go != null && parent != null) {
						Transform t = go.transform;
						t.parent = parent.transform;
						t.localPosition = parent.transform.localPosition;
//						t.position.x = parent.transform.position.x;
						t.localRotation = Quaternion.identity;
						t.localScale = Vector3.one;
						go.layer = parent.layer;
				}
				return go;
		}
}
