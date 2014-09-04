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
				List<GameObject> ObjectList = GetAllChild (self);
				ObjectList.ForEach(item => MonoBehaviour.Destroy(item));
				Resources.UnloadUnusedAssets ();
		}
	
		public static void SetActiveAllChild (this GameObject self, bool value)
		{
				GetAllChild(self).ForEach(item => item.gameObject.SetActive(value));
		}
		
		public static List<GameObject> GetAllChild (this GameObject self)
		{
				List<GameObject> ObjectList = new List<GameObject> ();
				for (int i = 0; i < self.transform.childCount; i++) {
						ObjectList.Add (self.transform.GetChild (i).gameObject);
				}
				return ObjectList.Count < 1 ? default(List<GameObject>) : ObjectList;
		}
}