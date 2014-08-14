using UnityEngine;
using UnityEditor;
using System.Collections;

public class MapTipEditor : BaseEditor
{
		public UIAtlas rootAtlas;
		private bool isMapTip;

		void Awake ()
		{
				isMapTip = true;
		}
	
		void Update ()
		{
		}

		void OnGUI ()
		{
				CloseWindowPushEscape ();
				
				if (isRootAtlas ()) {
						if (isMapTip) {
								EditorGUILayout.BeginHorizontal ();
								for (int i = 0; i < 10; i++) {
										NGUIEditorTools.DrawPrefixButton ("" + i, GuiBaseRect (10f, 10f));
										EditorGUILayout.BeginVertical ();
										for (int j = 0; j < 10; j++) {
												GUILayout.Label ("" + j, GuiBaseRect (10f, 10f));
										}
										EditorGUILayout.EndVertical ();
								}
								EditorGUILayout.EndHorizontal ();
						}
//						isMapTip = false;
				}
		}

		/// <summary>
		/// Creates the atlas field.
		/// </summary>
		private bool isRootAtlas ()
		{
				EditorGUILayout.BeginHorizontal ();
				rootAtlas = EditorGUILayout.ObjectField (rootAtlas, typeof(UIAtlas), true) as UIAtlas;
				EditorGUILayout.EndHorizontal ();
				return rootAtlas ? true : false;
		}
}
