using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;

public enum Scores {
    Carbon,
    Biodiversity,
    Food,
    Energy,
}

[Serializable]
public class ScoresFloatDictionary : SerializableDictionary<Scores, float> {}

/*
 * PlayerScores keeps track of the current scores for the player
 */
public class PlayerScores : MonoBehaviour
{
    [SerializeField]
    public ScoresFloatDictionary MaxValues = new ScoresFloatDictionary() {
        {Scores.Carbon, 1000},
        {Scores.Biodiversity, 1000},
        {Scores.Food, 1000},
        {Scores.Energy, 1000},
    };

    [SerializeField]
    ScoresFloatDictionary CurrentValues = new ScoresFloatDictionary() {
        {Scores.Carbon, 0},
        {Scores.Biodiversity, 0},
        {Scores.Food, 0},
        {Scores.Energy, 0},
    };

    void Start()
    {
        Debug.Log("Scores start: " + CurrentValues);
    }

    void Update()
    {
    }

    public void Add(Scores score, float value)
    {
        CurrentValues[score] += value;
        Debug.Log("Add: " + score + "/" + value + " Scores: " + CurrentValues);
    }

    public void Remove(Scores score, float value)
    {
        CurrentValues[score] -= value;
        Debug.Log("Remove: " + score + "/" + value + " Scores: " + CurrentValues);
    }

    public float Get(Scores score) {
        return CurrentValues[score];
    }

    public void Set(Scores scores, float value) {
        CurrentValues[scores] = value;
    }

    public float CalculateProportion(Scores score)
    {
        return CurrentValues[score] / MaxValues[score];
    }
}
