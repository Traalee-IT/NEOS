using System;
using System.Collections.Generic;

using System.Data;
using System.Globalization;
using System.Windows.Forms;

using LiveCharts;
using LiveCharts.Wpf;
using QuanLyKhuTro.DAO;
namespace QuanLyKhuTro.View
{
    public partial class ThongKeDoanhThu : Form
    {

        DateTime currentTime = DateTime.Now;
        public ThongKeDoanhThu()
        {
            InitializeComponent();
            loadChartByMonth();
            StatisticalOneYear();
            loadChartStatisticalAll();
            loadLineChartForTenYear();
        }
        Func<ChartPoint, string> labelPoint = chartPoint => string.Format(CultureInfo.GetCultureInfo("vi-VN"), "{0:C0}", chartPoint.Y);

        private void loadChartByMonth()
        {
            var dataSet = PaymentHistoryDAO.getInstance().StatisticalMonth(currentTime.Month, currentTime.Year);
            SeriesCollection series = new SeriesCollection();

            // Kiểm tra xem dataSet có ít nhất một bảng và ít nhất một cột dữ liệu
            if (dataSet!=null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                // Trích xuất dữ liệu từ bảng đầu tiên của dataSet
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    // Định dạng giá trị thành tiền tệ và bỏ hai số 0 sau dấu thập phân
                    string formattedValue = string.Format(CultureInfo.GetCultureInfo("vi-VN"), "{0:C0}", float.Parse(row[1].ToString()));

                    series.Add(new PieSeries() { Title = row[0].ToString(), Values = new ChartValues<float> { float.Parse(row[1].ToString()) }, DataLabels = true, LabelPoint = chartPoint => formattedValue });
                    statisticalMonth.Series = series;
                }
                // Tạo chú thích (Legend)
                statisticalMonth.LegendLocation = LegendLocation.Top; // Đặt vị trí chú thích bên cạnh biểu đồ
                statisticalMonth.Series = series;
            }
            else
            {
                // Xử lý khi không có dữ liệu
            }
        }

        public void StatisticalOneYear()
        {
            var dataSet = PaymentHistoryDAO.getInstance().ThongKeDoanhThuMotNam(currentTime.Year).Tables[0];

            // Kiểm tra xem dataSet có ít nhất một bảng và ít nhất một cột dữ liệu
            if (dataSet!=null && dataSet.Rows.Count > 0)
            {
                // Tạo SeriesCollection để chứa các loạt dữ liệu
                SeriesCollection seriesCollection = new SeriesCollection();

                // Tạo danh sách nhãn cho trục x (AxisX)
                List<string> labels = new List<string>();

                // Lấy dữ liệu từ bảng và tạo các ColumnSeries
                foreach (DataRow row in dataSet.Rows)
                {
                    // Lấy tên loạt dữ liệu từ cột đầu tiên của bảng
                    string seriesName = row[0].ToString();

                    // Tạo danh sách giá trị từ các cột còn lại của bảng (từ cột thứ 2 trở đi)
                    List<double> values = new List<double>();
                    for (int i = 1; i < dataSet.Columns.Count; i++)
                    {
                        values.Add(Convert.ToDouble(row[i]));
                    }


                    // Định dạng giá trị sang tiền tệ Việt Nam
                    List<string> formattedValues = new List<string>();
                    foreach (double value in values)
                    {
                        formattedValues.Add(value.ToString("C0", new CultureInfo("vi-VN")));
                    }


                    // Tạo ColumnSeries cho mỗi loạt dữ liệu
                    ColumnSeries columnSeries = new ColumnSeries
                    {
                        Title = seriesName,
                        Values = new ChartValues<double>(values),
                        //DataLabels = true
                    };

                    // Thêm ColumnSeries vào SeriesCollection
                    seriesCollection.Add(columnSeries);

                    // Thêm nhãn (label) cho trục x
                    labels.Add(seriesName);
                }

                // Đặt SeriesCollection và AxisX cho biểu đồ cột (ColumnChart)
                statisticalOneYear.Series = seriesCollection;
                statisticalOneYear.AxisX.Add(new Axis
                {
                    Title = "Thống kê doanh thu 12 tháng",
                    // Labels = labels
                });

                statisticalOneYear.AxisY.Add(new Axis
                {

                    LabelFormatter = value => FormatCurrency(value)
                });

            }
            else
            {
                // Xử lý khi không có dữ liệu
            }
        }

        private void loadChartStatisticalAll()
        {
            var dataSet = PaymentHistoryDAO.getInstance().StatisticalAll();
            SeriesCollection series = new SeriesCollection();

            // Kiểm tra xem dataSet có ít nhất một bảng và ít nhất một cột dữ liệu
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                // Tạo chú thích (Legend)
                PieStatisticalAll.LegendLocation = LegendLocation.Top; // Đặt vị trí chú thích bên cạnh biểu đồ
                
                // Lặp qua các dòng trong bảng để thêm dữ liệu vào SeriesCollection
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    string title = row[0].ToString();
                    double value = Convert.ToDouble(row[1]);
                    string formattedValue = string.Format(CultureInfo.GetCultureInfo("vi-VN"), "{0:C0}",value);
                    // Thêm dữ liệu vào SeriesCollection
                    series.Add(new PieSeries
                    {
                        Title = title,
                        Values = new ChartValues<double> { value },
                        DataLabels = true, // Hiển thị nhãn dữ liệu
                        LabelPoint = point => formattedValue // Định dạng nhãn dữ liệu
                    });
                }

                // Gán SeriesCollection cho biểu đồ tròn
                PieStatisticalAll.Series = series;
            }
            else
            {
                // Xử lý khi không có dữ liệu
            }
        }

        private void loadLineChartForTenYear()
        {
            var dataSet = PaymentHistoryDAO.getInstance().StatisticalForTenYear();

            // Xác định số năm và doanh thu tương ứng từ dataSet
            Dictionary<int, decimal> yearlyRevenue = new Dictionary<int, decimal>();

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                int year = Convert.ToInt32(row["Nam"]); // Giả sử cột chứa năm là "Nam"
                decimal revenue = Convert.ToDecimal(row["TongDoanhThu"]); // Giả sử cột chứa tổng doanh thu là "TongDoanhThu"

                yearlyRevenue.Add(year, revenue);
            }

            // Tạo series mới
            var series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "DataSeries",
                Color = System.Drawing.Color.Blue,
                IsVisibleInLegend = false,
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
            };

            // Thêm dữ liệu từ Dictionary vào series
            foreach (var pair in yearlyRevenue)
            {
                series.Points.AddXY(pair.Key, pair.Value);
            }
        //    chartLine.ChartAreas[0].AxisY.LabelStyle.Format = "C0"; // Định dạng theo tiền tệ
            // Thêm series vào biểu đồ
            chartLine.Series.Add(series);
        }

        string FormatCurrency(double value)
        {
            return value.ToString("C0", new CultureInfo("vi-VN"));
        }


    }
}
