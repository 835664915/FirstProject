using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassCardCommand : EventCommand
{
    [Inject]
    public RoundModel roumdModel { get; set; }

    public override void Execute()
    {
        roumdModel.Trun();


    }

}
