using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Playables;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public int health, speed, cooldownReduction, ability;

    [SerializeField]
    private TMP_Text healthText, speedText, cooldownReductionText, abilityText;

    [SerializeField]
    private TMP_Text healthPreText, speedPreText, cooldownReductionPreText, abilityPreText;
    [SerializeField]
    private Image previewImage;
    [SerializeField]
    private GameObject selectedItemStats;
    [SerializeField]
    private GameObject selectedItemImage;

    public GregoryStats gregoryStats;

    private void Start()
    {
        UpdateEquipmentStats();
    }


    public void UpdateEquipmentStats()
    {
        healthText.text = health.ToString();
        speedText.text = speed.ToString();
        cooldownReductionText.text = cooldownReduction.ToString();
        abilityText.text = ability.ToString();
    }

    public void PreviewEquipmentStats(int health, int speed, int cooldownReduction, int ability, Sprite itemSprite)
    {
        healthPreText.text = health.ToString();
        speedPreText.text = speed.ToString();
        cooldownReductionPreText.text = cooldownReduction.ToString();
        abilityPreText.text = ability.ToString();

        previewImage.sprite= itemSprite;

        selectedItemImage.SetActive(true);
        selectedItemStats.SetActive(true);

    }

    public void TurnOffPreviewStats()
    {
        selectedItemImage.SetActive(false); 
        selectedItemStats.SetActive(false);
    }

    public void PushGregoryStats()
    {
        gregoryStats.health = health;
        gregoryStats.speed = speed;
        gregoryStats.cooldownReduction = cooldownReduction;
        gregoryStats.ability = ability;
        Debug.Log("He got his shit");
    }

}
