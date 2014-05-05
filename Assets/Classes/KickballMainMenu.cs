using UnityEngine;
using System.Collections;

public class KickballMainMenu : MonoBehaviour {


	void Awake() {
		
		Skillz.skillzInitForGameIdAndEnvironment("611", Skillz.SkillzEnvironment.SkillzProduction);
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		if (GUI.Button(new Rect(Screen.width / 2 - 50, 25, 100, 50), "SKILLZ")){ 
			Skillz.launchSkillz(Skillz.SkillzOrientation.SkillzPortrait);
		}
	}
}
