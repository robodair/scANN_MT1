namespace ANNShell
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.buttonTest2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonTest1 = new System.Windows.Forms.Button();
            this.buttonRunStudent = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.nnChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.nnProgressBar = new System.Windows.Forms.ProgressBar();
            this.buttonRunWine = new System.Windows.Forms.Button();
            this.buttonHeartCleveland = new System.Windows.Forms.Button();
            this.buttonRun4000 = new System.Windows.Forms.Button();
            this.buttonFaceAssignment = new System.Windows.Forms.Button();
            this.buttonTest3 = new System.Windows.Forms.Button();
            this.buttonTimesTables = new System.Windows.Forms.Button();
            this.checkBoxGraph = new System.Windows.Forms.CheckBox();
            this.buttonRunCancer = new System.Windows.Forms.Button();
            this.textPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.layoutOutputAndGraph = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.nnChart)).BeginInit();
            this.layoutOutputAndGraph.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonQuit
            // 
            this.buttonQuit.Location = new System.Drawing.Point(911, 5);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(75, 23);
            this.buttonQuit.TabIndex = 0;
            this.buttonQuit.Text = "Quit";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // buttonTest2
            // 
            this.buttonTest2.Location = new System.Drawing.Point(911, 112);
            this.buttonTest2.Name = "buttonTest2";
            this.buttonTest2.Size = new System.Drawing.Size(75, 23);
            this.buttonTest2.TabIndex = 1;
            this.buttonTest2.Text = "Test 1";
            this.buttonTest2.UseVisualStyleBackColor = true;
            this.buttonTest2.Click += new System.EventHandler(this.buttonTest2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Courier New", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(485, 398);
            this.textBox1.TabIndex = 2;
            // 
            // buttonTest1
            // 
            this.buttonTest1.Location = new System.Drawing.Point(910, 141);
            this.buttonTest1.Name = "buttonTest1";
            this.buttonTest1.Size = new System.Drawing.Size(75, 23);
            this.buttonTest1.TabIndex = 3;
            this.buttonTest1.Text = "Test 2";
            this.buttonTest1.UseVisualStyleBackColor = true;
            this.buttonTest1.Click += new System.EventHandler(this.buttonTest1_Click);
            // 
            // buttonRunStudent
            // 
            this.buttonRunStudent.Location = new System.Drawing.Point(10, 5);
            this.buttonRunStudent.Name = "buttonRunStudent";
            this.buttonRunStudent.Size = new System.Drawing.Size(117, 23);
            this.buttonRunStudent.TabIndex = 4;
            this.buttonRunStudent.Text = "Run Student";
            this.buttonRunStudent.UseVisualStyleBackColor = true;
            this.buttonRunStudent.Click += new System.EventHandler(this.buttonRunStudent_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(266, 43);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(634, 122);
            this.textBox2.TabIndex = 5;
            // 
            // nnChart
            // 
            this.nnChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nnChart.BorderlineColor = System.Drawing.Color.Gray;
            this.nnChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.nnChart.ChartAreas.Add(chartArea1);
            legend1.BorderColor = System.Drawing.Color.Black;
            legend1.DockedToChartArea = "ChartArea1";
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.IsDockedInsideChartArea = false;
            legend1.Name = "Legend1";
            legend1.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Wide;
            this.nnChart.Legends.Add(legend1);
            this.nnChart.Location = new System.Drawing.Point(493, 2);
            this.nnChart.Margin = new System.Windows.Forms.Padding(2);
            this.nnChart.Name = "nnChart";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Legend = "Legend1";
            series1.Name = "Training";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.Legend = "Legend1";
            series2.Name = "Testing";
            this.nnChart.Series.Add(series1);
            this.nnChart.Series.Add(series2);
            this.nnChart.Size = new System.Drawing.Size(487, 400);
            this.nnChart.TabIndex = 6;
            this.nnChart.Text = "chart1";
            title1.Alignment = System.Drawing.ContentAlignment.BottomCenter;
            title1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            title1.Name = "Epochs";
            title1.Text = "Epochs";
            title2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left;
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            title2.Name = "Title1";
            title2.Text = "Accuracy %";
            this.nnChart.Titles.Add(title1);
            this.nnChart.Titles.Add(title2);
            // 
            // nnProgressBar
            // 
            this.nnProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nnProgressBar.Location = new System.Drawing.Point(10, 169);
            this.nnProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.nnProgressBar.Name = "nnProgressBar";
            this.nnProgressBar.Size = new System.Drawing.Size(982, 22);
            this.nnProgressBar.TabIndex = 7;
            this.nnProgressBar.Click += new System.EventHandler(this.nnProgressBar_Click);
            // 
            // buttonRunWine
            // 
            this.buttonRunWine.Location = new System.Drawing.Point(10, 82);
            this.buttonRunWine.Name = "buttonRunWine";
            this.buttonRunWine.Size = new System.Drawing.Size(117, 23);
            this.buttonRunWine.TabIndex = 8;
            this.buttonRunWine.Text = "Run Wine";
            this.buttonRunWine.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonRunWine.UseVisualStyleBackColor = true;
            this.buttonRunWine.Click += new System.EventHandler(this.buttonRunWine_Click);
            // 
            // buttonHeartCleveland
            // 
            this.buttonHeartCleveland.Location = new System.Drawing.Point(10, 127);
            this.buttonHeartCleveland.Name = "buttonHeartCleveland";
            this.buttonHeartCleveland.Size = new System.Drawing.Size(117, 23);
            this.buttonHeartCleveland.TabIndex = 8;
            this.buttonHeartCleveland.Text = "Run Heart Cleveland ";
            this.buttonHeartCleveland.UseVisualStyleBackColor = true;
            this.buttonHeartCleveland.Click += new System.EventHandler(this.buttonHeartCleveland_Click);
            // 
            // buttonRun4000
            // 
            this.buttonRun4000.Location = new System.Drawing.Point(133, 127);
            this.buttonRun4000.Name = "buttonRun4000";
            this.buttonRun4000.Size = new System.Drawing.Size(105, 23);
            this.buttonRun4000.TabIndex = 8;
            this.buttonRun4000.Text = "Run 4000e10";
            this.buttonRun4000.UseVisualStyleBackColor = true;
            this.buttonRun4000.Click += new System.EventHandler(this.buttonRun4000_Click);
            // 
            // buttonFaceAssignment
            // 
            this.buttonFaceAssignment.Location = new System.Drawing.Point(136, 5);
            this.buttonFaceAssignment.Name = "buttonFaceAssignment";
            this.buttonFaceAssignment.Size = new System.Drawing.Size(102, 23);
            this.buttonFaceAssignment.TabIndex = 8;
            this.buttonFaceAssignment.Text = "Face Assignment";
            this.buttonFaceAssignment.UseVisualStyleBackColor = true;
            this.buttonFaceAssignment.Click += new System.EventHandler(this.buttonFaceAssignment_Click);
            // 
            // buttonTest3
            // 
            this.buttonTest3.Location = new System.Drawing.Point(911, 82);
            this.buttonTest3.Name = "buttonTest3";
            this.buttonTest3.Size = new System.Drawing.Size(75, 23);
            this.buttonTest3.TabIndex = 9;
            this.buttonTest3.Text = "Test 3";
            this.buttonTest3.UseVisualStyleBackColor = true;
            this.buttonTest3.Click += new System.EventHandler(this.buttonTest3_Click);
            // 
            // buttonTimesTables
            // 
            this.buttonTimesTables.Location = new System.Drawing.Point(133, 82);
            this.buttonTimesTables.Name = "buttonTimesTables";
            this.buttonTimesTables.Size = new System.Drawing.Size(105, 23);
            this.buttonTimesTables.TabIndex = 10;
            this.buttonTimesTables.Text = "Times tables";
            this.buttonTimesTables.UseVisualStyleBackColor = true;
            this.buttonTimesTables.Click += new System.EventHandler(this.buttonTimesTables_Click);
            // 
            // checkBoxGraph
            // 
            this.checkBoxGraph.AutoSize = true;
            this.checkBoxGraph.Checked = true;
            this.checkBoxGraph.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGraph.Location = new System.Drawing.Point(136, 43);
            this.checkBoxGraph.Name = "checkBoxGraph";
            this.checkBoxGraph.Size = new System.Drawing.Size(55, 17);
            this.checkBoxGraph.TabIndex = 11;
            this.checkBoxGraph.Text = "Graph";
            this.checkBoxGraph.UseVisualStyleBackColor = true;
            // 
            // buttonRunCancer
            // 
            this.buttonRunCancer.Location = new System.Drawing.Point(13, 43);
            this.buttonRunCancer.Name = "buttonRunCancer";
            this.buttonRunCancer.Size = new System.Drawing.Size(114, 23);
            this.buttonRunCancer.TabIndex = 12;
            this.buttonRunCancer.Text = "Run Cancer";
            this.buttonRunCancer.UseVisualStyleBackColor = true;
            this.buttonRunCancer.Click += new System.EventHandler(this.buttonRunCancer_Click);
            // 
            // textPath
            // 
            this.textPath.Location = new System.Drawing.Point(331, 7);
            this.textPath.Name = "textPath";
            this.textPath.Size = new System.Drawing.Size(569, 20);
            this.textPath.TabIndex = 13;
            this.textPath.Text = "M:\\UniFolder\\Y4 S2\\Soft Computing (7168)\\MT1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(263, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Data Root: ";
            // 
            // layoutOutputAndGraph
            // 
            this.layoutOutputAndGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutOutputAndGraph.ColumnCount = 2;
            this.layoutOutputAndGraph.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutOutputAndGraph.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutOutputAndGraph.Controls.Add(this.nnChart, 1, 0);
            this.layoutOutputAndGraph.Controls.Add(this.textBox1, 0, 0);
            this.layoutOutputAndGraph.Location = new System.Drawing.Point(10, 196);
            this.layoutOutputAndGraph.Name = "layoutOutputAndGraph";
            this.layoutOutputAndGraph.RowCount = 1;
            this.layoutOutputAndGraph.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutOutputAndGraph.Size = new System.Drawing.Size(982, 404);
            this.layoutOutputAndGraph.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 612);
            this.Controls.Add(this.layoutOutputAndGraph);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textPath);
            this.Controls.Add(this.buttonRunCancer);
            this.Controls.Add(this.checkBoxGraph);
            this.Controls.Add(this.buttonTimesTables);
            this.Controls.Add(this.buttonTest3);
            this.Controls.Add(this.buttonFaceAssignment);
            this.Controls.Add(this.buttonRun4000);
            this.Controls.Add(this.buttonHeartCleveland);
            this.Controls.Add(this.buttonRunWine);
            this.Controls.Add(this.nnProgressBar);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.buttonRunStudent);
            this.Controls.Add(this.buttonTest1);
            this.Controls.Add(this.buttonTest2);
            this.Controls.Add(this.buttonQuit);
            this.Name = "Form1";
            this.Text = "Ann Test v5.0.00b";
            ((System.ComponentModel.ISupportInitialize)(this.nnChart)).EndInit();
            this.layoutOutputAndGraph.ResumeLayout(false);
            this.layoutOutputAndGraph.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Button buttonTest2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonTest1;
        private System.Windows.Forms.Button buttonRunStudent;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart nnChart;
        private System.Windows.Forms.ProgressBar nnProgressBar;
        private System.Windows.Forms.Button buttonRunWine;
        private System.Windows.Forms.Button buttonHeartCleveland;
        private System.Windows.Forms.Button buttonRun4000;
        private System.Windows.Forms.Button buttonFaceAssignment;
        private System.Windows.Forms.Button buttonTest3;
        private System.Windows.Forms.Button buttonTimesTables;
        private System.Windows.Forms.CheckBox checkBoxGraph;
        private System.Windows.Forms.Button buttonRunCancer;
        private System.Windows.Forms.TextBox textPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel layoutOutputAndGraph;
    }
}

