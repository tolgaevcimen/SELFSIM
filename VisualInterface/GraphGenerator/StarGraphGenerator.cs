﻿using System;
using System.Drawing;
using System.Windows.Forms;
using AsyncSimulator;
using NodeGenerator;

namespace VisualInterface.GraphGenerator
{
    class StarGraphGenerator : AbstractGraphGenerator
    {
        public StarGraphGenerator(Presenter parentForm, Panel drawing_panel) : base(parentForm, drawing_panel)
        {
        }

        public override void Generate(int nodeCount, NodeHolder nodeHolder, EdgeHolder edgeHolder, string SelectedAlgorithm)
        {
            var arg = new PaintEventArgs(Drawing_panel.CreateGraphics(), new Rectangle());

            var radius = (Math.Min(Drawing_panel.Height, Drawing_panel.Width) - 80) / 2;
            var origin = new Point(Drawing_panel.Width / 2, Drawing_panel.Height / 2);

            for (int i = 0; i < nodeCount; i++)
            {
                var angle = 360 / (float)(nodeCount - 1) * i;

                var p = i == 0 ? origin : PointOnCircle(radius, angle, origin);

                if (!nodeHolder.AnyIntersecting(p))
                {
                    var node = NodeFactory.Create(SelectedAlgorithm, nodeHolder.NodeCount, new WinformsNodeVisualiser(arg, p.X, p.Y, nodeHolder.NodeCount, ParentForm), ParentForm.cb_selfStab.Checked, nodeHolder);

                    nodeHolder.AddNode(node);
                }
                else
                {
                    i--;
                }
            };

            for (int i = 0; i < nodeCount; i++)
            {
                var node1 = nodeHolder.GetNodeAt(0);
                var node2 = nodeHolder.GetNodeAt(i);

                edgeHolder.AddEgde(new WinformsEdge(arg, node1, node2));
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
