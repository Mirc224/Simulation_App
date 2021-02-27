
namespace Simulator_App
{
    partial class AppGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.simOptionsPanel = new System.Windows.Forms.Panel();
            this.OptConfirmButton = new System.Windows.Forms.Button();
            this.optionsLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.iterationsLabel = new System.Windows.Forms.Label();
            this.IterationsInput = new System.Windows.Forms.TextBox();
            this.replicationLabel = new System.Windows.Forms.Label();
            this.ReplicationsInput = new System.Windows.Forms.TextBox();
            this.tresholdValueLabel = new System.Windows.Forms.Label();
            this.TresholdInput = new System.Windows.Forms.TextBox();
            this.optionsLabel = new System.Windows.Forms.Label();
            this.simControlPanel = new System.Windows.Forms.Panel();
            this.StopButton = new System.Windows.Forms.Button();
            this.RunPauseButton = new System.Windows.Forms.Button();
            this.graphPanel = new System.Windows.Forms.Panel();
            this.SimulationGraph = new OxyPlot.WindowsForms.PlotView();
            this.simulationWorker = new System.ComponentModel.BackgroundWorker();
            this.simOptionsPanel.SuspendLayout();
            this.optionsLayoutPanel.SuspendLayout();
            this.simControlPanel.SuspendLayout();
            this.graphPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // simOptionsPanel
            // 
            this.simOptionsPanel.Controls.Add(this.OptConfirmButton);
            this.simOptionsPanel.Controls.Add(this.optionsLayoutPanel);
            this.simOptionsPanel.Controls.Add(this.optionsLabel);
            this.simOptionsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.simOptionsPanel.Location = new System.Drawing.Point(901, 0);
            this.simOptionsPanel.Name = "simOptionsPanel";
            this.simOptionsPanel.Size = new System.Drawing.Size(277, 655);
            this.simOptionsPanel.TabIndex = 0;
            // 
            // OptConfirmButton
            // 
            this.OptConfirmButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OptConfirmButton.Location = new System.Drawing.Point(91, 596);
            this.OptConfirmButton.Name = "OptConfirmButton";
            this.OptConfirmButton.Size = new System.Drawing.Size(95, 47);
            this.OptConfirmButton.TabIndex = 5;
            this.OptConfirmButton.Text = "Confirm";
            this.OptConfirmButton.UseVisualStyleBackColor = true;
            this.OptConfirmButton.Click += new System.EventHandler(this.OptConfirmButton_Click);
            // 
            // optionsLayoutPanel
            // 
            this.optionsLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsLayoutPanel.ColumnCount = 2;
            this.optionsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.optionsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.optionsLayoutPanel.Controls.Add(this.iterationsLabel, 0, 0);
            this.optionsLayoutPanel.Controls.Add(this.IterationsInput, 1, 0);
            this.optionsLayoutPanel.Controls.Add(this.replicationLabel, 0, 1);
            this.optionsLayoutPanel.Controls.Add(this.ReplicationsInput, 1, 1);
            this.optionsLayoutPanel.Controls.Add(this.tresholdValueLabel, 0, 2);
            this.optionsLayoutPanel.Controls.Add(this.TresholdInput, 1, 2);
            this.optionsLayoutPanel.Location = new System.Drawing.Point(6, 92);
            this.optionsLayoutPanel.Name = "optionsLayoutPanel";
            this.optionsLayoutPanel.RowCount = 3;
            this.optionsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.optionsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.optionsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.optionsLayoutPanel.Size = new System.Drawing.Size(269, 95);
            this.optionsLayoutPanel.TabIndex = 4;
            // 
            // iterationsLabel
            // 
            this.iterationsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iterationsLabel.AutoSize = true;
            this.iterationsLabel.Location = new System.Drawing.Point(3, 0);
            this.iterationsLabel.Name = "iterationsLabel";
            this.iterationsLabel.Size = new System.Drawing.Size(128, 28);
            this.iterationsLabel.TabIndex = 0;
            this.iterationsLabel.Text = "Iterations:";
            // 
            // IterationsInput
            // 
            this.IterationsInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IterationsInput.Location = new System.Drawing.Point(137, 3);
            this.IterationsInput.Name = "IterationsInput";
            this.IterationsInput.Size = new System.Drawing.Size(129, 22);
            this.IterationsInput.TabIndex = 1;
            // 
            // replicationLabel
            // 
            this.replicationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.replicationLabel.AutoSize = true;
            this.replicationLabel.Location = new System.Drawing.Point(3, 28);
            this.replicationLabel.Name = "replicationLabel";
            this.replicationLabel.Size = new System.Drawing.Size(128, 28);
            this.replicationLabel.TabIndex = 2;
            this.replicationLabel.Text = "Replications";
            // 
            // ReplicationsInput
            // 
            this.ReplicationsInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReplicationsInput.Location = new System.Drawing.Point(137, 31);
            this.ReplicationsInput.Name = "ReplicationsInput";
            this.ReplicationsInput.Size = new System.Drawing.Size(129, 22);
            this.ReplicationsInput.TabIndex = 3;
            // 
            // tresholdValueLabel
            // 
            this.tresholdValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tresholdValueLabel.AutoSize = true;
            this.tresholdValueLabel.Location = new System.Drawing.Point(3, 56);
            this.tresholdValueLabel.Name = "tresholdValueLabel";
            this.tresholdValueLabel.Size = new System.Drawing.Size(128, 39);
            this.tresholdValueLabel.TabIndex = 4;
            this.tresholdValueLabel.Text = "Size of K: ";
            // 
            // TresholdInput
            // 
            this.TresholdInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TresholdInput.Location = new System.Drawing.Point(137, 59);
            this.TresholdInput.Name = "TresholdInput";
            this.TresholdInput.Size = new System.Drawing.Size(129, 22);
            this.TresholdInput.TabIndex = 5;
            // 
            // optionsLabel
            // 
            this.optionsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsLabel.AutoSize = true;
            this.optionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.optionsLabel.Location = new System.Drawing.Point(76, 9);
            this.optionsLabel.Name = "optionsLabel";
            this.optionsLabel.Size = new System.Drawing.Size(100, 29);
            this.optionsLabel.TabIndex = 3;
            this.optionsLabel.Text = "Options";
            // 
            // simControlPanel
            // 
            this.simControlPanel.Controls.Add(this.StopButton);
            this.simControlPanel.Controls.Add(this.RunPauseButton);
            this.simControlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.simControlPanel.Location = new System.Drawing.Point(0, 0);
            this.simControlPanel.Name = "simControlPanel";
            this.simControlPanel.Size = new System.Drawing.Size(901, 65);
            this.simControlPanel.TabIndex = 2;
            // 
            // StopButton
            // 
            this.StopButton.Enabled = false;
            this.StopButton.Location = new System.Drawing.Point(127, 12);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(93, 39);
            this.StopButton.TabIndex = 2;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // RunPauseButton
            // 
            this.RunPauseButton.Location = new System.Drawing.Point(12, 12);
            this.RunPauseButton.Name = "RunPauseButton";
            this.RunPauseButton.Size = new System.Drawing.Size(86, 39);
            this.RunPauseButton.TabIndex = 1;
            this.RunPauseButton.Text = "Run";
            this.RunPauseButton.UseVisualStyleBackColor = true;
            this.RunPauseButton.Click += new System.EventHandler(this.RunPauseButton_Click);
            // 
            // graphPanel
            // 
            this.graphPanel.Controls.Add(this.SimulationGraph);
            this.graphPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphPanel.Location = new System.Drawing.Point(0, 65);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(901, 590);
            this.graphPanel.TabIndex = 3;
            // 
            // SimulationGraph
            // 
            this.SimulationGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SimulationGraph.Location = new System.Drawing.Point(12, 6);
            this.SimulationGraph.Name = "SimulationGraph";
            this.SimulationGraph.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.SimulationGraph.Size = new System.Drawing.Size(883, 572);
            this.SimulationGraph.TabIndex = 0;
            this.SimulationGraph.Text = "plotView1";
            this.SimulationGraph.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.SimulationGraph.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.SimulationGraph.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // simulationWorker
            // 
            this.simulationWorker.WorkerReportsProgress = true;
            this.simulationWorker.WorkerSupportsCancellation = true;
            this.simulationWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SimulationWorker_DoWork);
            this.simulationWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.SimulationWorker_ProgressChanged);
            this.simulationWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.SimulationWorker_RunWorkerCompleted);
            // 
            // AppGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 655);
            this.Controls.Add(this.graphPanel);
            this.Controls.Add(this.simControlPanel);
            this.Controls.Add(this.simOptionsPanel);
            this.Name = "AppGUI";
            this.Text = "SimulatorApp";
            this.simOptionsPanel.ResumeLayout(false);
            this.simOptionsPanel.PerformLayout();
            this.optionsLayoutPanel.ResumeLayout(false);
            this.optionsLayoutPanel.PerformLayout();
            this.simControlPanel.ResumeLayout(false);
            this.graphPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel simOptionsPanel;
        private System.Windows.Forms.Panel simControlPanel;
        private System.Windows.Forms.Panel graphPanel;
        private System.Windows.Forms.TableLayoutPanel optionsLayoutPanel;
        private System.Windows.Forms.Label iterationsLabel;
        private System.Windows.Forms.TextBox IterationsInput;
        private System.Windows.Forms.Label optionsLabel;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button RunPauseButton;
        private OxyPlot.WindowsForms.PlotView SimulationGraph;
        private System.Windows.Forms.Button OptConfirmButton;
        private System.Windows.Forms.Label replicationLabel;
        private System.Windows.Forms.TextBox ReplicationsInput;
        private System.ComponentModel.BackgroundWorker simulationWorker;
        private System.Windows.Forms.Label tresholdValueLabel;
        private System.Windows.Forms.TextBox TresholdInput;
    }
}

