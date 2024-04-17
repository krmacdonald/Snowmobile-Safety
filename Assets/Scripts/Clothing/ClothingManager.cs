using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Kyle Macdonald
 * @date 4/3/2024
 * Prerequisite: Buttons that can be clicked to trigger functions
 * Output: A functioning scene that allows the user to choose their own clothes for the snowmobiling simulation
 */

public class ClothingManager : MonoBehaviour
{
    //Booleans to be used for the transition to the next scene
    public bool[] correctClothes = {false, false, false, false};
    public string[] equippedClothes = new string[4];
    [SerializeField]
    private GameObject clothesParent;
    
    //Applies this function to the helmet buttons, parameter set manually in unity editor.
    public void changeHelmet(string clothingPiece)
    {
        switch (clothingPiece)
        {
            case "Beanie":
                manageClothingData(false, 0, clothingPiece);
                break;
            case "Bike Helmet":
                manageClothingData(false, 0, clothingPiece);
                break;
            case "Snowmobile Helmet":
                manageClothingData(true, 0, clothingPiece);
                break;
            case "ATV Helmet":
                manageClothingData(false, 0, clothingPiece);
                break;
        }
    }

    public void changeShirt(string clothingPiece)
    {
        switch (clothingPiece)
        {
            case "Jacket":
                manageClothingData(true, 1, clothingPiece);
                break;
            case "Jeans":
                manageClothingData(false, 1, clothingPiece);
                break;
            case "Full Jacket":
                manageClothingData(true, 1, clothingPiece);
                break;
            case "Shirt":
                manageClothingData(false, 1, clothingPiece);
                break;
        }
    }

    public void changeGloves(string clothingPiece)
    {
        switch (clothingPiece)
        {
            case "Mittens":
                manageClothingData(false, 2, clothingPiece);
                break;
            case "Fingerless Gloves":
                manageClothingData(false, 2, clothingPiece);
                break;
            case "Padded Gloves":
                manageClothingData(true, 2, clothingPiece);
                break;
            case "Biker Gloves":
                manageClothingData(false, 2, clothingPiece);
                break;
        }
    }

    public void changeBoots(string clothingPiece)
    {
        switch (clothingPiece)
        {
            case "Snow Boots":
                manageClothingData(true, 3, clothingPiece);
                break;
            case "Fluffy Boots":
                manageClothingData(false, 3, clothingPiece);
                break;
            case "Sneakers":
                manageClothingData(false, 3, clothingPiece);
                break;
            case "Flip Flops":
                manageClothingData(false, 3, clothingPiece);
                break;
        }
    }

    //Manages the array that contains the data of whether or not the gear is currently correct.
    /*
     * -=-=-=-=-Index guide-=-=-=-=-
     * 0: Helm
     * 1: Shirt
     * 2: Gloves
     * 3: Shoes
     * -=-=-=-=-=-=-=-=-=-=-=-=-=-=-
     */

    public void manageClothingData(bool isCorrect, int indexOfGear, string clothingPiece)
    {
        correctClothes[indexOfGear] = isCorrect;
        removeClothes();
        equippedClothes[indexOfGear] = clothingPiece;
        addClothes();
    }

    private void removeClothes()
    {
        for (int i = 0; i < 4; i++)
        {
            if(equippedClothes[i] != null)
                clothesParent.transform.Find(equippedClothes[i]).gameObject.SetActive(false);
        }
        clothesParent.SetActive(true);
    }

    private void addClothes()
    {
        for(int i = 0; i < 4; i++)
        {
            if (equippedClothes[i] != null)
                clothesParent.transform.Find(equippedClothes[i]).gameObject.SetActive(true);
        }
    }
}
