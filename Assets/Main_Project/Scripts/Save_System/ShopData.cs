using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopData
{
    public int[] price;
    public int moneyWithPlayer;
    public bool[] isPurchased;
    public bool[] isEquiped;
    public int HighScore;

    public ShopData (CharacterSelector characterSelector)
    {
        price = new int[characterSelector.ShopItemsList.Count];
        isPurchased = new bool[characterSelector.ShopItemsList.Count];
        isEquiped = new bool[characterSelector.ShopItemsList.Count];
        for (int i = 0; i < characterSelector.ShopItemsList.Count; i++)
        {
            price[i] = characterSelector.ShopItemsList[i].price;
            isEquiped[i] = characterSelector.ShopItemsList[i].isEquiped;
            isPurchased[i] = characterSelector.ShopItemsList[i].isPurchased;
        }
        moneyWithPlayer = characterSelector.moneyWithPlayer;
    }
}
