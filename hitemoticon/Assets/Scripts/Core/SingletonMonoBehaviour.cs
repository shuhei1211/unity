﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Singleton mono behaviour. MonoBehaviourを継承したシングルトン
/// </summary>
public class SingletonMonoBehaviour<T> : BaseMonoBehaviour where T : MonoBehaviour
{
		private static T instance;
		public static T Instance {
				get {
						if (instance == null) {
								instance = (T)FindObjectOfType (typeof(T));
								if (instance == null) {
										Debug.LogError (typeof(T) + "is nothing");
								}
						}
						return instance;
				}
		}

		protected void Awake ()
		{
				CheckInstance ();
		}
		
		protected bool CheckInstance ()
		{
				if (this == Instance) {
						return true;
				}
				Destroy (this);
				return false;
		}
}
