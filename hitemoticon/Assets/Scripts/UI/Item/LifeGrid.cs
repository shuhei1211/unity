using UnityEngine;
using System.Collections;

public class LifeGrid : BaseMonoBehaviour
{
		private UIGrid grid;
	
		void Awake ()
		{	
				grid = GetComponent<UIGrid> ();
				for (int i = 0; i < Config.PLAYER_HP; i++) {
						CloneManager.CloneLife (gameObject);
				}
				grid.Reposition ();
		}

		private void DecreaseLifeCount ()
		{
				Destroy (grid.GetChild (0).gameObject);
		}

		private void IncreaseLifeCount ()
		{
				CloneManager.CloneLife (gameObject);
				grid.Reposition ();
		}
}
