﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AsyncSimulator;

namespace VisualInterface.GraphGenerator
{
    class TripletTreeGraphGenerator : IGraphGenerator
    {
        public void Generate(int nodeCount, Presenter parentForm, Panel drawing_panel, NodeHolder nodeHolder, EdgeHolder edgeHolder, string SelectedAlgorithm)
        {
            var arg = new PaintEventArgs(drawing_panel.CreateGraphics(), new Rectangle());

            var queue = new Queue<int>();

            var totalHeight = 0;

            if (nodeCount == 1)
                totalHeight = 2;
            else if (nodeCount == 2 || nodeCount == 3 || nodeCount == 4)
                totalHeight = 2;
            else
                totalHeight = (int)Math.Floor(Math.Log(nodeCount, 3)) + 1;

            var verticalInterval = (int)((drawing_panel.Height - 80) / (totalHeight - 1));

            for (int i = 0; i < nodeCount; i++)
            {
                var currentDepth = (int)Math.Floor(Math.Log(i + 1, 3));

                var horizontalInterval = (int)((drawing_panel.Width) / (Math.Pow(3, currentDepth) + 1));

                var currentIndex = (int)(i - (Math.Pow(3, currentDepth) - 1) + 1);

                Console.WriteLine("i: {0}, depth: {1}, currentIndex: {2}", i, currentDepth, currentIndex);

                var p = new Point((currentIndex) * horizontalInterval, (currentDepth) * verticalInterval + 40);

                if (!nodeHolder.AnyIntersecting(p))
                {
                    var node = NodeFactory.Create(SelectedAlgorithm, nodeHolder.NodeCount, new NodeVisualizer(arg, p.X, p.Y, nodeHolder.NodeCount, parentForm));

                    nodeHolder.AddNode(node);
                }
                else
                {
                    throw new Exception("Reached to screen limits");
                }
            };

            for (int i = 1; i < nodeCount; i++)
            {
                queue.Enqueue(i);
            }

            for (int i = 0; i < nodeCount; i++)
            {
                var parent = nodeHolder.GetNodeAt(i);

                for (int j = 0; j < 3; j++)
                {
                    if (!queue.Any()) break;

                    var firstChildId = queue.Dequeue();
                    var child = nodeHolder.GetNodeAt(firstChildId);
                    
                    edgeHolder.AddEgde(new VisualEdge(arg, parent, child));
                }

            }
        }

        PointF PointOnCircle(float radius, float angleInDegrees, PointF origin)
        {
            // Convert from degrees to radians via multiplication by PI/180        
            float x = (float)(radius * Math.Cos(angleInDegrees * Math.PI / 180F)) + origin.X;
            float y = (float)(radius * Math.Sin(angleInDegrees * Math.PI / 180F)) + origin.Y;

            return new PointF(x, y);
        }
    }
}
