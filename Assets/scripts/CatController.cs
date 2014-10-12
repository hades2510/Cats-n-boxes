using UnityEngine;
using System.Collections;

namespace CatsBoxes
{
	public class CatController : MonoBehaviour {

		public Animation animation;

		// Use this for initialization
		void Start () {
			animation.wrapMode = WrapMode.Loop;

			animation.Play ("A_run");
		}
		
		// Update is called once per frame
		void Update () {
			var tr = gameObject.transform.parent.transform.localPosition;
			tr.z += 0.01f;
			gameObject.transform.parent.transform.localPosition = tr;
		}
	}
}