namespace Guia03
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAddNode;
        private System.Windows.Forms.Button btnAddEdge;
        private System.Windows.Forms.Button btnRunDijkstra;
        private System.Windows.Forms.Panel panelGraph;
        private System.Windows.Forms.TextBox txtStartNode;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnAddNode = new System.Windows.Forms.Button();
            this.btnAddEdge = new System.Windows.Forms.Button();
            this.btnRunDijkstra = new System.Windows.Forms.Button();
            this.panelGraph = new System.Windows.Forms.Panel();
            this.txtStartNode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAddNode
            // 
            this.btnAddNode.Location = new System.Drawing.Point(12, 12);
            this.btnAddNode.Name = "btnAddNode";
            this.btnAddNode.Size = new System.Drawing.Size(108, 23);
            this.btnAddNode.TabIndex = 0;
            this.btnAddNode.Text = "Agregar Nodo";
            this.btnAddNode.UseVisualStyleBackColor = true;
            this.btnAddNode.Click += new System.EventHandler(this.btnAddNode_Click);
            // 
            // btnAddEdge
            // 
            this.btnAddEdge.Location = new System.Drawing.Point(126, 10);
            this.btnAddEdge.Name = "btnAddEdge";
            this.btnAddEdge.Size = new System.Drawing.Size(115, 23);
            this.btnAddEdge.TabIndex = 1;
            this.btnAddEdge.Text = "Agregar Arco";
            this.btnAddEdge.UseVisualStyleBackColor = true;
            this.btnAddEdge.Click += new System.EventHandler(this.btnAddEdge_Click);
            // 
            // btnRunDijkstra
            // 
            this.btnRunDijkstra.Location = new System.Drawing.Point(247, 10);
            this.btnRunDijkstra.Name = "btnRunDijkstra";
            this.btnRunDijkstra.Size = new System.Drawing.Size(91, 23);
            this.btnRunDijkstra.TabIndex = 2;
            this.btnRunDijkstra.Text = "Ejecutar Dijkstra";
            this.btnRunDijkstra.UseVisualStyleBackColor = true;
            this.btnRunDijkstra.Click += new System.EventHandler(this.btnRunDijkstra_Click);
            // 
            // panelGraph
            // 
            this.panelGraph.BackColor = System.Drawing.SystemColors.Window;
            this.panelGraph.Location = new System.Drawing.Point(12, 41);
            this.panelGraph.Name = "panelGraph";
            this.panelGraph.Size = new System.Drawing.Size(776, 397);
            this.panelGraph.TabIndex = 3;
            // 
            // txtStartNode
            // 
            this.txtStartNode.Location = new System.Drawing.Point(353, 12);
            this.txtStartNode.Name = "txtStartNode";
            this.txtStartNode.Size = new System.Drawing.Size(100, 20);
            this.txtStartNode.TabIndex = 4;
            this.txtStartNode.Text = "Nodo Inicial";
            this.txtStartNode.GotFocus += new System.EventHandler(this.txtStartNode_GotFocus);
            this.txtStartNode.LostFocus += new System.EventHandler(this.txtStartNode_LostFocus);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtStartNode);
            this.Controls.Add(this.panelGraph);
            this.Controls.Add(this.btnRunDijkstra);
            this.Controls.Add(this.btnAddEdge);
            this.Controls.Add(this.btnAddNode);
            this.Name = "Form1";
            this.Text = "Simulador de Dijkstra";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

