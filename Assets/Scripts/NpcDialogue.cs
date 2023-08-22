using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcDialogue : MonoBehaviour
{
    public string[] dialogueNpc;
    private int dialogueIndex;

    public GameObject dialoguePanel;
    public Text dialogueText;
    public Text nameNpc;
    public string nameNpcString;
    public Image imageNpc;
    public Sprite spriteNpc;

    public bool readyToSpeak = true;
    public Button nextButton;
    public Button skipButton;

    // Start is called before the first frame update
    void Start()
    {
        dialoguePanel.SetActive(true);
        readyToSpeak = true;

        nextButton = GameObject.Find("NextButton").GetComponent<Button>();
        nextButton.onClick.AddListener(NextDialogue);

        skipButton = GameObject.Find("SkipButton").GetComponent<Button>();
        skipButton.onClick.AddListener(SkipDialogue);

        StartDialogue();
    }

    void NextDialogue()
    {
        dialogueIndex++;
        if (dialogueIndex < dialogueNpc.Length)
        {
            StartCoroutine(ShowDialogue());
        }
        else
        {
            EndDialogue();
        }
    }

    void SkipDialogue()
    {
        EndDialogue(); // Chama o método para terminar o diálogo
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        nextButton.gameObject.SetActive(false);
        skipButton.gameObject.SetActive(false);
        readyToSpeak = false;
        FindObjectOfType<PlayerController>().speed = 1f;
    }

    IEnumerator ShowDialogue()
    {
        dialogueText.text = "";
        foreach (char letter in dialogueNpc[dialogueIndex])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }

    void StartDialogue()
    {
        nameNpc.text = nameNpcString;
        imageNpc.sprite = spriteNpc;
        dialogueIndex = 0;
        dialoguePanel.SetActive(true);
        nextButton.gameObject.SetActive(true);
        skipButton.gameObject.SetActive(true);
        StartCoroutine(ShowDialogue());
    }

    // ... (rest of the script)
}
