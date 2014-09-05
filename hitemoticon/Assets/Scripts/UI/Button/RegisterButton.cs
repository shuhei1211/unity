using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RegisterButton : BaseButton
{
		void Update ()
		{
				boxcollider2D.enabled = true;
		}

		public void OnClick ()
		{
				base.OnClickPlaySound ();
				DestroyBlockUI ();
				UIInput input = GameObject.Find ("InputField").GetComponent <UIInput> ();
				string score = SaveManager.LoadScore ();
				Dictionary<string, string> dict = new Dictionary<string, string> ();
				dict.Add (Config.API_FIELD_SENDMODE, Config.API_FIELD_SENDMODE_POST);
				dict.Add (Config.API_FIELD_NAME, input.value);
				dict.Add (Config.API_FIELD_SCORE, score);
				WWW www = ApiManager.Instance.POST (Config.API_POST_URL, dict);
				StartCoroutine (WaitForRequest(www));
		}
		
		private IEnumerator WaitForRequest (WWW www)
		{
				yield return www;
				if (!string.IsNullOrEmpty (www.error)) {
						Debug.LogError (string.Format ("WWW error\n{0}", www.error));
						yield break;
				}
				Destroy (transform.parent.gameObject);
				www.Dispose ();
		}
}
