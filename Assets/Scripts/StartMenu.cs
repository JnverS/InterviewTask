using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject switchButton;
    [SerializeField] private GameObject on;
    [SerializeField] private GameObject off;
    [SerializeField] private Canvas policy;
    [SerializeField] private Canvas mainScene;
    private bool isOn;

    public void SwitchButton()
    {
        if (isOn)
        {
            on.SetActive(false);
            off.SetActive(true);
            switchButton.transform.position = new Vector3(switchButton.transform.position.x - 0.25f, switchButton.transform.position.y);
        }
        else
        {
            on.SetActive(true);
            off.SetActive(false);
            switchButton.transform.position = new Vector3(switchButton.transform.position.x + 0.25f, switchButton.transform.position.y);
        }

        isOn = !isOn;
    }
    public void StartButton()
    {
        if (isOn)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
    public void BackButton()
    {
        mainScene.gameObject.SetActive(true);
        policy.gameObject.SetActive(false);
    }    
    public void ShowPrivacyPolicy()
    {
        mainScene.gameObject.SetActive(false);
        policy.gameObject.SetActive(true);
    }
}
