using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;

    public string option1Text;
    public string option2Text;
    public GameObject result1;
    public GameObject result2;

    public void StartDialogue()
    {
        dialogueManager.ShowChoices(option1Text, option2Text, result1, result2);
    }
}
