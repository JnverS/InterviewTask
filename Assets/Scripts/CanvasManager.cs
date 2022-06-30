using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private Text text;

    public void UpdateScore(int score)
    {
        text.text = score.ToString();
    }
}