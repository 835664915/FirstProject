using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCommand : EventCommand
{

    [Inject]
    public IntegrationModel integrationModel { get; set; }

    public override void Execute()
    {
        GameData gameData = new GameData();
        gameData.playerIntergration = integrationModel.PlayerIntergration;

        gameData.computerRightIntergration = integrationModel.ComputerRightIntergration;
        gameData.computerLeftIntergration = integrationModel.ComputerLeftIntergration;
        dispatcher.Dispatch(ViewEvent.UPDATE_INTEGRATION, gameData);


    }


    }
