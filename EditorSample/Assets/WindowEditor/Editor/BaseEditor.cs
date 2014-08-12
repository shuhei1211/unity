using UnityEngine;
using UnityEditor;
using System.Collections;

public class BaseEditor : EditorWindow {

	// http://anchan828.hatenablog.jp/entry/2013/02/14/022551
		
	void Awake () {
	}
	// 通常のWindow
	[MenuItem("CustomWindow/NormalWindow")]
	static void OpenNormalWindow () {
		GetWindow<NormalWindow> ();
	}

	// 必ず手前に表示し続けるWindow
	[MenuItem("CustomWindow/ShowUtility")]
	static void OpenShowUtility () {
		NormalWindow window = CreateInstance<NormalWindow> ();
		window.ShowUtility ();
	}

	[MenuItem("CustomWindow/ShowPopup")]
	static void OpenShowPopUp () {
		NormalWindow window = CreateInstance<NormalWindow> ();
		window.ShowPopup ();
	}

	void Start () {

	}
	
	void Update () {
	
	}
}
