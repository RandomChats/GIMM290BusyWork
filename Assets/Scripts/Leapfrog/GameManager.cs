using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [SerializeField] private Text playerOneLabel, playerTwoLabel, victoryScreen;
    private int playerOnePoints, playerTwoPoints, winningScore;

    void Start() {
        winningScore = 4;
    }

    public int PlayerOnePoints {
        get {
            return playerOnePoints;
        } set {
            playerOnePoints = value;
            playerOneLabel.GetComponent<Text>().text = "Player 1 Score: " + playerOnePoints;
            if (playerOnePoints == winningScore) {
                PlayerVictory(1);
            }
        }
    }
    
    public int PlayerTwoPoints {
        get {
            return playerTwoPoints;
        } set {
            playerTwoPoints = value;
            playerTwoLabel.GetComponent<Text>().text = "Player 2 Score: " + playerTwoPoints;
            if (playerTwoPoints == winningScore) {
                PlayerVictory(2);
            }
        }
    }

    private void PlayerVictory(int playerNumber) {
        if (playerNumber == 1) {
            playerOneLabel.enabled = false;
            playerTwoLabel.enabled = false;
            victoryScreen.GetComponent<Text>().text = "Player 1 Wins!";
            victoryScreen.enabled = true;
        } else {
            playerOneLabel.enabled = false;
            playerTwoLabel.enabled = false;
            victoryScreen.GetComponent<Text>().text = "Player 2 Wins!";
            victoryScreen.enabled = true;
        }
    }

}
