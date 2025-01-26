using UnityCommunity.UnitySingleton;
using UnityEngine;

public class DialogueManager : MonoSingleton<DialogueManager>
{
    public void StartDialogue(Inventory inventory, TextAsset text)
    {
        GetComponent<Dialog>().StartDialogue(inventory, text);
    }
}
