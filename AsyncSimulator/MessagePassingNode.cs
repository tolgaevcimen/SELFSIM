﻿using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncSimulator
{
    public abstract class MessagePassingNode
    {
        /// <summary>
        /// Id of a node.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// List of neighbours of this node. Empty initially.
        /// </summary>
        public List<MessagePassingNode> Neighbours { get; set; }

        /// <summary>
        /// A thread safe queue for received messages.
        /// </summary>
        protected ConcurrentQueue<MessageEx> ReceiveQueue { get; set; }

        /// <summary>
        /// Flag for running state of the underlying thread.
        /// </summary>
        protected bool Running { get; set; }

        /// <summary>
        /// This is the hooker of the strategy pattern.
        /// </summary>
        public IVisualizer Visualizer { get; set; }

        /// <summary>
        /// As soon a node is created, the thread starts running.
        /// </summary>
        /// <param name="id"></param>
        public MessagePassingNode( int id )
        {
            Id = id;

            /// initialize lists
            Neighbours = new List<MessagePassingNode>();
            ReceiveQueue = new ConcurrentQueue<MessageEx>();

            /// initiate the thread. Magic occurs here as this call create a thread based running.
            Task.Run(() => Receive());
        }

        public virtual bool Selected()
        {
            return false;
        }

        /// <summary>
        /// This method will be implemented in sub classes for algorithm details.
        /// </summary>
        /// <param name="m"></param>
        protected abstract void UserDefined_ReceiveMessageProcedure (MessageEx m);

        #region initiator

        /// <summary>
        /// This method will be implemented for single initiation strategies.
        /// </summary>
        /// <param name="root"></param>
        public abstract void UserDefined_SingleInitiatorProcedure ( _Node root );

        /// <summary>
        /// This method will be implemented for concurrent initiation strategies.
        /// </summary>
        /// <param name="allNodes"></param>
        public abstract void UserDefined_ConcurrentInitiatorProcedure ( List<_Node> allNodes );

        #endregion

        #region Sender

        /// <summary>
        /// This method puts the given message to destinations ReceiveQueue
        /// </summary>
        /// <param name="m"></param>
        public void Underlying_Send ( MessageEx m )
        {
            m.Destination.ReceiveQueue.Enqueue(m);
        }

        #endregion

        #region Receiver

        /// <summary>
        /// The implementation of the mechanism running in thread.
        /// </summary>
        void Receive ()
        {
            while ( true )
            {
                if ( Running )
                {
                    MessageEx incomingMessage;
                    while ( !ReceiveQueue.TryDequeue(out incomingMessage) ) { Thread.Sleep(50); }
                    
                    UserDefined_ReceiveMessageProcedure(incomingMessage);
                }
                else
                {
                    Thread.Sleep(50);
                }
            }
        }
        
        #endregion

        /// <summary>
        /// Starts the node
        /// </summary>
        public void Start()
        {
            Running = true;
        }

        /// <summary>
        /// Stops the node
        /// </summary>
        public void Stop()
        {
            Running = false;
        }
    }
}
