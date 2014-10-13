using UnityEngine;
using System.Collections;

namespace CatsBoxes
{
	public class CatController : MonoBehaviour {

		private float speed = 1.0f;

		public Animation animation;

		// Use this for initialization
		void Start () {
			animation.wrapMode = WrapMode.Loop;

			animation.Play ("A_run");
		}
		
		// Update is called once per frame
		void Update () {
			var tr = gameObject.transform.parent.transform.localPosition;

			tr.z += Time.deltaTime*speed;
			gameObject.transform.parent.transform.localPosition = tr;
		}
	}
}