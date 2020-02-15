﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLeague : MonoBehaviour
{
    int score0, score1;
    public GameObject ballFab;
    GameObject ballObject;
    Rigidbody ball;
    Material ballShader;
    [SerializeField]
    float force = 10f;
    [SerializeField]
    float forceMod = 1f;
    public enum ForceDirection
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
        VERT_UP,
        VERT_DOWN
    }
    Queue<ForceDirection> forces = new Queue<ForceDirection>();
    Queue<Vector4> colors = new Queue<Vector4>();
    Queue<int> forceChanges = new Queue<int>();
    // Start is called before the first frame update
    void Start()
    {
        score0 = 0;
        score1 = 0;
        resetBall();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Remove following
        getKeyboardInput();

        //get all events and enqueue
        GET_THE_FUCKING_MESSAGES_FROM_THE_PLUGIN_AND_ADD_THEM_TO_THE_RIGHT_QUEUE();

        getAndApplyForces();
        applyColors();
        applyForceChange();
        // TODO: Do we need to sync clients?
    }
    void getKeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
            forces.Enqueue(ForceDirection.UP);
        if (Input.GetKeyDown(KeyCode.S))
            forces.Enqueue(ForceDirection.DOWN);
        if (Input.GetKeyDown(KeyCode.A))
            forces.Enqueue(ForceDirection.LEFT);
        if (Input.GetKeyDown(KeyCode.D))
            forces.Enqueue(ForceDirection.RIGHT);
        if (Input.GetKeyDown(KeyCode.E))
            forces.Enqueue(ForceDirection.VERT_UP);
        if (Input.GetKeyDown(KeyCode.Q))
            forces.Enqueue(ForceDirection.VERT_DOWN);
    }
    void GET_THE_FUCKING_MESSAGES_FROM_THE_PLUGIN_AND_ADD_THEM_TO_THE_RIGHT_QUEUE()
    {
        // TODO: for each message, queue force in forces.
        // TODO: for each message queue color in colors
        // TODO: for each message queue speed change in speeds.
        // TODO: Chat messages.

    }
    public void resetBall()
    {
        Destroy(ballObject);
        ballObject = Instantiate(ballFab);
        ball = ballObject.GetComponent<Rigidbody>();
        ballShader = ballObject.GetComponent<Material>();

    }
    public void addScore(int teamNum)
    {
        if (teamNum == 0)
        {
            score0 += 1;
        }
        else if (teamNum == 1)
        {
            score1 += 1;
        }
        else
        {
            Debug.LogError("Invalid team Num: " + teamNum);
        }
    }
    void applyForceChange()
    {
        for(int i=forceChanges.Count; i >0; i--)
        {
            force += forceMod * forceChanges.Dequeue();
        }
    }
    void applyColors()
    {
        for(int i = colors.Count; i > 0; i--)
        {
            Vector4 color = ballShader.color;
            color += colors.Dequeue();
            ballShader.color = color / 2f;
        }
    }
    void getAndApplyForces()
    {
        for(int i = forces.Count; i >0; i--)
        {
            applyForce(forces.Dequeue());
        }
    }
    void applyForce(ForceDirection forceDirection)
    {
    switch(forceDirection)
            {
        case ForceDirection.DOWN:
                ball.AddForce(new Vector3(0,0,-1) * force, ForceMode.Impulse);
            break;
        case ForceDirection.UP:
                ball.AddForce(new Vector3(0, 0, 1) * force, ForceMode.Impulse);
            break;
            case ForceDirection.RIGHT:
                ball.AddForce(Vector3.right * force, ForceMode.Impulse);
            break;
            case ForceDirection.LEFT:
                ball.AddForce(-Vector3.right * force, ForceMode.Impulse);
            break;
            case ForceDirection.VERT_DOWN:
                ball.AddForce(-Vector3.up * force, ForceMode.Impulse);
            break;
            case ForceDirection.VERT_UP:
                ball.AddForce(Vector3.up * force, ForceMode.Impulse);
            break;
        }
    }
}