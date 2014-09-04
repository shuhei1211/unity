using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;

public class DataManager : SingletonMonoBehaviour<DataManager>
{
		private Dictionary<string, object> controllerDic = new Dictionary<string, object> ();
		private Dictionary<string, object> modelDic = new Dictionary<string, object> ();
	
		public T GetController<T> ()
		{
				Type type = Type.GetType (typeof(T).ToString ());
				object cls = "";
				if (controllerDic.ContainsKey (typeof(T).ToString ())) {
						cls = controllerDic [typeof(T).ToString ()];
				} else {
						cls = Activator.CreateInstance<T> ();
						controllerDic.Add (typeof(T).ToString (), cls);
				}
				return (T)cls;
		}
		
		public T GetModel<T> ()
		{
				Type type = Type.GetType (typeof(T).ToString ());
				object cls = "";
				if (modelDic.ContainsKey (typeof(T).ToString ())) {
						cls = modelDic [typeof(T).ToString ()];
				} else {
						cls = Activator.CreateInstance<T> ();
						modelDic.Add (typeof(T).ToString (), cls);
				}
				return (T)cls;
		}
}
