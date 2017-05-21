﻿using AsyncSimulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FloodSTNode
{
    public class _FloodSTNode : _Node
    {
        public _Node Parent { get; set; }

        public _FloodSTNode ( int id )
            : base(id)
        {

        }

        protected override void UserDefined_ReceiveMessageProcedure ( Message receivedMessage )
        {
            var now = DateTime.Now;

            Visualizer.Log("node{0} received:( {1} )", this.Id, receivedMessage, receivedMessage.Source.Id, now.Minute + ":" + now.Second);
            Thread.Sleep(1000);

            if ( Parent != null )
            {
                Visualizer.Log("---I'm {0}, I already have a parent: {1}", Id, Parent.Id);
                this.Stop();
                return;
            }
            Parent = receivedMessage.Source;

            foreach ( var neighbour in Neighbours )
            {
                var m = new Message
                {
                    Data = this.Id + "-" + neighbour.Id,
                    Source = this,
                    Destination = neighbour,
                    MessageType = 0
                };
                this.Underlying_Send(m);
            }

            Visualizer.VisualizeMessage(receivedMessage);

            Running = false;
            Visualizer.Log("receiver {0} done", this.Id);
        }

        public override void UserDefined_SingleInitiatorProcedure ( _Node root )
        {
            this.Underlying_Send(new AsyncSimulator.Message
            {
                Data = this.Id + "-" + root.Id,
                Source = this,
                Destination = root,
                MessageType = 0
            });
        }

        public override void UserDefined_ConcurrentInitiatorProcedure ( List<_Node> allNodes )
        {
            throw new NotImplementedException();
        }
    }
}