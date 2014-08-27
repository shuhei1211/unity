using UnityEngine;
using System.Collections;

public static class SpriteRendererExtension
{
		private static SpriteRenderer spriteRenderer;

		public static float SelfWidth (this GameObject go)
		{
				spriteRenderer = go.GetComponent<SpriteRenderer> ();
				return spriteRenderer.bounds.size.x;
		}

		public static float SelfHeight (this GameObject go)
		{
				spriteRenderer = go.GetComponent<SpriteRenderer> ();
				return spriteRenderer.bounds.size.y;
		}


}
