using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    [System.Serializable]
    public class ShopItem
    {
        public GameObject character;
        public int price;
        public bool isPurchased, isEquiped;
        public string name;
    }
    public List<ShopItem> ShopItemsList;
    public int moneyWithPlayer;
    //public GameObject[] characters;
    public Text priceOfChar, nameOfChar, moneyText, ownedText, priceText;
    public int selectedCharacters = 0;
    public Button buyButton, equipButton, equipedButton;
    bool BuyCharacter = false;
    public GameObject notEnoughMoneyPanel;
    [SerializeField] UIManager UIManager;

    private void Start()
    {
        priceOfChar.text = "$ " + (ShopItemsList[selectedCharacters].price).ToString();
        nameOfChar.text = (ShopItemsList[selectedCharacters].name);

        UIManager.LoadData();
        selectedCharacters = PlayerPrefs.GetInt("SelectedCharacter");

        BackToMainMenu();
    }

    private void Update()
    {
        moneyWithPlayer = PlayerPrefs.GetInt("MoneyWithPlayer");
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacters);
        moneyText.text = "$ " + moneyWithPlayer.ToString();
        if (ShopItemsList[selectedCharacters].isPurchased)
        {
            equipButton.gameObject.SetActive(true);
            buyButton.gameObject.SetActive(false);
            ownedText.gameObject.SetActive(true);
            priceText.gameObject.SetActive(false);
            priceOfChar.gameObject.SetActive(false);
        }
        else if (!ShopItemsList[selectedCharacters].isPurchased && !ShopItemsList[selectedCharacters].isEquiped)
        {
            buyButton.gameObject.SetActive(true);
            equipButton.gameObject.SetActive(false);
            equipedButton.gameObject.SetActive(false);
            ownedText.gameObject.SetActive(false);
            priceText.gameObject.SetActive(true);
            priceOfChar.gameObject.SetActive(true);
        }

        if (ShopItemsList[selectedCharacters].isPurchased && ShopItemsList[selectedCharacters].isEquiped)
        {
            equipButton.gameObject.SetActive(false);
            equipedButton.gameObject.SetActive(true);
        }
        else if(ShopItemsList[selectedCharacters].isPurchased && !ShopItemsList[selectedCharacters].isEquiped)
        {
            equipButton.gameObject.SetActive(true);
            equipedButton.gameObject.SetActive(false);
        }

        if (moneyWithPlayer >= ShopItemsList[selectedCharacters].price)
        {
            BuyCharacter = true;
        }
        else
        {
            BuyCharacter = false;
        }
    }

    public void NextCharacter()
    {
        ShopItemsList[selectedCharacters].character.SetActive(false);
        selectedCharacters = (selectedCharacters + 1) % ShopItemsList.Count;
        priceOfChar.text = "$ " + (ShopItemsList[selectedCharacters].price).ToString();
        nameOfChar.text = (ShopItemsList[selectedCharacters].name);
        ShopItemsList[selectedCharacters].character.SetActive(true);
    }

    public void PreviousCharacter()
    {
        ShopItemsList[selectedCharacters].character.SetActive(false);
        selectedCharacters--;
        if (selectedCharacters < 0)
        {
            selectedCharacters += ShopItemsList.Count;
        }
        priceOfChar.text = "$ " + (ShopItemsList[selectedCharacters].price).ToString();
        nameOfChar.text = (ShopItemsList[selectedCharacters].name);
        ShopItemsList[selectedCharacters].character.SetActive(true);
    }

    public void EquipCharacter()
    {
        if (ShopItemsList[selectedCharacters].isPurchased)
        {
            for (int i = 0; i < ShopItemsList.Count;i++)
            {
                if(i == selectedCharacters)
                {
                    ShopItemsList[selectedCharacters].isEquiped = true;
                    equipButton.gameObject.SetActive(false);
                    equipedButton.gameObject.SetActive(true);
                }
                else
                {
                    ShopItemsList[i].isEquiped = false;
                    equipedButton.gameObject.SetActive(false);
                    equipButton.gameObject.SetActive(true);
                }
            }
        }
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacters);
    }

    public void PurchaseCharacter()
    {
        if(BuyCharacter)
        {
            int moneyLeft;
            moneyLeft = moneyWithPlayer - ShopItemsList[selectedCharacters].price;
            PlayerPrefs.SetInt("MoneyWithPlayer", moneyLeft);
            equipButton.gameObject.SetActive(true);
            buyButton.gameObject.SetActive(false);
            ShopItemsList[selectedCharacters].isPurchased = true;
            BuyCharacter = false;
        }
        else if(!BuyCharacter)
        {
            notEnoughMoneyPanel.SetActive(true);
        }
    }

    public void BackToMainMenu()
    {
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacters);
        for (int i = 0; i < ShopItemsList.Count; i++)
        {
            if(ShopItemsList[i].isEquiped)
            {
                ShopItemsList[i].character.SetActive(true);
                selectedCharacters = i;
            }
            else
            {
                ShopItemsList[i].character.SetActive(false);
            }
        }
    }
}