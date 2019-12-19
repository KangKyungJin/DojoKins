using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    private int whosTurn = 1;
    private bool coroutineAllowed = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        if (!GameControl.gameOver && coroutineAllowed)
        {
            System.Console.WriteLine("Is this working?");
            StartCoroutine("TurnChange");
        }
    }
    private void TurnChange()
    {
        coroutineAllowed = false;
        if (whosTurn == 1)
        {
            GameControl.MovePlayer(1);
        }
        else if (whosTurn == -1)
        {
            GameControl.MovePlayer(2);
        }
        whosTurn *= -1;
        coroutineAllowed = true;
    }
}
