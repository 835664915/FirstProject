using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using System;

public class GameOverMediator : EventMediator
{
    [Inject]
  public GameOverView gameOverView { get; set; }
    public override void OnRegister()
    {
        dispatcher.AddListener(ViewEvent.SHOW_INTERGRATION, ondsajdias);
    }

    private void ondsajdias(IEvent payload)
    {
        print( 6526565565656565);



    }
    public override void OnRemove()
    {
        dispatcher.RemoveListener(ViewEvent.SHOW_INTERGRATION, ondsajdias);
    }


}
