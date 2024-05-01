using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DataManagerBetweenScenes : MonoBehaviour
{
    public static DataManagerBetweenScenes Instance;
    public TMP_InputField scoreInput;
    public int score;

    // ���������� ������� ��� ���������� � ��������� score
    public event Action<int> OnScoreChanged;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeScore()
    {
        int newScore;
        if (int.TryParse(scoreInput.text, out newScore))
        {
            score = newScore;
            // �������� �������, ����� ���������� �� ��������� score
            OnScoreChanged?.Invoke(score);
        }
    }

    public int getScore()
    {
        return score;
    }

    public void setScore(int value)
    {
        score = value;
    }

}
