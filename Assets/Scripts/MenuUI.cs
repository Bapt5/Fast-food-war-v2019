using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour {

	private int BestScore;
	public Text textBestScore;
	public Text textHealth;
	private int ScorePlayer;
	private int HealthPlayer;
	public Button Speed;
	public Button Explosion;
	public Button Prank;
	public Image SpeedImage;
	public Image ExplosionImage;
	public Image PrankImage;
	public Sprite SpeedFalse;
	public Sprite ExplosionFalse;
	public Sprite PrankFalse;
	public Sprite SpeedTrue;
	public Sprite ExplosionTrue;
	public Sprite PrankTrue;
	private bool SpeedBool=false;
	private bool ExplosionBool=false;
	private bool PrankBool=false;
	public GameObject MenuObject;
	public GameObject CreditObject;
	public GameObject TutorialPouvoir;
	public GameObject TutorialNewGame;

	IEnumerator Tutorial(){
		PlayerPrefs.SetInt ("Tutorial", 1);
		TutorialPouvoir.SetActive (true);
		yield return new WaitForSeconds (8f);
		TutorialPouvoir.SetActive (false);
		TutorialNewGame.SetActive (true);
		yield return new WaitForSeconds (5f);
		TutorialNewGame.SetActive (false);
	}

	void Start () {
		TutorialPouvoir.SetActive (false);
		TutorialNewGame.SetActive (false);
		PlayerPrefs.SetInt ("Menu", 1);

		Time.timeScale=1;
		PlayerPrefs.SetInt("Health",3);
		Explosion.interactable = false;
		Speed.interactable = false;
		Prank.interactable = false;
		MenuObject.SetActive (true);
		CreditObject.SetActive (false);

		Scene actualScene = SceneManager.GetActiveScene();
		if (PlayerPrefs.GetInt ("Tutorial") == 0 && actualScene.name == "Menu") {
			StartCoroutine (Tutorial ());
		}
	}

	public void Credit () {
		MenuObject.SetActive (false);
		CreditObject.SetActive (true);
	}

	public void Restart () {
		if (PlayerPrefs.GetInt ("Tutorial") == 0) {
			SceneManager.LoadScene ("Tutorial");
		} else {
			SceneManager.LoadScene ("Game");
		}
	}

	public void Menu() {
		SceneManager.LoadScene ("Menu");
	}

	public void BonusSpeed (){
		SpeedBool = !SpeedBool;
		PrankBool = false;
		ExplosionBool = false;
	}

	public void BonusPrank (){
		PrankBool = !PrankBool;
		ExplosionBool = false;
		SpeedBool = false;
	}

	public void BonusExplosion (){
		ExplosionBool = !ExplosionBool;
		PrankBool = false;
		SpeedBool = false;
	}

	void Update (){
		BestScore = PlayerPrefs.GetInt ("bestScore");
		ScorePlayer = PlayerPrefs.GetInt("Score");
		HealthPlayer = PlayerPrefs.GetInt("Health");
		if(BestScore > ScorePlayer){
		textBestScore.text = "Meilleur score : " + BestScore;
	}
		if (BestScore <= ScorePlayer) {
			textBestScore.text = "Nouveau score : " + BestScore;
		}

		textHealth.text = ""+ HealthPlayer;

		if (PlayerPrefs.GetInt ("Menu") == 1) {
			if (BestScore >= 10) {
				Speed.interactable = true;
			}

			if (BestScore >= 20) {
				Explosion.interactable = true;
			}

			if (BestScore >= 30) {
				Prank.interactable = true;
			}

			if (SpeedBool == true) {
				PlayerPrefs.SetInt ("BonusValue", 1);
				SpeedImage.sprite = SpeedTrue;
			}

			if (ExplosionBool == true) {
				PlayerPrefs.SetInt ("BonusValue", 2);
				ExplosionImage.sprite = ExplosionTrue;
			}

			if (PrankBool == true) {
				PlayerPrefs.SetInt ("BonusValue", 3);
				PrankImage.sprite = PrankTrue;
			}

			if (SpeedBool == false) {
				SpeedImage.sprite = SpeedFalse;
			}

			if (ExplosionBool == false) {
				ExplosionImage.sprite = ExplosionFalse;
			}

			if (PrankBool == false) {
				PrankImage.sprite = PrankFalse;
			}

			if (PrankBool == false && ExplosionBool == false && SpeedBool == false) {
				PlayerPrefs.SetInt ("BonusValue", 0);
			}
		}
	}

}
	