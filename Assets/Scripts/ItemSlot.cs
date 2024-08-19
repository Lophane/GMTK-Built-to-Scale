using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
    private TMP_Text quantityText;

    [SerializeField]
    private Image itemImage;

    //=======ITEM DESCRIPTION SLOT=======//

    public Image itemDescriptionImage;
    public TMP_Text itemDescriptionNameText;
    public TMP_Text itemDescriptionText;

    public GameObject selectedShader;
    public bool thisItemSelected;

    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }


    public void AddItem(string itemName, Sprite itemSprite, string itemDescription, ItemType itemType)
    {
        this.itemName = itemName;
        this.itemSprite = itemSprite;
        //this.itemDescription = itemDescription;
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
        if(thisItemSelected)
            inventoryManager.UseItem(itemName);

        inventoryManager.DeselectAllSlots();
        selectedShader.SetActive(true);
        thisItemSelected = true;
        //itemDescriptionNameText.text = itemName;
        //itemDescriptionText.text = itemDescription;
        itemDescriptionImage.sprite = itemSprite;
        if (itemDescriptionImage.sprite == null)
            itemDescriptionImage.sprite = emptySprite;
    }

    public void OnRightClick()
    {

    }

}
