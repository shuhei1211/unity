using UnityEngine;
using System.Collections;

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
}
