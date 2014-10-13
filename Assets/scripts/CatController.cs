using UnityEngine;
using System.Collections;

namespace CatsBoxes
{
	public class CatController : MonoBehaviour {

		public const float NORMAL_RUN_STEP = 0.02f;

		public Animation animation;

		// Use this for initialization
		void Start () {
			animation.wrapMode = WrapMode.Loop;

			animation.Play ("A_run");
		}
		
		// Update is called once per frame
		void Update () {
			var tr = gameObject.transform.parent.transform.localPosition;
			tr.z += NORMAL_RUN_STEP;
			gameObject.transform.parent.transform.localPosition = tr;
		}
	}
}