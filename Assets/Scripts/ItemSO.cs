using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;

    [System.Serializable]
    public struct AttributeChange
    {
        public AttributeToChange attribute;
        public int amount;
    }

    public List<AttributeChange> attributeChanges = new List<AttributeChange>();

    public void UseItem()
    {
        PlayerBehavior player = GameObject.Find("Player").GetComponent<PlayerBehavior>();

        foreach (var change in attributeChanges)
        {
            switch (change.attribute)
            {
                case AttributeToChange.health:
                    //player.SetHealth(change.amount);
                    break;
                case AttributeToChange.power:
                    //player.SetPower(change.amount);
                    break;
                case AttributeToChange.speed:
                    //player.SetSpeed(change.amount);
                    break;
                case AttributeToChange.cooldownReduction:
                    //player.SetCooldownReduction(change.amount);
                    break;
                case AttributeToChange.stamina:
                    //player.SetStamina(change.amount);
                    break;
                case AttributeToChange.ability:
                    //player.SetAbility(change.amount);
                    break;
                case AttributeToChange.none:
                default:
                    break;
            }
        }
    }

    public enum AttributeToChange
    {
        none,
        health,
        power,
        speed,
        cooldownReduction,
        stamina,
        ability
    };
}