using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public GameObject[] skins;
    public int selectedCharacter;

    private void Awake()
    {
        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        foreach (GameObject player in skins)
            player.SetActive(false);

        skins[selectedCharacter].SetActive(true);

        UpdateUI();
    }

    public void ChangeNext()
    {
        skins[selectedCharacter].SetActive(false);
        selectedCharacter++;
        if (selectedCharacter == skins.Length)
            selectedCharacter = 0;

        skins[selectedCharacter].SetActive(true);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
        UpdateUI();
    }

    public void ChangePrevious()
    {
        skins[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter == -1)
            selectedCharacter = skins.Length -1;

        skins[selectedCharacter].SetActive(true);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
        UpdateUI();
    }

    public void UpdateUI()
    {
        
    }
}