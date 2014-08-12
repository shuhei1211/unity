using UnityEngine;
using UnityEditor;
using System.Collections;

public class NormalWindow : EditorWindow {
	void Start () {
	}
	void Update () {
	
	}
	void OnGUI () {
		if (Event.current.keyCode == KeyCode.Escape && Event.current.type == EventType.KeyDown) {
			Close ();
		}
	}
}