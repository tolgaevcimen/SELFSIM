﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncSimulator
{
    public abstract class _Node
    {
        /// <summary>
        /// Id of a node.
        /// </summary>
        public int Id { get; set; }

        public NodeHolder NodeHolder { get; set; }

        /// <summary>
        /// List of neighbours of this node. Empty initially.
        /// </summary>
        public Dictionary<int, _Node> Neighbours { get; set; }

        /// <summary>
        /// A thread safe queue for received messages.
        /// </summary>
        protected MessageQueue<Message> ReceiveQueue { get; set; }
        
        /// <summary>
        /// This is the hooker of the strategy pattern.
        /// </summary>
        public IVisualizer Visualizer { get; set; }

        public object ReceiveLock { get; set; }

        protected bool FirstTime { get; set; }

        public int MessageCount { get; set; }
        public int MoveCount { get; set; }

        /// <summary>
        /// As soon a node is created, the thread starts running.
        /// </summary>
        /// <param name="id"></param>
        public _Node(int id, NodeHolder nodeHolder)
        {
            Id = id;

            NodeHolder = nodeHolder;

            /// initialize listsse
            Neighbours = new Dictionary<int, _Node>();
            ReceiveQueue = new MessageQueue<Message>();
            ReceiveQueue.MessageAdded += ReceiveQueue_NewMessage;

            ReceiveLock = new object();

            FirstTime = true;
        }

        private void ReceiveQueue_NewMessage(object sender, EventArgs e)
        {
            if (ReceiveQueue.Count == 0) return;

            var m = ReceiveQueue.Dequeue();

            Trace.WriteLine(String.Format("Acquiring lock - {0}", m));
            lock (ReceiveLock)
            {
                Trace.WriteLine(String.Format("Acquiried lock - {0}", m));
                UserDefined_ReceiveMessageProcedure(m);
                Trace.WriteLine(String.Format("Releasing lock - {0}", m));
            }
            Trace.WriteLine(String.Format("Released lock - {0}", m));
        }

        public virtual bool Selected()
        {
            return false;
        }

        /// <summary>
        /// This method will be implemented in sub classes for algorithm details.
        /// </summary>
        /// <param name="m"></param>
        protected void UserDefined_ReceiveMessageProcedure(Message m)
        {
            MessageCount++;
            UpdateNeighbourInformation(m.Source);

            //if (Neighbours.Any(n => n.Value == null))
            //{
            //    foreach (var n in Neighbours)
            //    {
            //        Task.Run(() =>
            //        {
            //            NodeHolder.GetNodeById(n.Key).Underlying_Send(
            //        });
            //    }
            //}

            RunRules();
        }

        protected abstract void UpdateNeighbourInformation(_Node neighbour);

        protected abstract void RunRules();

        #region initiator

        /// <summary>
        /// This method will be implemented for single initiation strategies.
        /// </summary>
        /// <param name="root"></param>
        public abstract void UserDefined_SingleInitiatorProcedure(_Node root);

        #endregion

        #region Sender

        /// <summary>
        /// This method puts the given message to destinations ReceiveQueue
        /// </summary>
        /// <param name="m"></param>
        public void Underlying_Send(Message m)
        {
            var destination = NodeHolder.GetNodeById(m.DestinationId);
            if (destination == null)
            {
                throw new ArgumentNullException("Destination");
            }
            destination.ReceiveQueue.Enqueue(m);
        }

        #endregion
        
        public virtual bool IsValid()
        {
            return false;
        }
    }
}
