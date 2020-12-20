using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour {
	HealthManager healthManage;
	public int level = 1;
	public int exp = 0;
	private int requireExp = 9;
	public Text levelText;
	public Text expText;
	public Slider expSlider;

    //public AudioSource levelUpAudio;

	void Start() {
		healthManage = GetComponent<HealthManager>();
		expText = GameObject.Find("UI/InGameUI/CharacterStatus/ExpText").GetComponent<Text>();
		expSlider = GameObject.Find("UI/InGameUI/CharacterStatus/ExpText/Slider").GetComponent<Slider>();
		
		levelText = GameObject.Find("UI/InGameUI/Startup").GetComponent<Text>();
		

		UpdateUI();
	}

	void UpdateUI() {
		

		levelText.text = "Round: " + level;
		expText.text = "Exp: " + exp + " / " + requireExp;

		float percentage = (float) exp / (float) requireExp;
		expSlider.value = percentage;
	}

	public int GetLevel() {
		return level;
	}

	public void GiveExp(int amount) {
		exp += 3;
		//Debug.Log(exp);
		//Debug.Log(requireExp);

		CheckLevelUp();
	}

	void CheckLevelUp() {
		if(exp >= requireExp) {
			exp = exp - requireExp;
			requireExp += 7+(level*2);
			level++;

			CheckLevelUp();
		}
		healthManage.SetHealth(100);
		UpdateUI();
	}
}
