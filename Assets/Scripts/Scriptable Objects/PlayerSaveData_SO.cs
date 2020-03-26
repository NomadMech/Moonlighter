using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Save Data", menuName = "Character/Data", order = 1)]
public class PlayerSaveData_SO : ScriptableObject
{
    [Header("Stats")]

    [SerializeField]
    int currentHealth;

    [Header("Leveling")]
    [SerializeField]
    int currentLevel = 1;

    [SerializeField]
    int maxLevel = 30;

    [SerializeField]
    int basisPoints = 200;

    [SerializeField]
    int pointsTillNextLevel;


    [SerializeField]
    float levelbuff = 0.1f;

    public float LevelMultiplier
    {
        get { return 1 + (currentLevel - 1) * levelbuff; }
    }

    public int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }

    public void AggrergateAttackPoints(int points)
    {
        pointsTillNextLevel -= points;

        if(pointsTillNextLevel <= 0)
        {
            currentLevel = Mathf.Clamp(currentLevel + 1,0, maxLevel);
            pointsTillNextLevel += (int)(basisPoints * LevelMultiplier);

            Debug.Log("LEVEL UP! New Level: " + currentLevel);
        }
    }

    private void OnEnable()
    {
        if(pointsTillNextLevel == 0)
        {
            pointsTillNextLevel += (int)(basisPoints * LevelMultiplier);
        }
    }
}
