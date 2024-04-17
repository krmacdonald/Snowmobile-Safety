using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

/*
 * @author Kyle
 * @date 4/17/2024
 * prerequisite: A text box with changing text.
 * output: A textbox that shows up info if items are right or wrong
 * 
 */
public class ClothingText : MonoBehaviour
{
    [SerializeField] private ClothingManager clothes;
    private string[] textToDisplay = new string[4];
    public string[,] textCollection = new string[4, 4];
    public TextAsset textFile;
    public TMP_Text text;
    public GameObject panel;
    void Start()
    {
        panel.SetActive(false);
        StreamReader reader = new StreamReader("Assets/Text Data/Clothing.txt");
        string temp = "asdf";
        for(int i = 0; i < 16; i++)
        {
            temp = reader.ReadLine();
            textCollection[i / 4, i % 4] = temp;
        }
    }

    public void GetText()
    {
        string[] currentClothes = clothes.equippedClothes;
        
        for(int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if(clothes.equippedClothes[i] == "") 
                {
                    textToDisplay[i] = "Nothing equipped!";
                }
                else if(textCollection[i, j].StartsWith(clothes.equippedClothes[i]))
                {
                    textToDisplay[i] = textCollection[i, j];
                }
            }
        }
    }

    public void SetText()
    {
        panel.SetActive(true);
        text.text = "Helmet\n" + textToDisplay[0] + "\nBody\n" + textToDisplay[1] + "\nGloves\n" + textToDisplay[2] + "\nBoots\n" + textToDisplay[3];
    }
}
