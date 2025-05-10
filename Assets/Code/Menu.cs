using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject MenuUI; // Ссылка на GameObject меню паузы
    public Button resumeButton; // Кнопка "Продолжить"
    public Button quitButton; // Кнопка "Выйти"

    private bool isPaused = false;

    void Start()
    {
        // Назначаем методы обработчиками нажатия кнопок
        resumeButton.onClick.AddListener(Resume);
        quitButton.onClick.AddListener(QuitGame);

        // Скрываем меню при старте
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        // Проверяем нажатие Esc
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
        // Скрываем меню
        pauseMenuUI.SetActive(false);
        MenuUI.SetActive(true);

        // Возобновляем время
        Time.timeScale = 1f;

        // Снимаем паузу
        isPaused = false;

        // Разблокируем курсор (если нужно)
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }

    void Pause()
    {
        // Показываем меню
        pauseMenuUI.SetActive(true);
        MenuUI.SetActive(false);

        // Останавливаем время
        Time.timeScale = 0f;

        // Ставим на паузу
        isPaused = true;

        // Разблокируем курсор (если нужно)
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void QuitGame()
    {
        // Выходим из игры (работает только в билде)
        SceneManager.LoadScene(0);
    }
}