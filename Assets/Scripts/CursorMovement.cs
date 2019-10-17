using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class CursorMovement : MonoBehaviour
{
    [System.NonSerialized]
    public int playerId;

    private float speed = 20;

    private Player player; // The Rewired Player

    void Start()
    {
        Debug.Log("reqired pid: " + playerId);
        player = ReInput.players.GetPlayer(playerId);
    }

    void Update()
    {

        float x = player.GetAxis("Move Horizontal");
        float y = player.GetAxis("Move Vertical");

        transform.position += new Vector3(x, y, 0) * Time.deltaTime * speed;

        Vector3 worldSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -worldSize.x, worldSize.x),
            Mathf.Clamp(transform.position.y, -worldSize.y, worldSize.y),
            transform.position.z);


    }
}
