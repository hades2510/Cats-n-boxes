using UnityEngine;
using System.Collections;

namespace CatsBoxes {

	public class DebugUI : MonoBehaviour {

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		public void OnGUI()
		{
			float width = Screen.width;
			float height = Screen.height;

			
			if(GUI.Button (new Rect(width-100,150,100,40) , "SwipeUp") )
			{
				AppEvents.OnSwipe(SwipeRecognizer.SwipeDirection.Up);
			}
			
			if(GUI.Button (new Rect(width-100,190,100,40) , "SwipeDown") )
			{
				AppEvents.OnSwipe(SwipeRecognizer.SwipeDirection.Down);
			}
		}
	}
}
