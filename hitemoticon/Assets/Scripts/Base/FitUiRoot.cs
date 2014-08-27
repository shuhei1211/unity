using UnityEngine;
using System.Collections;

public class FitUiRoot : MonoBehaviour
{

		public int manualWidth = 1280;
		public int manualHeight = 720;
		UIRoot uiRoot;
	
		public float ratio {
				get {
						if (!uiRoot) {
								return 1.0f;
						}
						return (float)Screen.height / uiRoot.manualHeight;
				}
		}
	
		void Awake ()
		{
				uiRoot = GetComponent<UIRoot> ();
		}

		void Update ()
		{
				if (!uiRoot || manualWidth <= 0 || manualHeight <= 0) {
						return;
				}
				int h = manualHeight;
				float r = (float)(Screen.height * manualWidth) / (Screen.width * manualHeight);
				if (r > 1.0f) {
						h = (int)(h * r);
				}
				if (uiRoot.manualHeight != h) {
					uiRoot.manualHeight = h;
				}
				if (uiRoot.minimumHeight > 1) {
					uiRoot.minimumHeight = 1;
				}
				if (uiRoot.maximumHeight < System.Int32.MaxValue) {
					uiRoot.maximumHeight = System.Int32.MaxValue;
				}
		}
}
