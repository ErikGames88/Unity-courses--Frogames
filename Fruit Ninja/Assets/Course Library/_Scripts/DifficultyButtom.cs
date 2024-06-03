using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtom : MonoBehaviour
{
    private Button _button;

    private GameManager gameManager;

    [Range(1,3)]
    public int difficulty;

    void Start()
    {
        _button = GetComponent<Button>();
        gameManager = FindObjectOfType<GameManager>();

        _button.onClick.AddListener(SetDifficulty);
    }

    void SetDifficulty()
    {
        gameManager.StartGame(difficulty);
    }
    
}
