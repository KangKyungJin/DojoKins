using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterClass : MonoBehaviour{

    private string characterClassName;
    private string characterClassDescription;
    private string characterGender;
    [SerializeField]
    public int level;
    private int maxLevel = 10;
    private int strength;
    private bool death;
    public Transform[] waypoints;
    [SerializeField]
    public float moveSpeed = 100f;
    [HideInInspector]
    public int waypointIndex = 0;
    public bool moveAllowed = false;
    public bool wonCombat = false;

    public string CharacterClassName
    {
        get { return characterClassName; }
        set { characterClassName = value; }
    }
    public string CharacterClassDescription
    {
        get { return characterClassDescription; }
        set { characterClassDescription = value; }
    }
    public string CharacterGender
    {
        get { return characterGender; }
        set { characterGender = value; }
    }
    public int Strength
    {
        get { return strength; }
        set { strength = value; }
    }
    public int Level
    {
        get { return level; }
        set { level = value; }
    }
    public bool Death
    {
        get { return false; }
        set { death = value; }
    }
    
    private void Start()
    {
        this.Strength = level;
        this.level = 1;
        transform.position = waypoints[waypointIndex].transform.position;
    }

    private void Update()
    {
        if (moveAllowed)
        {
            if (Input.GetKeyDown("space"))
            {
                if(this.level < 10)
                    this.level += 1;
            }
            Move();
        }
    }

    private void Move()
    {
        if (waypointIndex < waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex + (level - 1)].transform.position, moveSpeed * Time.deltaTime);
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += (level - 1);
            }
        }
    }

}
