using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour {

	public GameObject[] popUps;
	private int popUpIndex = 0;
	public GameObject Burger;
	public GameObject Coca;
	public GameObject Bottle;
	public GameObject Health;

	void Awake(){
		if (PlayerPrefs.GetInt ("Tutorial") == 1) {
			SceneManager.LoadScene ("Menu");
		}
	}

	void Start (){
		popUpIndex = 0;
		Burger.SetActive (false);
		Coca.SetActive (false);
		Bottle.SetActive (false);
		Health.SetActive (false);
		PlayerPrefs.SetInt ("TS", 0);
		PlayerPrefs.SetInt ("BurgerTutorial", 0);
		PlayerPrefs.SetInt ("CocaTutorial", 0);
		PlayerPrefs.SetInt ("PouvoirTutorial", 0);
	}

	void Update () {

		for (int i = 0; i < popUps.Length; i++) {
			if (i == popUpIndex) {
				popUps [i].SetActive (true);
			} else {
				popUps [i].SetActive (false);
			}
		}

		if (popUpIndex == 0) {
			if (PlayerPrefs.GetInt ("TS") == 1){
				popUpIndex = popUpIndex + 1;
				PlayerPrefs.SetInt ("BurgerTutorial", 1);
				Burger.SetActive (true);
				Health.SetActive (true);
			}
		}else if (popUpIndex == 1) {
			if (PlayerPrefs.GetInt ("TS") == 2){
				PlayerPrefs.SetInt ("CocaTutorial", 1);
				popUpIndex = popUpIndex + 1;
				Coca.SetActive (true);
			}
		}else if (popUpIndex == 2) {
			if (PlayerPrefs.GetInt ("TS") == 3){
				popUpIndex = popUpIndex + 1;
				Bottle.SetActive (true);
			}
		}else if (popUpIndex == 3) {
			if (PlayerPrefs.GetInt ("TS") == 4){
				popUpIndex = popUpIndex + 1;
				PlayerPrefs.SetInt ("PouvoirTutorial", 1);
			}
		}else if (popUpIndex == 4) {
			if (PlayerPrefs.GetInt ("TS") == 5){
				SceneManager.LoadScene ("Menu");
			}
		}
	}
}
