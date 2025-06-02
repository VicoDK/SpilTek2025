using UnityEngine;
using Mirror;
using TMPro;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine.TextCore.Text;
using System.Collections.Generic;

public class characterSelect : NetworkBehaviour
{
    /*[SerializeField] private GameObject characterSelectDisplay = default;
    [SerializeField] private Transform characterPreviewParent = default;
    [SerializeField] private Character[] characters = default;

    private List<GameObject> characterInstances = new List<GameObject>();
    private int currentCharacterIndex = 0;

    public override void OnStartClient()
    {
        if( characterPreviewParent.childCount==0)
        {
            foreach (var character in characters)
            {
                GameObject characterInstance =
                    Instantiate(characters.characterPreviewParent, characterPreviewParent);
                characterInstance.SetActive(false);

                //characterInstances.Add(characterInstance);
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

    [Command(requiresAuthority = true)]
    public void CmdSelect(int characterIndex, NetworkConnectionToClient sender=null)
    {
        GameObject characterInstance = Instantiate(characters[characterIndex].GameplayCharacterPrefab);
        NetworkServer.Spawn(characterInstance, sender);
    }
    public void Right()
    {
        characterInstances[currentCharacterIndex].SetActive(false);

        currentCharacterIndex = (currentCharacterIndex + 1) % characterInstances.Count;

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
