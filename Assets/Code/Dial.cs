using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueSystem : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject dialoguePanel;  // ������ �������
    [SerializeField] private TextMeshProUGUI dialogueText;  // ����� �������
    [SerializeField] private GameObject interactHint;  // ��������� "������� E"

    [Header("Dialogue Settings")]
    [SerializeField] private string[] dialogueLines;  // ������ ������
    [SerializeField] private KeyCode interactKey = KeyCode.E;  // ������� ��������������

    private int currentLine = 0;
    private bool isDialogueActive = false;
    private bool isPlayerInRange = false;

    void Update()
    {
        // ���� ����� � ���� � ����� E
        if (isPlayerInRange && Input.GetKeyDown(interactKey))
        {
            if (!isDialogueActive)
            {
                StartDialogue();  // �������� ������
            }
            else
            {
                ShowNextLine();  // ���������� ��������� �������
            }
        }
    }

    // ������ �������
    private void StartDialogue()
    {
        isDialogueActive = true;
        dialoguePanel.SetActive(true);
        interactHint.SetActive(false);
        currentLine = 0;
        dialogueText.text = dialogueLines[currentLine];
    }

    // ��������� �������
    private void ShowNextLine()
    {
        currentLine++;

        if (currentLine < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLine];
        }
        else
        {
            EndDialogue();
        }
    }

    // ���������� �������
    private void EndDialogue()
    {
        isDialogueActive = false;
        dialoguePanel.SetActive(false);
    }

    // ����� ����� � ���� NPC
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            interactHint.SetActive(true);
        }
    }

    // ����� ����� �� ���� NPC
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            interactHint.SetActive(false);

            // ���� ������ ��� �������, ��������� ���
            if (isDialogueActive)
            {
                EndDialogue();
            }
        }
    }
}
