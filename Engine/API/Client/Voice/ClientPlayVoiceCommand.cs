﻿using Engine.Model.Client;
using Engine.Model.Common.Entities;
using System;
using System.Security;

namespace Engine.Api.Client
{
  [SecurityCritical]
  class ClientPlayVoiceCommand :
    ClientCommand<ClientPlayVoiceCommand.MessageContent>
  {
    public static long CommandId = (long)ClientCommandId.PlayVoice;

    public override long Id
    {
      [SecuritySafeCritical]
      get { return CommandId; }
    }

    protected override bool IsPeerCommand
    {
      [SecuritySafeCritical]
      get { return true; }
    }

    [SecuritySafeCritical]
    protected override void OnRun(MessageContent content, ClientCommandArgs args)
    {
      using (var client = ClientModel.Get())
      {
        var user = client.Chat.GetUser(args.PeerConnectionId);
        if (user.IsVoiceActive())
          ClientModel.Player.Enqueue(args.PeerConnectionId, content.Number, content.Pack);
      }
    }

    [Serializable]
    public class MessageContent
    {
      private SoundPack _pack;
      private long _number;

      public SoundPack Pack
      {
        get { return _pack; }
        set { _pack = value; }
      }

      public long Number
      {
        get { return _number; }
        set { _number = value; }
      }
    }
  }
}
