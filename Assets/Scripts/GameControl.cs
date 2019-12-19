using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    private static GameObject player1, player2;
    public static int diceSideThrown = 0;
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;
    public static bool gameOver = false;
    [SerializeField]
    List<Message> messageList = new List<Message>();
    public int maxMessages = 25;
    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        player1.GetComponent<BaseCharacterClass>().moveAllowed = false;
        player2.GetComponent<BaseCharacterClass>().moveAllowed = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SendMessageToChat("You pressed the space key!");
            Debug.Log("Space");
        }
        if(player1.GetComponent<BaseCharacterClass>().level == 10)
        {
            gameOver = true;
        }
        if (player2.GetComponent<BaseCharacterClass>().level == 10)
        {
            gameOver = true;
        }
    }

    public static void MovePlayer(int playerToMove)
    {
        if (playerToMove == 1) {
            player2.GetComponent<BaseCharacterClass>().moveAllowed = false;
            player1.GetComponent<BaseCharacterClass>().moveAllowed = true; 
        } else {
            player1.GetComponent<BaseCharacterClass>().moveAllowed = false;
            player2.GetComponent<BaseCharacterClass>().moveAllowed = true;
        }
    }

    public void SendMessageToChat(string text)
    {
        if(messageList.Count >= maxMessages)
        {
            messageList.Remove(messageList[0]);
        }
        Message newMessage = new Message();
        newMessage.text = text;
        messageList.Add(newMessage);
    }
}
[System.Serializable]
public class Message
{
    public string text;
}
