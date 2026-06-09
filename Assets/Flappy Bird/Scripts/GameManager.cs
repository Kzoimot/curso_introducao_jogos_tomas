using NUnit.Framework.Constraints;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Referência do Canvas UI do menu pausa")]
    GameObject[] Available_Levels;

    [SerializeField]
    [Tooltip("How many tiles in each level.")]
    float LevelSize;

    [SerializeField]
    [Tooltip("Game speed")]
    float speed;

    List<Transform> Current_Levels;

    void Start()
    {
        Current_Levels = new List<Transform>();
        Play();
    }

    void Update()
    {
        UpdateMap();
    }

    void UpdateMap()
    {
        // for each transform in Current_Levels variable
        foreach (Transform level in Current_Levels)
        {
            level.position += (Vector3.left * speed * Time.deltaTime);
        }

        if (Current_Levels[Current_Levels.Count-1].position.x <= 0)
        {
            Transform Remove_Level = Current_Levels[0];
            Current_Levels.Remove(Remove_Level);
            GameObject.Destroy(Remove_Level.gameObject);
            SpawnNewLevel();
        }
    }

    void SpawnNewLevel()
    {
        int Random_Level = Random.Range(0, Available_Levels.Length);

        GameObject New_Level = GameObject.Instantiate(Available_Levels[Random_Level], Current_Levels[0].transform.position + Vector3.right * LevelSize, Quaternion.identity, transform);
        Current_Levels.Add(New_Level.transform);
    }

    public void Play()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        Current_Levels.Clear();

        // GetComponent<Transform>() is the same of transform
        GameObject New_Level = GameObject.Instantiate(Available_Levels[0], Vector3.zero, Quaternion.identity, transform);
        Current_Levels.Add(New_Level.transform);
        SpawnNewLevel();
    }
}