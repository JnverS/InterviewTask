using System;
using UnityEngine;

[RequireComponent(typeof(LinesManager))]
public class GameManager : MonoBehaviour
{
    [SerializeField] private CanvasManager canvasManager;
    [SerializeField] private LinesManager linesManager;
    [SerializeField] private float speed;

    private int score = 1000;
    private int bet = 10;
    private bool isPlaying;

    private void Awake()
    {
        linesManager.onScore += OnScoreChanged;
        linesManager.onStop += OnSpinStop;
        linesManager.Speed = speed;
        canvasManager.UpdateScore(score);
    }

    public void Spin()
    {
        if (isPlaying) return;
        if (score < bet) return;
        isPlaying = true;
        score -= bet;
        canvasManager.UpdateScore(score);
        linesManager.Spin();
    }

    private void OnDestroy()
    {
        linesManager.onScore -= OnScoreChanged;
        linesManager.onStop -= OnSpinStop;
    }

    private void OnScoreChanged(int multiplier)
    {
        if (multiplier < 1) return;
        var tmp = bet * Convert.ToInt32(Math.Pow(2, multiplier));
        score += tmp;
        canvasManager.UpdateScore(score);
    }

    private void OnSpinStop()
    {
        isPlaying = false;
    }
}