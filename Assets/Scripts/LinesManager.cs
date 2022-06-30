using System.Collections;
using UnityEngine;

public class LinesManager : MonoBehaviour
{
    [SerializeField] private Line[] lines;
    [SerializeField] private float spinTime = 5f;

    public delegate void OnScoreDelegate(int multiplier);
    public delegate void OnStopDelegate();

    public event OnScoreDelegate onScore;
    public event OnStopDelegate onStop;

    public float Speed
    {
        set
        {
            foreach (var line in lines)
            {
                line.Speed = value;
            }
        }
    }

    public void Spin()
    {
        foreach (var line in lines)
        {
            line.Spin();
        }

        StartCoroutine(SpinTimer());
    }


    private IEnumerator SpinTimer()
    {
        yield return new WaitForSeconds(spinTime);
        foreach (var line in lines)
        {
            line.Stop();
            line.FixPosition();
        }

        onScore?.Invoke(CalculateMultiplier());
        onStop?.Invoke();
    }

    private int CalculateMultiplier()
    {
        var score = 0;
        for (var i = 1; i < lines[0].slots.Length - 1; i++)
        {
            var oldValue = lines[0].slots[i].value;
            var win = true;
            foreach (var line in lines)
            {
                if (oldValue == line.slots[i].value) continue;
                win = false;
                break;
            }

            if (win) score++;
        }

        return score;
    }
}