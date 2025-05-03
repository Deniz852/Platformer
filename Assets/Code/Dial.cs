using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueSystem : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject dialoguePanel;  // Панель диалога
    [SerializeField] private TextMeshProUGUI dialogueText;  // Текст реплики
    [SerializeField] private GameObject interactHint;  // Подсказка "Нажмите E"

    [Header("Dialogue Settings")]
    [SerializeField] private string[] dialogueLines;  // Массив реплик
    [SerializeField] private KeyCode interactKey = KeyCode.E;  // Клавиша взаимодействия

    private int currentLine = 0;
    private bool isDialogueActive = false;
    private bool isPlayerInRange = false;

    void Update()
    {
        // Если игрок в зоне и нажал E
        if (isPlayerInRange && Input.GetKeyDown(interactKey))
        {
            if (!isDialogueActive)
            {
                StartDialogue();  // Начинаем диалог
            }
            else
            {
                ShowNextLine();  // Показываем следующую реплику
            }
        }
    }

    // Запуск диалога
    private void StartDialogue()
    {
        isDialogueActive = true;
        dialoguePanel.SetActive(true);
        interactHint.SetActive(false);
        currentLine = 0;
        dialogueText.text = dialogueLines[currentLine];
    }

    // Следующая реплика
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

    // Завершение диалога
    private void EndDialogue()
    {
        isDialogueActive = false;
        dialoguePanel.SetActive(false);
    }

    // Игрок вошёл в зону NPC
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            interactHint.SetActive(true);
        }
    }

    // Игрок вышел из зоны NPC
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            interactHint.SetActive(false);

            // Если диалог был активен, закрываем его
            if (isDialogueActive)
            {
                EndDialogue();
            }
        }
    }
}
