using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Timers;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    //=======ITEM DATA=======//

    public string itemName;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public Sprite emptySprite;
    public ItemType itemType;

    //=======ITEM SLOT=======//
    [SerializeField]
    private Image itemImage;


    //=======EQUIPPED SLOT=======//

    [SerializeField]
    private EquippedSlot headSlot, armsSlot, legsSlot;


    public GameObject selectedShader;
    public bool thisItemSelected;

    private InventoryManager inventoryManager;
    private EquipmentSOLibrary equipmentSOLibrary;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        equipmentSOLibrary = GameObject.Find("InventoryCanvas").GetComponent<EquipmentSOLibrary>();
    }


    public void AddItem(string itemName, Sprite itemSprite, string itemDescription, ItemType itemType)
    {
        this.itemName = itemName;
        this.itemSprite = itemSprite;
        this.itemType = itemType;

        isFull = true;
        itemImage.sprite = itemSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    public void OnLeftClick()
    {
        if (isFull)
        {
            if (thisItemSelected)
            {
                EquipGear();
            }
            else
            {
                inventoryManager.DeselectAllSlots();
                selectedShader.SetActive(true);
                thisItemSelected = true;
                for (int i = 0; i < equipmentSOLibrary.equipmentSO.Length; i++)
                {
                    if (equipmentSOLibrary.equipmentSO[i].itemName == this.itemName)
                        equipmentSOLibrary.equipmentSO[i].PreviewEquipment();
                }
            }
        }
        else
        {
            GameObject.Find("StatManager").GetComponent<PlayerStats>().TurnOffPreviewStats();
            inventoryManager.DeselectAllSlots();
            selectedShader.SetActive(true);
            thisItemSelected = true;
        }


        

    }

    private void EquipGear()
    {
        if (itemType == ItemType.head)
            headSlot.EquipGear(itemSprite, itemName, itemDescription);
        if (itemType == ItemType.arms)
            armsSlot.EquipGear(itemSprite, itemName, itemDescription);
        if (itemType == ItemType.legs)
            legsSlot.EquipGear(itemSprite, itemName, itemDescription);

        EmptySlot();

    }

    public void EmptySlot()
    {
        itemImage.sprite = emptySprite;
        isFull = false;
    }


    public void OnRightClick()
    {

    }

}
