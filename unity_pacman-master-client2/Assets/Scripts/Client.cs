using System;
using UnityEngine;
using UnityEngine.Networking;


public class Client : MonoBehaviour
{
    int port = 7777;
    string ip = "localhost";
    public GameObject Pacman;

    // The id we use to identify our messages and register the handler
    short messageID = 1003;
    short messageID2 = 1001;

    // The network client
    NetworkClient client;
    public float[] data0 = new float[9];
    public float[] Answer= new float[14];
    void Start()
    {
        CreateClient(); 
    }

    public Client()
    {
        Application.runInBackground = true;
        CreateClient();
    }

    void CreateClient()
    {
        var config = new ConnectionConfig();

        // Config the Channels we will use
        config.AddChannel(QosType.ReliableFragmented);
        config.AddChannel(QosType.UnreliableFragmented);

        // Create the client ant attach the configuration
        client = new NetworkClient();
        client.Configure(config, 1);

        // Register the handlers for the different network messages
        RegisterHandlers();

        // Connect to the server
        client.Connect(ip, port);
    }

    // Register the handlers for the different message types
    void RegisterHandlers()
    {

        // Unity have different Messages types defined in MsgType
        client.RegisterHandler(messageID, OnMessageReceived);
        client.RegisterHandler(MsgType.Connect, OnConnected);
        client.RegisterHandler(MsgType.Disconnect, OnDisconnected);
    }


    void FixedUpdate()
    {

        // Do stuff when connected to the server
        MyNetworkMessage messageContainer = new MyNetworkMessage();
        data0= Pacman.GetComponent<PacmanMove>().TransfMessage;
        messageContainer.data = data0;
        // Say hi to the server when connected
        client.Send(messageID, messageContainer);


        //Прием сообщения от сервера
        // Our message use his own message type.

        client.RegisterHandler(messageID2, OnMessageReceived);


    }

    void OnConnected(NetworkMessage message)
    {
        // Do stuff when connected to the server

        MyNetworkMessage messageContainer = new MyNetworkMessage();
        messageContainer.message = "Hello server!";

        // Say hi to the server when connected
        client.Send(messageID, messageContainer);
    }

    void OnDisconnected(NetworkMessage message)
    {
        // Do stuff when disconnected to the server
    }

    // Message received from the server
    void OnMessageReceived(NetworkMessage netMessage)
    {
        // You can send any object that inherence from MessageBase
        // The client and server can be on different projects, as long as the MyNetworkMessage or the class you are using have the same implementation on both projects
        // The first thing we do is deserialize the message to our custom type
        var objectMessage = netMessage.ReadMessage<MyNetworkMessage>();
        Answer = objectMessage.dataAns;
        Debug.Log("Message received: " + objectMessage.message);
    }





    //Artem


}