using UnityEngine;
using System.Collections;

public class MenuInterface : MonoBehaviour {

	public GUISkin Skin;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		var width = Screen.width;
		var height = Screen.height;

		GUI.skin = Skin;

		GUI.Label (new Rect (width / 2 - 50, height / 2 - 105, 100, 30), "Cats'n'Boxz" );

		if (GUI.Button (new Rect (width / 2 - 50, height / 2 - 60, 100, 30), "Play")) 
		{
			Application.LoadLevel( "level_1" );
		}

		GUI.Button( new Rect (width/2-50, height/2 -15, 100, 30), "Credits");
	}
}
