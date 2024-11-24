using NUnit.Framework;
using TMPro;
using UnityEngine;

public class ModalScript : MonoBehaviour
{

    private GameObject content;
    private TextMeshProUGUI messageText;
    private TextMeshProUGUI titleText;
    private TextMeshProUGUI resumeButtonText;
    private UnityEngine.UI.Button resumeButton;

    private enum ModalState
    {
        Rules,
        Pause,
        GameOver
    }

    private ModalState currentState;

    void Start()
    {
        content = transform.Find("Content").gameObject;
        titleText = content.transform.Find("TitleTMP").GetComponent<TextMeshProUGUI>();
        messageText = content.transform.Find("MessageTMP").GetComponent<TextMeshProUGUI>();
        resumeButton = content.transform.Find("ResumeButton").GetComponent<UnityEngine.UI.Button>();
        resumeButtonText = resumeButton.transform.Find("ResumeButtonText").GetComponent<TextMeshProUGUI>(); ;
      

        Time.timeScale = 0.0f; 
        currentState = ModalState.Rules;
        ShowModalWithState(currentState);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && currentState != ModalState.GameOver)
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        bool isPaused = content.activeInHierarchy;
        currentState = isPaused ? ModalState.Pause : ModalState.Pause;
        Time.timeScale = isPaused ? 1.0f : 0.0f;
        content.SetActive(!isPaused);
        ShowModalWithState(currentState);
    }

    private void ShowModalWithState(ModalState state)
    {
        switch (state)
        {
            case ModalState.Rules:
                titleText.text = "������� ����";
                messageText.text = "����� ���������� � ����! ��������� ������, ����� ������, � ��������� ������������ � �������.";
                SetResumeButton("������ ����", StartGame);
                break;

            case ModalState.Pause:
                titleText.text = "�����";
                messageText.text = "�� ������ ����������?";
                SetResumeButton("����������", ResumeGame);
                break;

            case ModalState.GameOver:
                titleText.text = "���� ��������";
                messageText.text = "�� ����������� � ������. ������ ����������� �����?";
                SetResumeButton("����� ����", RestartGame);
                break;
        }

        content.SetActive(true);
    }

    private void SetResumeButton(string buttonText, UnityEngine.Events.UnityAction action)
    {
        resumeButtonText.text = buttonText;
        resumeButton.onClick.RemoveAllListeners(); 
        resumeButton.onClick.AddListener(action);
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }

    private void StartGame()
    {
        Time.timeScale = 1.0f;
        content.SetActive(false);
    }

    private void ResumeGame()
    {
        Time.timeScale = 1.0f;
        content.SetActive(false);
    }

    private void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void TriggerGameOver()
    {
        currentState = ModalState.GameOver;
        ShowModalWithState(currentState);
        Time.timeScale = 0.0f;
    }
}
