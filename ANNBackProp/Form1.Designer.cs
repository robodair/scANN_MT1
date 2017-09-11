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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.buttonTest2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonTest1 = new System.Windows.Forms.Button();
            this.buttonRunStudent = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.nnChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.nnProgressBar = new System.Windows.Forms.ProgressBar();
            this.buttonRunIris = new System.Windows.Forms.Button();
            this.buttonAbalone = new System.Windows.Forms.Button();
            this.buttonRun4000 = new System.Windows.Forms.Button();
            this.buttonFaceAssignment = new System.Windows.Forms.Button();
            this.buttonTest3 = new System.Windows.Forms.Button();
            this.buttonTimesTables = new System.Windows.Forms.Button();
            this.checkBoxGraph = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nnChart)).BeginInit();
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
            this.textBox1.Font = new System.Drawing.Font("Courier New", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 197);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(514, 404);
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
            this.buttonRunStudent.Size = new System.Drawing.Size(105, 23);
            this.buttonRunStudent.TabIndex = 4;
            this.buttonRunStudent.Text = "Run Student";
            this.buttonRunStudent.UseVisualStyleBackColor = true;
            this.buttonRunStudent.Click += new System.EventHandler(this.buttonRunStudent_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(266, 5);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(634, 160);
            this.textBox2.TabIndex = 5;
            // 
            // nnChart
            // 
            this.nnChart.BorderlineColor = System.Drawing.Color.Gray;
            this.nnChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.Name = "ChartArea1";
            this.nnChart.ChartAreas.Add(chartArea2);
            legend2.BorderColor = System.Drawing.Color.Black;
            legend2.DockedToChartArea = "ChartArea1";
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend2.IsDockedInsideChartArea = false;
            legend2.Name = "Legend1";
            legend2.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Wide;
            this.nnChart.Legends.Add(legend2);
            this.nnChart.Location = new System.Drawing.Point(536, 197);
            this.nnChart.Margin = new System.Windows.Forms.Padding(2);
            this.nnChart.Name = "nnChart";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series3.Legend = "Legend1";
            series3.Name = "Training";
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series4.Legend = "Legend1";
            series4.Name = "Testing";
            this.nnChart.Series.Add(series3);
            this.nnChart.Series.Add(series4);
            this.nnChart.Size = new System.Drawing.Size(450, 403);
            this.nnChart.TabIndex = 6;
            this.nnChart.Text = "chart1";
            title3.Alignment = System.Drawing.ContentAlignment.BottomCenter;
            title3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            title3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            title3.Name = "Epochs";
            title3.Text = "Epochs";
            title4.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left;
            title4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            title4.Name = "Title1";
            title4.Text = "Accuracy %";
            this.nnChart.Titles.Add(title3);
            this.nnChart.Titles.Add(title4);
            // 
            // nnProgressBar
            // 
            this.nnProgressBar.Location = new System.Drawing.Point(12, 169);
            this.nnProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.nnProgressBar.Name = "nnProgressBar";
            this.nnProgressBar.Size = new System.Drawing.Size(974, 22);
            this.nnProgressBar.TabIndex = 7;
            this.nnProgressBar.Click += new System.EventHandler(this.nnProgressBar_Click);
            // 
            // buttonRunIris
            // 
            this.buttonRunIris.Location = new System.Drawing.Point(10, 82);
            this.buttonRunIris.Name = "buttonRunIris";
            this.buttonRunIris.Size = new System.Drawing.Size(105, 23);
            this.buttonRunIris.TabIndex = 8;
            this.buttonRunIris.Text = "Run Iris";
            this.buttonRunIris.UseVisualStyleBackColor = true;
            this.buttonRunIris.Click += new System.EventHandler(this.buttonRunIris_Click);
            // 
            // buttonAbalone
            // 
            this.buttonAbalone.Location = new System.Drawing.Point(10, 127);
            this.buttonAbalone.Name = "buttonAbalone";
            this.buttonAbalone.Size = new System.Drawing.Size(105, 23);
            this.buttonAbalone.TabIndex = 8;
            this.buttonAbalone.Text = "Run Abalone";
            this.buttonAbalone.UseVisualStyleBackColor = true;
            this.buttonAbalone.Click += new System.EventHandler(this.buttonAbalone_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 612);
            this.Controls.Add(this.checkBoxGraph);
            this.Controls.Add(this.buttonTimesTables);
            this.Controls.Add(this.buttonTest3);
            this.Controls.Add(this.buttonFaceAssignment);
            this.Controls.Add(this.buttonRun4000);
            this.Controls.Add(this.buttonAbalone);
            this.Controls.Add(this.buttonRunIris);
            this.Controls.Add(this.nnProgressBar);
            this.Controls.Add(this.nnChart);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.buttonRunStudent);
            this.Controls.Add(this.buttonTest1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonTest2);
            this.Controls.Add(this.buttonQuit);
            this.Name = "Form1";
            this.Text = "Ann Test v5.0.00b";
            ((System.ComponentModel.ISupportInitialize)(this.nnChart)).EndInit();
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
        private System.Windows.Forms.Button buttonRunIris;
        private System.Windows.Forms.Button buttonAbalone;
        private System.Windows.Forms.Button buttonRun4000;
        private System.Windows.Forms.Button buttonFaceAssignment;
        private System.Windows.Forms.Button buttonTest3;
        private System.Windows.Forms.Button buttonTimesTables;
        private System.Windows.Forms.CheckBox checkBoxGraph;
    }
}

