﻿using AsyncSimulator;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GoddardMDSNode
{
    public class GoddardNode : _Node
    {
        public int x { get; set; }
        public int c { get; set; }

        bool FirstTime { get; set; }

        object Lock { get; set; }

        public GoddardNode(int id, InitialState initialState = InitialState.AllWait, Random randomizer = null) : base(id)
        {
            x = GetState(initialState, randomizer);
            Lock = new object();
            FirstTime = true;
        }

        public void RunRules()
        {
            Thread.Sleep(50);

            var realNeigborCount = GiveNeighborCount();

            if (x == 0 && c != realNeigborCount)
            {
                Visualizer.Log("D1: I'm {0}.Rectifying neighbor count: {1}. ", Id, realNeigborCount);

                c = realNeigborCount;
                PokeNeighbors();
            }
            else if (realNeigborCount == 0 && x == 0 && c == 0 && !Neighbours.Any(n => n.Id < Id && ((GoddardNode)n).c == 0))
            {
                Visualizer.Log("D2: I'm {0}. Entering set. ", Id);

                x = 1;
                Visualizer.Draw(true);
                PokeNeighbors();
            }
            else if (realNeigborCount > 0 && x == 1 && Neighbours.
                Where(n => ((GoddardNode)n).x == 0).All(n => ((GoddardNode)n).c == 2))
            {
                Visualizer.Log("D3: I'm {0}. Leaving set. ", Id);

                x = 0;
                c = realNeigborCount == 1 ? 1 : 2;
                Visualizer.Draw(false);
                PokeNeighbors();
            }
            else
            {
                MoveCount--;
                if (FirstTime)
                {
                    Visualizer.Log("D-: I'm {0}. Forwarding message. ", Id);
                    FirstTime = false;
                    PokeNeighbors();
                }
            }
        }

        int GiveNeighborCount()
        {
            if (Neighbours.All(n => ((GoddardNode)n).x == 0)) return 0;

            if (Neighbours.Count(n => ((GoddardNode)n).x == 1) == 1) return 1;

            return 2;
        }

        void PokeNeighbors()
        {
            foreach (var neighbor in Neighbours)
            {
                Task.Run(() =>
                {
                    Underlying_Send(new Message
                    {
                        Source = this,
                        Destination = neighbor
                    });
                });
            }

            Task.Run(() => RunRules());
        }

        public override bool Selected()
        {
            return base.Selected() || x == 1;
        }

        protected override void UserDefined_ReceiveMessageProcedure(Message m)
        {
            base.UserDefined_ReceiveMessageProcedure(null);
            RunRules();
        }

        public override void UserDefined_SingleInitiatorProcedure(_Node root)
        {
            var initialNode = (GoddardNode)root;

            initialNode.FirstTime = true;
            initialNode.RunRules();
        }

        public override bool IsValid()
        {
            var realNeigborCount = GiveNeighborCount();
            if (x == 0 && c != realNeigborCount)
            {
                return false;
            }
            else if (realNeigborCount == 0 && x == 0 && c == 0 && !Neighbours.Any(n => n.Id < Id && ((GoddardNode)n).c == 0))
            {
                return false;
            }
            else if (realNeigborCount > 0 && x == 1 && Neighbours.Where(n => ((GoddardNode)n).x == 0).All(n => ((GoddardNode)n).c == 2))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        int GetState(InitialState _is, Random randomizer)
        {
            switch (_is)
            {
                case InitialState.AllWait:
                    return 0;
                case InitialState.AllIn:
                    return 1;
                case InitialState.Random:
                    {
                        var randIndex = randomizer.Next(0, 2);

                        return randIndex;
                    }
                default: return 0;
            }
        }
    }
}
