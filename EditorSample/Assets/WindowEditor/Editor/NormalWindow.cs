using UnityEngine;
using UnityEditor;
using System.Collections;

public class NormalWindow : EditorWindow
{
		
		
		void Start ()
		{
		}

		void Update ()
		{
		}

		public Object obj;

		void OnGUI ()
		{

				if (Event.current.keyCode == KeyCode.Escape && Event.current.type == EventType.KeyDown) {
						Close ();
				}

				if (GUILayout.Button ("test", GUILayout.Width (50))) {
						obj = EditorGUILayout.ObjectField (obj, typeof(Object), true, GUILayout.Width (100));
				}

				EditorGUILayout.BeginHorizontal ();
				obj = EditorGUILayout.ObjectField (obj, typeof(Object), true);
				EditorGUILayout.EndHorizontal ();

		}
}