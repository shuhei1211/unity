using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class GameObjectExtension
{
		public static void SettingClone (this GameObject clone, GameObject parent, string name)
		{
				clone.transform.SetParent (parent);
				clone.name = name;
				clone.transform.SetLocalScale (1, 1, 1);
		}
	
		public static void SettingClone (this GameObject clone, GameObject parent)
		{
				clone.transform.SetParent (parent);
				clone.transform.SetLocalScale (1, 1, 1);
		}
		
		public static void AllClearChild (this GameObject self)
		{
				List<GameObject> ObjectList = GetChildren (self);
				ObjectList.ForEach (item => MonoBehaviour.Destroy (item));
				Resources.UnloadUnusedAssets ();
		}
	
		public static void SetActiveAllChild (this GameObject self, bool value)
		{
				GetChildren (self).ForEach (item => item.gameObject.SetActive (value));
		}
		
		public static List<GameObject> GetChildren (this GameObject self)
		{
				List<GameObject> ObjectList = new List<GameObject> ();
				for (int i = 0; i < self.transform.childCount; i++) {
						ObjectList.Add (self.transform.GetChild (i).gameObject);
				}
				return ObjectList.Count < 1 ? default(List<GameObject>) : ObjectList;
		}
	
		public static GameObject[] GetAllChildren (this GameObject self, bool isIncludeInActive = false)
		{
				return self.GetComponentsInChildren<Transform> (isIncludeInActive)
					.Where (item => item != self.transform)
					.Select (item => item.gameObject)
					.ToArray ();
		}
		
		// Debug用
		public static void GetChildrenName (this List<GameObject> list)
		{
				list.ForEach (item => Debug.Log ("child name : " + item.name));
		}
}