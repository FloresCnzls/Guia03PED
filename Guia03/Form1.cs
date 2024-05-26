using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guia03
{
    public partial class Form1 : Form
    {
        private List<Point> nodes = new List<Point>();
        private List<Tuple<int, int, int>> edges = new List<Tuple<int, int, int>>(); // From, To, Weight
        private Dijkstra dijkstra;
        private bool addingEdge = false;
        private int startNodeIndex;

        public Form1()
        {
            InitializeComponent();
            panelGraph.MouseClick += new MouseEventHandler(panelGraph_MouseClick);
            panelGraph.Paint += new PaintEventHandler(panelGraph_Paint);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Código para inicializar el formulario si es necesario
        }
        private void txtStartNode_GotFocus(object sender, EventArgs e)
        {
            if (txtStartNode.Text == "Nodo Inicial")
            {
                txtStartNode.Text = "";
            }
        }

        private void txtStartNode_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStartNode.Text))
            {
                txtStartNode.Text = "Nodo Inicial";
            }
        }
        private void panelGraph_MouseClick(object sender, MouseEventArgs e)
        {
            if (!addingEdge)
            {
                // Agregar nodo
                Point newNode = new Point(e.X, e.Y);
                nodes.Add(newNode);
                panelGraph.Invalidate(); // Redibuja el panel
            }
            else
            {
                // Agregar arco
                for (int i = 0; i < nodes.Count; i++)
                {
                    if (IsPointNearNode(e.Location, nodes[i]))
                    {
                        int endNodeIndex = i;
                        string input = InputBox.Show("Ingrese el peso del arco:", "Peso del arco");
                        if (int.TryParse(input, out int weight))
                        {
                            edges.Add(new Tuple<int, int, int>(startNodeIndex, endNodeIndex, weight));
                            panelGraph.Invalidate(); // Redibuja el panel
                            addingEdge = false;
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Ingrese un peso válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private bool IsPointNearNode(Point point, Point node)
        {
            int radius = 10; // Radio del nodo
            return (Math.Abs(point.X - node.X) <= radius && Math.Abs(point.Y - node.Y) <= radius);
        }

        private void btnAddNode_Click(object sender, EventArgs e)
        {
            addingEdge = false;
        }

        private void btnAddEdge_Click(object sender, EventArgs e)
        {
            addingEdge = true;
            MessageBox.Show("Haga clic en el nodo de inicio para el arco.");
        }

        private void btnRunDijkstra_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtStartNode.Text, out int startNode) && startNode >= 1 && startNode <= nodes.Count)
            {
                int[,] adjacencyMatrix = CreateAdjacencyMatrix(nodes.Count, edges);
                dijkstra = new Dijkstra(nodes.Count, adjacencyMatrix);
                dijkstra.RunDijkstra(startNode - 1);

                // Mostrar resultados
                string result = "Resultados de Dijkstra:\n";
                for (int i = 0; i < dijkstra.D.Length; i++)
                {
                    result += $"Distancia mínima al nodo {i + 1} es: {dijkstra.D[i]}\n";
                }
                MessageBox.Show(result);
            }
            else
            {
                MessageBox.Show("Ingrese un nodo inicial válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int[,] CreateAdjacencyMatrix(int nodeCount, List<Tuple<int, int, int>> edges)
        {
            int[,] matrix = new int[nodeCount, nodeCount];
            for (int i = 0; i < nodeCount; i++)
            {
                for (int j = 0; j < nodeCount; j++)
                {
                    matrix[i, j] = -1;
                }
            }

            foreach (var edge in edges)
            {
                matrix[edge.Item1, edge.Item2] = edge.Item3;
            }

            return matrix;
        }

        private void panelGraph_Paint(object sender, PaintEventArgs e)
        {
            // Dibujar nodos
            foreach (var node in nodes)
            {
                e.Graphics.FillEllipse(Brushes.Black, node.X - 5, node.Y - 5, 10, 10);
            }

            // Dibujar arcos
            foreach (var edge in edges)
            {
                Point from = nodes[edge.Item1];
                Point to = nodes[edge.Item2];
                e.Graphics.DrawLine(Pens.Black, from, to);
                // Dibujar el peso del arco
                Point midPoint = new Point((from.X + to.X) / 2, (from.Y + to.Y) / 2);
                e.Graphics.DrawString(edge.Item3.ToString(), this.Font, Brushes.Red, midPoint);
            }
        }
    }

    public static class InputBox
    {
        public static string Show(string prompt, string title)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = prompt;
            textBox.Text = "";

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new System.Drawing.Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new System.Drawing.Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            return dialogResult == DialogResult.OK ? textBox.Text : null;
        }
    }
}


