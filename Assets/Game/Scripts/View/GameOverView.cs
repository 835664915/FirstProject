using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverView : View
{


    //------全局事件
  [Inject(ContextKeys.CONTEXT_DISPATCHER)]
   public IEventDispatcher dispatcher { get; set; }
    /// <summary>
    /// 点击重新开始
    /// </summary>
    public void OnRestartClick()
    {
        dispatcher.Dispatch(ViewEvent.RESTART_GAME);

        Destroy(gameObject);

    }
  
    public void OnExitClick()
    {
        Application.Quit();

    }

	
}
