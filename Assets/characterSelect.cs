using UnityEngine;
using Mirror;
using TMPro;
using NUnit.Framework;
using Unity.VisualScripting;

public class characterSelect : MonoBehaviour
{
    /*[SerializeField] private GameObject characterSelectDisplay = default;
    [SerializeField] private Transform characterPreviewParent = default;
    [SerializeField] private Character[] characters = default;

    private int currentCharacterIndex = 0;
    private List<GameObject> characterInstances = new List<GameObject>();

    public override void OnStartClient()
    {
        if( characterPreviewParent,childCount==0)
        {
            foreach (var character in characters)
            {
                GameObject characterInstance =
                    Instantiate(character.CharacterPreviewPrefab, characterPreviewParent);
                characterInstance.SetActive(false);

                characterInstance.AddComponent(characterInstance);
            }
        }
        characterInstances[currentCharacterIndex].SetActive(true);

        characterSelectDisplay.SetActive(true);
    }

    public void Select()
    {
        CmdSelect(currentCharacterIndex);
        characterSelectDisplay.SetActive(false);
    }

    [Command(ignoreAuthority=true)]
    public void CmdSelect(int characterIndex, NetworkConnectionToClient sender=null)
    {
        GameObject characterInstance = Instantiate(characters[characterIndex].GameplayCharacterPrefab);
        NetworkServer.Spawn(characterInstance, sender);
    }
    public void Right()
    {
        characterInstances[currentCharacterIndex].SetActive(false);

        currentCharacterIndex = (currentCharacterIndex + 1) % characters;

        characterSelectDisplay.SetActive(true);

    }

    public void left()
    {
        characterInstances[currentCharacterIndex].SetActive(false);

        currentCharacterIndex--;
        if(currentCharacterIndex < 0)
        {
            currentCharacterIndex += characterInstances.Count;
        }
        characterInstances[currentCharacterIndex].SetActive(true);

    }*/
}
