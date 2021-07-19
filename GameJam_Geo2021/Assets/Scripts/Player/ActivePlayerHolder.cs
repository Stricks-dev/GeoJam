using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlayerHolder : MonoBehaviour
{
    public List<PlayerMove> players;
    [Space]

    public CameraController cameraLook;

    GameObject activePlayer; 
    private void Start()
    {
        foreach (var player in players)
        {

            if(player.info.id == 1)
            {
                player.gameObject.SetActive(true);
                activePlayer = player.gameObject;
            }
            else
            {
                player.gameObject.SetActive(false);
            }
            switch (player.info.playerType)
            {
                case PlayerInfo.PlayerType.Circle:
                    player.OnPlayerStop += OnCircleStop;
                    break;
                case PlayerInfo.PlayerType.Rhombus:
                    player.OnPlayerStop += OnRhombusStop;
                    break;
                case PlayerInfo.PlayerType.Star:
                    player.OnPlayerStop += OnStarStop;
                    break;
                case PlayerInfo.PlayerType.Triangle:
                    player.OnPlayerStop += OnTriangleStop;
                    break;
                case PlayerInfo.PlayerType.Trapezoid:
                    player.OnPlayerStop += OnTrapezoidStop;
                    break;
                default:
                    break;
            }
        }
        if(cameraLook != null)
        {
            cameraLook.player = activePlayer;
        }
    }
    private void Update()
    {
        cameraLook.player = activePlayer;
    }
    void OnCircleStop()
    {
        //Setting active player
        activePlayer = players[1].gameObject;
        //Enabling
        players[1].gameObject.SetActive(true);
        //Position Track
        players[1].transform.position = players[0].lastRecordPos;
        players[0].lastRecordPos = Vector3.zero;
        //Disable old component
        players[0].gameObject.SetActive(false);
    }
    void OnRhombusStop()
    {
        //Setting active player
        activePlayer = players[2].gameObject;
        //Enabling
        players[2].gameObject.SetActive(true);
        //Position Track
        players[2].transform.position = players[1].lastRecordPos;
        players[1].lastRecordPos = Vector3.zero;
        //Disable old component
        players[1].gameObject.SetActive(false);
    }
    void OnStarStop()
    {
        //Setting active player
        activePlayer = players[3].gameObject;
        //Enabling
        players[3].gameObject.SetActive(true);
        //Position Track
        players[3].transform.position = players[2].lastRecordPos;
        players[2].lastRecordPos = Vector3.zero;
        //Disable old component
        players[2].gameObject.SetActive(false);
    }
    void OnTriangleStop()
    {
        //Setting active player
        activePlayer = players[0].gameObject;
        //Enabling
        players[0].gameObject.SetActive(true);
        //Position Track
        players[0].transform.position = players[3].lastRecordPos;
        players[3].lastRecordPos = Vector3.zero;
        //Disable old component
        players[3].gameObject.SetActive(false);
    }
    void OnTrapezoidStop()
    {

    }
}
