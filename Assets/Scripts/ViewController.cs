using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ViewController : MonoBehaviour
{
    [SerializeField] private GameObject webView;
    void Start()
    {
        if (HasConnection())
            webView.gameObject.SetActive(true);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    private static bool HasConnection()
    {
        try
        {
            using (var client = new WebClient())
            using (var stream = new WebClient().OpenRead("http://www.google.com"))
            {
                return true;
            }
        }
        catch
        {
            return false;
        }
    }
}
