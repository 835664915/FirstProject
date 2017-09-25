using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 算个中介，让view模块与外界访问
/// </summary>
public class StartMediator : EventMediator
{
    [Inject]
    public StartView startView { get; set; }


    public override void OnRegister()
    {

        startView.Init();

        startView.dispatcher.AddListener(ViewEvent.CHANGE_MULTIPLE, onViewClick);
    }

    public override void OnRemove()
    {
        startView.ViewDestroy();
        startView.dispatcher.RemoveListener(ViewEvent.CHANGE_MULTIPLE, onViewClick);
    }

    /// <summary>
    /// view被点击
    /// </summary>
    /// <param name="evt"></param>
    private void onViewClick(IEvent evt)
    {
        int multiple = (int)evt.data;

        //获取的倍数发送出去

        dispatcher.Dispatch(CommandEvent.ChangeMulitiple, multiple);

    }




  
}
