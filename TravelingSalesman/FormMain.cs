using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace TravelingSalesman
{
    public partial class FormMain : Form
    {
        // runtime variables
        private int nodeCount = 10;
        private Node[] nodes = new Node[0];
        private int nodeStart = 0;
        private int nodeEnd = 0;
        private int[] shortestPath = new int[0];
        private double shortestDistance = 0.0;
        private int[] levelProgress = new int[3];

        // constants
        private const int nodeRadius = 5;
        private const int nodeDiameter = (nodeRadius * 2) + 1;
        private static Pen pePath = new Pen(Color.Black);
        private static Pen peNode = new Pen(Color.Blue, 1.0f);
        private static Pen peNodeStart = new Pen(Color.Green, 2.0f);
        private static Pen peNodeEnd = new Pen(Color.Red, 2.0f);
        private static Brush brBackground = new SolidBrush(Color.White);

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            textBoxNodeCount.Text = nodeCount.ToString();
            comboBoxAlgorithm.SelectedIndex = 0;
        }

        private void textBoxNodeCount_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(textBoxNodeCount.Text, out nodeCount);
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Restart();

            if (comboBoxAlgorithm.SelectedIndex == 0)
                RunOneByOne();

            sw.Stop();
            labelProgress.Text = "Time: " + (sw.ElapsedMilliseconds / 1000.0).ToString("0.###") + " sec";
        }

        private void ToggleControls(bool enable)
        {
            comboBoxAlgorithm.Enabled = enable;
            textBoxNodeCount.Enabled = enable;
            buttonRun.Enabled = enable;
        }

        private void GenerateNodes()
        {
            nodes = new Node[nodeCount];
            Random rand = new Random();

            for (int i = 0; i < nodeCount; i++)
            {
                nodes[i] = new Node(GetCenteredDouble(rand), GetCenteredDouble(rand));
            }

            nodeStart = rand.Next(nodeCount);
            do
            {
                nodeEnd = rand.Next(nodeCount);
            }
            while (nodeEnd == nodeStart);
        }

        private double GetCenteredDouble(Random rand)
        {
            double d = (rand.NextDouble() * 2.0) - 1.0;

            bool neg = (d < 0);
            if (neg)
                d *= -1;

            d = Math.Pow(d, 1.5);

            if (neg)
                d *= -1;

            d += 1.0;
            d /= 2.0;

            return d;
        }

        private void RenderPath()
        {
            Rectangle rectPathBox = new Rectangle(0, 0, pictureBoxPath.Width, pictureBoxPath.Height);

            using (Graphics g = pictureBoxPath.CreateGraphics())
            {
                // background
                g.FillRectangle(brBackground, rectPathBox);

                // nodes
                for (int i = 0; i < nodes.Length; i++)
                {
                    if (i == nodeStart)
                        g.DrawEllipse(peNodeStart, NodeToRect(i, rectPathBox));
                    else if (i == nodeEnd)
                        g.DrawEllipse(peNodeEnd, NodeToRect(i, rectPathBox));
                    else
                        g.DrawEllipse(peNode, NodeToRect(i, rectPathBox));
                }

                // path
                if (shortestPath.Length > 0)
                {
                    Point pLineOrigin = NodeToPoint(shortestPath[0], rectPathBox);
                    for (int i = 1; i < shortestPath.Length; i++)
                    {
                        Point pLineEnd = NodeToPoint(shortestPath[i], rectPathBox);
                        g.DrawLine(pePath, pLineOrigin, pLineEnd);
                        pLineOrigin = pLineEnd;
                    }
                }
            }

            Application.DoEvents();
        }

        private Point NodeToPoint(int node, Rectangle rect)
        {
            const int paddingPosition = nodeRadius + 1;
            const int paddingSize = paddingPosition * 2 + 3;

            double x = (nodes[node].X * (rect.Width - paddingSize)) + paddingPosition;
            double y = (nodes[node].Y * (rect.Height - paddingSize)) + paddingPosition;

            return new Point(rect.X + (int)x, rect.Y + (int)y);
        }

        private Rectangle NodeToRect(int node, Rectangle rect)
        {
            const int paddingPosition = nodeRadius + 1;
            const int paddingSize = paddingPosition * 2 + 3;

            double x = (nodes[node].X * (rect.Width - paddingSize)) + paddingPosition;
            double y = (nodes[node].Y * (rect.Height - paddingSize)) + paddingPosition;

            return new Rectangle(rect.X + (int)x - nodeRadius, rect.Y + (int)y - nodeRadius, nodeDiameter, nodeDiameter);
        }

        private double GetDistance(int[] path)
        {
            double dist = 0.0;

            for (int i = 0; i < path.Length - 1; i++)
            {
                dist += Math.Sqrt(Math.Pow(nodes[path[i]].X - nodes[path[i + 1]].X, 2.0) + Math.Pow(nodes[path[i]].Y - nodes[path[i + 1]].Y, 2.0));
            }

            return dist;
        }

        private void RunOneByOne()
        {
            ToggleControls(false);

            GenerateNodes();
            shortestPath = new int[nodes.Length];
            shortestDistance = double.MaxValue;

            RenderPath();

            bool[] nodeVisited = new bool[nodes.Length];
            int[] path = new int[nodes.Length];

            nodeVisited[nodeStart] = true;
            nodeVisited[nodeEnd] = true;
            path[0] = nodeStart;
            path[path.Length - 1] = nodeEnd;

            SolveOneByOne(ref nodeVisited, ref path, 1);
            labelProgress.Text = "Progress: Done!";

            ToggleControls(true);
        }

        private void SolveOneByOne(ref bool[] nodeVisited, ref int[] path, int pathIndex)
        {
            if (pathIndex > path.Length - 2)
            {
                double dist = GetDistance(path);

                if (dist < shortestDistance)
                {
                    shortestPath = path;
                    shortestDistance = dist;

                    RenderPath();
                }
            }
            else
            {
                for (int i = 0; i < nodes.Length; i++)
                {
                    // display progress
                    if (pathIndex - 1 < levelProgress.Length)
                    {
                        levelProgress[pathIndex - 1] = i;
                        for (int j = pathIndex - 1 + 1; j < levelProgress.Length; j++)
                            levelProgress[j] = 0;

                        double progress = 0.0;

                        for (int j = 0; j < levelProgress.Length; j++)
                            progress += levelProgress[j] * Math.Pow(nodes.Length, levelProgress.Length - j - 1);

                        double progressPercent = (progress / Math.Pow(nodes.Length, levelProgress.Length)) * 100;

                        labelProgress.Text = "Progress: " + progressPercent.ToString("00.00") + "%";
                        Application.DoEvents();
                    }

                    if (nodeVisited[i])
                        continue;

                    nodeVisited[i] = true;

                    path[pathIndex] = i;
                    SolveOneByOne(ref nodeVisited, ref path, pathIndex + 1);

                    nodeVisited[i] = false;
                }
            }
        }
    }
}
