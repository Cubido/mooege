﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using D3Sharp.Net.Game.Message.Definitions.ACD;
using D3Sharp.Net.Game.Message.Definitions.Misc;
using D3Sharp.Core.Toons;

namespace D3Sharp.Core.Actors
{
    public class Actor
    {
        public int ID;
        public int snoID;
        public float PosX, PosY, PosZ;
        public ACDEnterKnownMessage RevealMessage;

        public void Reveal(Toon t)
        {
            if (RevealMessage != null) t.Owner.LoggedInBNetClient.InGameClient.SendMessage(RevealMessage);
            t.Owner.LoggedInBNetClient.InGameClient.FlushOutgoingBuffer();
        }

        public void Destroy(Toon t)
        {
            if (RevealMessage != null)
            {
                t.Owner.LoggedInBNetClient.InGameClient.SendMessage(new ANNDataMessage() { Id=0x3c, Field0=ID, });
                t.Owner.LoggedInBNetClient.InGameClient.FlushOutgoingBuffer();
            }
        }
    }
}
