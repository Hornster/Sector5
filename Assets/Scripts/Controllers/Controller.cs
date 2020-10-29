using Assets.Scripts.Common.Enums;
using Assets.Scripts.Logic.Data;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    private List<AvailableCommands> _myCommands;
    private CommandReceivers _whoAmI;
    public List<AvailableCommands> MyCommands { get => _myCommands; protected set => _myCommands = value; }
    public CommandReceivers WhoAmI { get => _whoAmI; protected set => _whoAmI = value; }

    protected virtual void Initialize()
    {

    }

    protected virtual void Execute(InteractiveObject obj, Command command)
    {
        obj.Use();
    }

    private void Start()
    {
        Initialize();
    }

    public void ReceiveCommand(List<Command> commands)
    {
        for (int i = 0; i < commands.Count; i++)
        {
            Command currentlyProcessedCommand = commands[i];
            CommandReceivers commandReceiver = currentlyProcessedCommand.CommandReceiver;
            int receiverID = currentlyProcessedCommand.ReceiverID;
            InteractiveObject interactiveObject = ObjectsManager.Instance.GetObject(receiverID, commandReceiver);


            if (currentlyProcessedCommand.CommandReceiver != WhoAmI)
            {
                continue;
            }

            if (MyCommands.Contains(currentlyProcessedCommand.IssuedCommand) == false)
            {
                continue;
            }

            if (interactiveObject == null)
            {
                //obiekt nie istnieje
                continue;
            }
            else
            {
                Execute(interactiveObject, currentlyProcessedCommand);
            }
        }
    }
}
