using UnityEngine;
using UnityEditor;
using System.Collections;

public class Test1
{

		/// <summary>
		/// Transoformコンポーネントをつけた空のGameObjectを追加する
		///　& = Alt, # = shift,
		/// </summary>
		[MenuItem("Test/Create TEST", true)]
		static bool Validate ()
		{
				return Selection.activeTransform;
		}

		[MenuItem("Test/Create TEST2", false)]
		static void Create ()
		{
				GameObject child = new GameObject ("child");
				child.transform.parent = Selection.activeTransform;
		}

		[MenuItem("Test/Create TEST3", false)]
		static void Create1 ()
		{
				GameObject child = new GameObject ("child");
				child.transform.parent = Selection.activeTransform;
		}


		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
