
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
            this.optionsLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.YStartInput = new System.Windows.Forms.TextBox();
            this.XStartInput = new System.Windows.Forms.TextBox();
            this.YSizeInput = new System.Windows.Forms.TextBox();
            this.ReplicationsLabel = new System.Windows.Forms.Label();
            this.ReplicationsInput = new System.Windows.Forms.TextBox();
            this.TresholdLabel = new System.Windows.Forms.Label();
            this.TresholdInput = new System.Windows.Forms.TextBox();
            this.XSizeLabel = new System.Windows.Forms.Label();
            this.YSizeLabel = new System.Windows.Forms.Label();
            this.XStartLabel = new System.Windows.Forms.Label();
            this.YStartLabel = new System.Windows.Forms.Label();
            this.XSizeInput = new System.Windows.Forms.TextBox();
            this.SeedLabel = new System.Windows.Forms.Label();
            this.SeedInput = new System.Windows.Forms.TextBox();
            this.OptConfirmButton = new System.Windows.Forms.Button();
            this.optionsLabel = new System.Windows.Forms.Label();
            this.AutoSeedCheck = new System.Windows.Forms.CheckBox();
            this.simControlPanel = new System.Windows.Forms.Panel();
            this.StopButton = new System.Windows.Forms.Button();
            this.RunPauseButton = new System.Windows.Forms.Button();
            this.graphPanel = new System.Windows.Forms.Panel();
            this.ProbabilityGraph = new OxyPlot.WindowsForms.PlotView();
            this.StatusPanel = new System.Windows.Forms.Panel();
            this.StrategyMovesLabel = new System.Windows.Forms.Label();
            this.ProbabilityLabel = new System.Windows.Forms.Label();
            this.MeanValueLabel = new System.Windows.Forms.Label();
            this.SimulationGraph = new OxyPlot.WindowsForms.PlotView();
            this.simulationWorker = new System.ComponentModel.BackgroundWorker();
            this.MinValueLabel = new System.Windows.Forms.Label();
            this.MaxValueLabel = new System.Windows.Forms.Label();
            this.simOptionsPanel.SuspendLayout();
            this.optionsLayoutPanel.SuspendLayout();
            this.simControlPanel.SuspendLayout();
            this.graphPanel.SuspendLayout();
            this.StatusPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // simOptionsPanel
            // 
            this.simOptionsPanel.Controls.Add(this.optionsLayoutPanel);
            this.simOptionsPanel.Controls.Add(this.OptConfirmButton);
            this.simOptionsPanel.Controls.Add(this.optionsLabel);
            this.simOptionsPanel.Controls.Add(this.AutoSeedCheck);
            this.simOptionsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.simOptionsPanel.Location = new System.Drawing.Point(1478, 0);
            this.simOptionsPanel.Name = "simOptionsPanel";
            this.simOptionsPanel.Size = new System.Drawing.Size(277, 854);
            this.simOptionsPanel.TabIndex = 0;
            // 
            // optionsLayoutPanel
            // 
            this.optionsLayoutPanel.ColumnCount = 2;
            this.optionsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.optionsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.optionsLayoutPanel.Controls.Add(this.YStartInput, 1, 3);
            this.optionsLayoutPanel.Controls.Add(this.XStartInput, 1, 2);
            this.optionsLayoutPanel.Controls.Add(this.YSizeInput, 1, 1);
            this.optionsLayoutPanel.Controls.Add(this.ReplicationsLabel, 0, 5);
            this.optionsLayoutPanel.Controls.Add(this.ReplicationsInput, 1, 5);
            this.optionsLayoutPanel.Controls.Add(this.TresholdLabel, 0, 4);
            this.optionsLayoutPanel.Controls.Add(this.TresholdInput, 1, 4);
            this.optionsLayoutPanel.Controls.Add(this.XSizeLabel, 0, 0);
            this.optionsLayoutPanel.Controls.Add(this.YSizeLabel, 0, 1);
            this.optionsLayoutPanel.Controls.Add(this.XStartLabel, 0, 2);
            this.optionsLayoutPanel.Controls.Add(this.YStartLabel, 0, 3);
            this.optionsLayoutPanel.Controls.Add(this.XSizeInput, 1, 0);
            this.optionsLayoutPanel.Controls.Add(this.SeedLabel, 0, 6);
            this.optionsLayoutPanel.Controls.Add(this.SeedInput, 1, 6);
            this.optionsLayoutPanel.Location = new System.Drawing.Point(0, 65);
            this.optionsLayoutPanel.Name = "optionsLayoutPanel";
            this.optionsLayoutPanel.RowCount = 7;
            this.optionsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.optionsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.optionsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.optionsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.optionsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.optionsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.optionsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.optionsLayoutPanel.Size = new System.Drawing.Size(274, 224);
            this.optionsLayoutPanel.TabIndex = 6;
            // 
            // YStartInput
            // 
            this.YStartInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.YStartInput.Location = new System.Drawing.Point(140, 93);
            this.YStartInput.Name = "YStartInput";
            this.YStartInput.Size = new System.Drawing.Size(131, 22);
            this.YStartInput.TabIndex = 5;
            // 
            // XStartInput
            // 
            this.XStartInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.XStartInput.Location = new System.Drawing.Point(140, 59);
            this.XStartInput.Name = "XStartInput";
            this.XStartInput.Size = new System.Drawing.Size(131, 22);
            this.XStartInput.TabIndex = 4;
            // 
            // YSizeInput
            // 
            this.YSizeInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.YSizeInput.Location = new System.Drawing.Point(140, 31);
            this.YSizeInput.Name = "YSizeInput";
            this.YSizeInput.Size = new System.Drawing.Size(131, 22);
            this.YSizeInput.TabIndex = 3;
            // 
            // ReplicationsLabel
            // 
            this.ReplicationsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReplicationsLabel.AutoSize = true;
            this.ReplicationsLabel.Location = new System.Drawing.Point(3, 158);
            this.ReplicationsLabel.Name = "ReplicationsLabel";
            this.ReplicationsLabel.Size = new System.Drawing.Size(131, 34);
            this.ReplicationsLabel.TabIndex = 2;
            this.ReplicationsLabel.Text = "Replications (actual 100):";
            this.ReplicationsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ReplicationsInput
            // 
            this.ReplicationsInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReplicationsInput.Location = new System.Drawing.Point(140, 161);
            this.ReplicationsInput.Name = "ReplicationsInput";
            this.ReplicationsInput.Size = new System.Drawing.Size(131, 22);
            this.ReplicationsInput.TabIndex = 7;
            // 
            // TresholdLabel
            // 
            this.TresholdLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TresholdLabel.AutoSize = true;
            this.TresholdLabel.Location = new System.Drawing.Point(3, 124);
            this.TresholdLabel.Name = "TresholdLabel";
            this.TresholdLabel.Size = new System.Drawing.Size(131, 34);
            this.TresholdLabel.TabIndex = 4;
            this.TresholdLabel.Text = "Size of K (actual 1): ";
            this.TresholdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TresholdInput
            // 
            this.TresholdInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TresholdInput.Location = new System.Drawing.Point(140, 127);
            this.TresholdInput.Name = "TresholdInput";
            this.TresholdInput.Size = new System.Drawing.Size(131, 22);
            this.TresholdInput.TabIndex = 6;
            // 
            // XSizeLabel
            // 
            this.XSizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.XSizeLabel.AutoSize = true;
            this.XSizeLabel.Location = new System.Drawing.Point(3, 0);
            this.XSizeLabel.Name = "XSizeLabel";
            this.XSizeLabel.Size = new System.Drawing.Size(131, 28);
            this.XSizeLabel.TabIndex = 6;
            this.XSizeLabel.Text = "X size (actual 5):";
            this.XSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // YSizeLabel
            // 
            this.YSizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.YSizeLabel.AutoSize = true;
            this.YSizeLabel.Location = new System.Drawing.Point(3, 28);
            this.YSizeLabel.Name = "YSizeLabel";
            this.YSizeLabel.Size = new System.Drawing.Size(131, 28);
            this.YSizeLabel.TabIndex = 7;
            this.YSizeLabel.Text = "Y size (actual 5):";
            this.YSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // XStartLabel
            // 
            this.XStartLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.XStartLabel.AutoSize = true;
            this.XStartLabel.Location = new System.Drawing.Point(3, 56);
            this.XStartLabel.Name = "XStartLabel";
            this.XStartLabel.Size = new System.Drawing.Size(131, 34);
            this.XStartLabel.TabIndex = 8;
            this.XStartLabel.Text = "X start position (actual 0):";
            this.XStartLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // YStartLabel
            // 
            this.YStartLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.YStartLabel.AutoSize = true;
            this.YStartLabel.Location = new System.Drawing.Point(3, 90);
            this.YStartLabel.Name = "YStartLabel";
            this.YStartLabel.Size = new System.Drawing.Size(131, 34);
            this.YStartLabel.TabIndex = 9;
            this.YStartLabel.Text = "Y start position (actual 0):";
            this.YStartLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // XSizeInput
            // 
            this.XSizeInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.XSizeInput.Location = new System.Drawing.Point(140, 3);
            this.XSizeInput.Name = "XSizeInput";
            this.XSizeInput.Size = new System.Drawing.Size(131, 22);
            this.XSizeInput.TabIndex = 2;
            // 
            // SeedLabel
            // 
            this.SeedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SeedLabel.AutoSize = true;
            this.SeedLabel.Location = new System.Drawing.Point(3, 192);
            this.SeedLabel.Name = "SeedLabel";
            this.SeedLabel.Size = new System.Drawing.Size(131, 32);
            this.SeedLabel.TabIndex = 10;
            this.SeedLabel.Text = "Seed:";
            this.SeedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SeedInput
            // 
            this.SeedInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SeedInput.Location = new System.Drawing.Point(140, 195);
            this.SeedInput.Name = "SeedInput";
            this.SeedInput.Size = new System.Drawing.Size(131, 22);
            this.SeedInput.TabIndex = 11;
            // 
            // OptConfirmButton
            // 
            this.OptConfirmButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OptConfirmButton.Location = new System.Drawing.Point(91, 795);
            this.OptConfirmButton.Name = "OptConfirmButton";
            this.OptConfirmButton.Size = new System.Drawing.Size(95, 47);
            this.OptConfirmButton.TabIndex = 0;
            this.OptConfirmButton.Text = "Confirm";
            this.OptConfirmButton.UseVisualStyleBackColor = true;
            this.OptConfirmButton.Click += new System.EventHandler(this.OptConfirmButton_Click);
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
            // AutoSeedCheck
            // 
            this.AutoSeedCheck.AutoSize = true;
            this.AutoSeedCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AutoSeedCheck.Checked = true;
            this.AutoSeedCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoSeedCheck.Location = new System.Drawing.Point(37, 295);
            this.AutoSeedCheck.Name = "AutoSeedCheck";
            this.AutoSeedCheck.Size = new System.Drawing.Size(122, 21);
            this.AutoSeedCheck.TabIndex = 12;
            this.AutoSeedCheck.Text = "Random seed:";
            this.AutoSeedCheck.UseVisualStyleBackColor = true;
            this.AutoSeedCheck.CheckedChanged += new System.EventHandler(this.AutoSeedCheck_CheckedChanged);
            // 
            // simControlPanel
            // 
            this.simControlPanel.Controls.Add(this.StopButton);
            this.simControlPanel.Controls.Add(this.RunPauseButton);
            this.simControlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.simControlPanel.Location = new System.Drawing.Point(0, 0);
            this.simControlPanel.Name = "simControlPanel";
            this.simControlPanel.Size = new System.Drawing.Size(1478, 60);
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
            this.graphPanel.Controls.Add(this.ProbabilityGraph);
            this.graphPanel.Controls.Add(this.StatusPanel);
            this.graphPanel.Controls.Add(this.SimulationGraph);
            this.graphPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphPanel.Location = new System.Drawing.Point(0, 60);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(1478, 794);
            this.graphPanel.TabIndex = 3;
            // 
            // ProbabilityGraph
            // 
            this.ProbabilityGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProbabilityGraph.Location = new System.Drawing.Point(3, 407);
            this.ProbabilityGraph.Name = "ProbabilityGraph";
            this.ProbabilityGraph.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.ProbabilityGraph.Size = new System.Drawing.Size(1475, 387);
            this.ProbabilityGraph.TabIndex = 2;
            this.ProbabilityGraph.Text = "plotView1";
            this.ProbabilityGraph.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.ProbabilityGraph.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.ProbabilityGraph.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // StatusPanel
            // 
            this.StatusPanel.Controls.Add(this.MaxValueLabel);
            this.StatusPanel.Controls.Add(this.MinValueLabel);
            this.StatusPanel.Controls.Add(this.StrategyMovesLabel);
            this.StatusPanel.Controls.Add(this.ProbabilityLabel);
            this.StatusPanel.Controls.Add(this.MeanValueLabel);
            this.StatusPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.StatusPanel.Location = new System.Drawing.Point(0, 0);
            this.StatusPanel.Name = "StatusPanel";
            this.StatusPanel.Size = new System.Drawing.Size(1478, 41);
            this.StatusPanel.TabIndex = 1;
            // 
            // StrategyMovesLabel
            // 
            this.StrategyMovesLabel.AutoSize = true;
            this.StrategyMovesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.StrategyMovesLabel.Location = new System.Drawing.Point(1196, 13);
            this.StrategyMovesLabel.Name = "StrategyMovesLabel";
            this.StrategyMovesLabel.Size = new System.Drawing.Size(186, 20);
            this.StrategyMovesLabel.TabIndex = 2;
            this.StrategyMovesLabel.Text = "Strategy mean value:";
            // 
            // ProbabilityLabel
            // 
            this.ProbabilityLabel.AutoSize = true;
            this.ProbabilityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.ProbabilityLabel.Location = new System.Drawing.Point(769, 13);
            this.ProbabilityLabel.Name = "ProbabilityLabel";
            this.ProbabilityLabel.Size = new System.Drawing.Size(123, 20);
            this.ProbabilityLabel.TabIndex = 1;
            this.ProbabilityLabel.Text = "More than K: ";
            // 
            // MeanValueLabel
            // 
            this.MeanValueLabel.AutoSize = true;
            this.MeanValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MeanValueLabel.Location = new System.Drawing.Point(8, 13);
            this.MeanValueLabel.Name = "MeanValueLabel";
            this.MeanValueLabel.Size = new System.Drawing.Size(110, 20);
            this.MeanValueLabel.TabIndex = 0;
            this.MeanValueLabel.Text = "Mean value:";
            // 
            // SimulationGraph
            // 
            this.SimulationGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SimulationGraph.Location = new System.Drawing.Point(0, 47);
            this.SimulationGraph.Name = "SimulationGraph";
            this.SimulationGraph.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.SimulationGraph.Size = new System.Drawing.Size(1472, 354);
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
            // MinValueLabel
            // 
            this.MinValueLabel.AutoSize = true;
            this.MinValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.MinValueLabel.Location = new System.Drawing.Point(350, 13);
            this.MinValueLabel.Name = "MinValueLabel";
            this.MinValueLabel.Size = new System.Drawing.Size(95, 20);
            this.MinValueLabel.TabIndex = 3;
            this.MinValueLabel.Text = "Min value:";
            // 
            // MaxValueLabel
            // 
            this.MaxValueLabel.AutoSize = true;
            this.MaxValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.MaxValueLabel.Location = new System.Drawing.Point(510, 13);
            this.MaxValueLabel.Name = "MaxValueLabel";
            this.MaxValueLabel.Size = new System.Drawing.Size(99, 20);
            this.MaxValueLabel.TabIndex = 4;
            this.MaxValueLabel.Text = "Max value:";
            // 
            // AppGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1755, 854);
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
            this.StatusPanel.ResumeLayout(false);
            this.StatusPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel simOptionsPanel;
        private System.Windows.Forms.Panel simControlPanel;
        private System.Windows.Forms.Panel graphPanel;
        private System.Windows.Forms.Label optionsLabel;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button RunPauseButton;
        private OxyPlot.WindowsForms.PlotView SimulationGraph;
        private System.Windows.Forms.Button OptConfirmButton;
        private System.Windows.Forms.Label ReplicationsLabel;
        private System.Windows.Forms.TextBox ReplicationsInput;
        private System.ComponentModel.BackgroundWorker simulationWorker;
        private System.Windows.Forms.Label TresholdLabel;
        private System.Windows.Forms.TextBox TresholdInput;
        private System.Windows.Forms.TableLayoutPanel optionsLayoutPanel;
        private System.Windows.Forms.TextBox YStartInput;
        private System.Windows.Forms.TextBox XStartInput;
        private System.Windows.Forms.TextBox YSizeInput;
        private System.Windows.Forms.Label XSizeLabel;
        private System.Windows.Forms.Label YSizeLabel;
        private System.Windows.Forms.Label XStartLabel;
        private System.Windows.Forms.Label YStartLabel;
        private System.Windows.Forms.TextBox XSizeInput;
        private System.Windows.Forms.Panel StatusPanel;
        private System.Windows.Forms.Label ProbabilityLabel;
        private System.Windows.Forms.Label MeanValueLabel;
        private OxyPlot.WindowsForms.PlotView ProbabilityGraph;
        private System.Windows.Forms.Label StrategyMovesLabel;
        private System.Windows.Forms.Label SeedLabel;
        private System.Windows.Forms.TextBox SeedInput;
        private System.Windows.Forms.CheckBox AutoSeedCheck;
        private System.Windows.Forms.Label MaxValueLabel;
        private System.Windows.Forms.Label MinValueLabel;
    }
}

