
namespace QuanLyKhuTro.View
{
    partial class ThongKeDoanhThu
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.statisticalMonth = new LiveCharts.WinForms.PieChart();
            this.statisticalOneYear = new LiveCharts.WinForms.CartesianChart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PieStatisticalAll = new LiveCharts.WinForms.PieChart();
            this.chartLine = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartLine)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.statisticalMonth, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.statisticalOneYear, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartLine, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1363, 716);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // statisticalMonth
            // 
            this.statisticalMonth.BackColor = System.Drawing.Color.White;
            this.statisticalMonth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statisticalMonth.Location = new System.Drawing.Point(684, 361);
            this.statisticalMonth.Name = "statisticalMonth";
            this.statisticalMonth.Size = new System.Drawing.Size(676, 352);
            this.statisticalMonth.TabIndex = 0;
            this.statisticalMonth.Text = "pieChart1";
            // 
            // statisticalOneYear
            // 
            this.statisticalOneYear.BackColor = System.Drawing.Color.White;
            this.statisticalOneYear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statisticalOneYear.Location = new System.Drawing.Point(3, 361);
            this.statisticalOneYear.Name = "statisticalOneYear";
            this.statisticalOneYear.Size = new System.Drawing.Size(675, 352);
            this.statisticalOneYear.TabIndex = 1;
            this.statisticalOneYear.Text = "cartesianChart1";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.PieStatisticalAll);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(675, 352);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Doanh thu từ trước đến nay";
            // 
            // PieStatisticalAll
            // 
            this.PieStatisticalAll.BackColor = System.Drawing.Color.White;
            this.PieStatisticalAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PieStatisticalAll.Location = new System.Drawing.Point(3, 18);
            this.PieStatisticalAll.Name = "PieStatisticalAll";
            this.PieStatisticalAll.Size = new System.Drawing.Size(669, 331);
            this.PieStatisticalAll.TabIndex = 3;
            this.PieStatisticalAll.Text = "pieChart1";
            // 
            // chartLine
            // 
            chartArea1.Name = "ChartArea1";
            this.chartLine.ChartAreas.Add(chartArea1);
            this.chartLine.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartLine.Legends.Add(legend1);
            this.chartLine.Location = new System.Drawing.Point(684, 3);
            this.chartLine.Name = "chartLine";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Trong 10 năm";
            this.chartLine.Series.Add(series1);
            this.chartLine.Size = new System.Drawing.Size(676, 352);
            this.chartLine.TabIndex = 5;
            this.chartLine.Text = "chart1";
            // 
            // ThongKeDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1363, 716);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ThongKeDoanhThu";
            this.Text = "Thống kê doanh thu";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartLine)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private LiveCharts.WinForms.PieChart statisticalMonth;
        private LiveCharts.WinForms.CartesianChart statisticalOneYear;
        private LiveCharts.WinForms.PieChart PieStatisticalAll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLine;
    }
}