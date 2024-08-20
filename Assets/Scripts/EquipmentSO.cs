using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EquipmentSO : ScriptableObject
{
    public string itemName;
    public int health, speed, cooldownReduction, ability;
    [SerializeField]
    private Sprite itemSprite;

    public void PreviewEquipment()
    {
        GameObject.Find("StatManager").GetComponent<PlayerStats>().PreviewEquipmentStats(health, speed, cooldownReduction, ability, itemSprite);
    }

    public void EquipItem()
    {
        PlayerStats playerStats = GameObject.Find("StatManager").GetComponent<PlayerStats>();
        playerStats.health += health;
        playerStats.speed += speed;
        playerStats.cooldownReduction += cooldownReduction;
        playerStats.ability += ability;

        playerStats.UpdateEquipmentStats();
    }

    public void UnEquipItem()
    {

        PlayerStats playerStats = GameObject.Find("StatManager").GetComponent<PlayerStats>();
        playerStats.health -= health;
        playerStats.speed -= speed;
        playerStats.cooldownReduction -= cooldownReduction;
        playerStats.ability -= ability;

        playerStats.UpdateEquipmentStats();

    }

}