using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class EquippedSlot : MonoBehaviour, IPointerClickHandler
{
    //SlotApperance
    [SerializeField]
    private Image slotImage;

    [SerializeField]
    private TMP_Text slotName;

    //SlotData//
    [SerializeField]
    private ItemType itemType = new ItemType();

    private Sprite itemSprite;
    private string itemName;
    private string itemDescription;

    private InventoryManager inventoryManager;
    private EquipmentSOLibrary equipmentSOLibrary;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        equipmentSOLibrary = GameObject.Find("InventoryCanvas").GetComponent<EquipmentSOLibrary>();
    }

    //OtherVariables//
    private bool slotInUse; 

    [SerializeField]
    public GameObject selectedShader;

    [SerializeField]
    public bool thisItemSelected;

    [SerializeField]
    private Sprite emptySprite;

    



    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
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
        if (thisItemSelected && slotInUse)
            UnEquipGear();

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
    public void OnRightClick()
    {
        UnEquipGear();
    }


    public void EquipGear(Sprite itemSprite, string itemName, string itemDescription)
    {
        if(slotInUse)
            UnEquipGear();

        //UpdateImage//
        this.itemSprite = itemSprite;
        slotImage.sprite = this.itemSprite;
        slotName.enabled = false;


        //UpdateData//
        this.itemName = itemName;
        this.itemDescription = itemDescription;

        //UpdateStats
        for (int i = 0; i < equipmentSOLibrary.equipmentSO.Length; i++)
        {
            if (equipmentSOLibrary.equipmentSO[i].itemName == this.itemName)
                equipmentSOLibrary.equipmentSO[i].EquipItem();
        }

        slotInUse = true;

    }

    public void UnEquipGear()
    {
        inventoryManager.DeselectAllSlots();

        inventoryManager.Additem(itemName, itemSprite, itemDescription, itemType);

        //UpdateSlotImage
        this.itemSprite = emptySprite;
        slotImage.sprite = this.emptySprite;
        slotName.enabled = true;

        //UpdateStats
        for (int i = 0; i < equipmentSOLibrary.equipmentSO.Length; i++)
        {
            if (equipmentSOLibrary.equipmentSO[i].itemName == this.itemName)
                equipmentSOLibrary.equipmentSO[i].UnEquipItem();
        }

    }

}
