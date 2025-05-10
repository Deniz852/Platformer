using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject MenuUI; // ������ �� GameObject ���� �����
    public Button resumeButton; // ������ "����������"
    public Button quitButton; // ������ "�����"

    private bool isPaused = false;

    void Start()
    {
        // ��������� ������ ������������� ������� ������
        resumeButton.onClick.AddListener(Resume);
        quitButton.onClick.AddListener(QuitGame);

        // �������� ���� ��� ������
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        // ��������� ������� Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        // �������� ����
        pauseMenuUI.SetActive(false);
        MenuUI.SetActive(true);

        // ������������ �����
        Time.timeScale = 1f;

        // ������� �����
        isPaused = false;

        // ������������ ������ (���� �����)
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }

    void Pause()
    {
        // ���������� ����
        pauseMenuUI.SetActive(true);
        MenuUI.SetActive(false);

        // ������������� �����
        Time.timeScale = 0f;

        // ������ �� �����
        isPaused = true;

        // ������������ ������ (���� �����)
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void QuitGame()
    {
        // ������� �� ���� (�������� ������ � �����)
        SceneManager.LoadScene(0);
    }
}