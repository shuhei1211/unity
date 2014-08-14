using UnityEngine;
using UnityEditor;
using System.Collections;

public class BaseEditor : EditorWindow
{

		// http://anchan828.hatenablog.jp/entry/2013/02/14/022551
		
		// 通常のWindow
		[MenuItem("CustomWindow/NormalWindow")]
		static void OpenNormalWindow ()
		{
				GetWindow<NormalWindow> ();
		}

		// 必ず手前に表示し続けるWindow
		[MenuItem("CustomWindow/ShowUtility")]
		static void OpenShowUtility ()
		{
				NormalWindow window = CreateInstance<NormalWindow> ();
				window.ShowUtility ();
		}

		[MenuItem("CustomWindow/ShowPopup")]
		static void OpenShowPopUp ()
		{
				NormalWindow window = CreateInstance<NormalWindow> ();
				window.ShowPopup ();
		}

		[MenuItem("MapTip/MapTipEditor %m")]	
		static void MapTipWindow ()
		{
				MapTipEditor window = GetWindow<MapTipEditor> ();
				window.title = "MapTipEditor";
				window.position = new Rect (100f, 100f, 800f, 800f);
		}

		/// <summary>
		/// Closes the window. 
		/// push Escape button close window
		/// </summary>
		protected void CloseWindowPushEscape ()
		{
				if (Event.current.keyCode == KeyCode.Escape && Event.current.type == EventType.KeyDown) {
						this.Close ();
				}
		}

		protected GUILayoutOption[] GuiBaseRect (float width, float height)
		{
				GUILayoutOption[] options = {GUILayout.Width (width), GUILayout.Height (height)};
				return options;
		}

		void Awake ()
		{

		}
		
		void Update ()
		{
	
		}

		void OnGUI ()
		{
		}
	
		void OnDestroy ()
		{
		
		}

		void OnInspectorUpdate ()
		{
	    
		}

		void OnSelectionChange ()
		{
		    
		}

		void OnApplicationFocus (bool focusStatus)
		{

		}
		void OnLostFocus ()
		{
	    
		}

		void OnHierarchyChange ()
		{
	    
		}

		void OnProjectChange ()
		{
	    
		}
}
