using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Button option1Button;
    public Button option2Button;
    public Text option1Text;
    public Text option2Text;

    public void ShowChoices(string text1, string text2, GameObject result1, GameObject result2)
    {
        dialoguePanel.SetActive(true);
        option1Text.text = text1;
        option2Text.text = text2;

        option1Button.onClick.RemoveAllListeners();
        option2Button.onClick.RemoveAllListeners();

        option1Button.onClick.AddListener(() => SelectOption(result1));
        option2Button.onClick.AddListener(() => SelectOption(result2));
    }

    void SelectOption(GameObject result)
    {
        dialoguePanel.SetActive(false);
        result.SetActive(true);
    }
}
