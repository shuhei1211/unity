using UnityEngine;
using System.Collections;

public class RenderQueue : MonoBehaviour
{
		private int queue = 4000;

		// Use this for initialization
		void Start ()
		{
			renderer.material.renderQueue = queue;
			Transform trans = transform;
			for (int i = 0; i < trans.childCount; i++) {
					trans.GetChild(i).gameObject.renderer.material.renderQueue = queue;
				}
		}
}
