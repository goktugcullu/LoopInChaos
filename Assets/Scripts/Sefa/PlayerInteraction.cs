using UnityEngine;
using UnityEngine.UI;
public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 3f;
    public LayerMask npcLayer;
    public GameObject interactionUI;
    private Transform lookedNPC;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance, npcLayer))
        {
            lookedNPC = hit.transform;
            interactionUI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                lookedNPC.GetComponent<DialogueTrigger>().StartDialogue();
            }
        }
        else
        {
            interactionUI.SetActive(false);
        }
    }
}
