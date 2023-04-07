using ClosedXML.Excel;
using Diplom_Storage.AppData;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Diplom_Storage.AllPage
{
    /// <summary>
    /// Логика взаимодействия для PageReport.xaml
    /// </summary>
    public partial class PageReport : Page
    {
        DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
        public PageReport()
        {
            InitializeComponent();
            List<string> reportOptions = new List<string>()
    {
        "Склад",
        "Бракованный товар",
        "Заказы",
        "Ревизия",
        "Приемка"
    };
            ReportChange.ItemsSource = reportOptions;
        }

        private void CreateReport_Click(object sender, RoutedEventArgs e)
        {
            var selectedValue = (string)ReportChange.SelectedItem;
            switch (selectedValue)
            {
                case "Склад":
                    var query = from p in context.Product
                                join s in context.SKLAD on p.ID_PROD equals s.Product_ID
                                join c in context.Category on p.Category_ID equals c.ID_Catregory
                                select new { ID = s.ID_SKLAD, Название = p.Name, Количество = s.Kolvo, Категория = c.Name, };
                    OperTabl.AutoGenerateColumns = false;
                    OperTabl.Columns.Clear();
                    OperTabl.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("ID") });
                    OperTabl.Columns.Add(new DataGridTextColumn { Header = "Название", Binding = new Binding("Название") });
                    OperTabl.Columns.Add(new DataGridTextColumn { Header = "Категория", Binding = new Binding("Категория") });
                    OperTabl.Columns.Add(new DataGridTextColumn { Header = "Количество", Binding = new Binding("Количество") });
                    OperTabl.ItemsSource = query.ToList();
                    var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("Склад");
                    worksheet.Cell(1, 1).Value = "ID";
                    worksheet.Cell(1, 2).Value = "Название";
                    worksheet.Cell(1, 3).Value = "Категория";
                    worksheet.Cell(1, 4).Value = "Количество";
                    worksheet.Range("A1:D1").Style.Font.Bold = true;
                    var row = 2;
                    foreach (var item in query)
                    {
                        worksheet.Cell(row, 1).Value = item.ID;
                        worksheet.Cell(row, 2).Value = item.Название;
                        worksheet.Cell(row, 3).Value = item.Категория;
                        worksheet.Cell(row, 4).Value = item.Количество;
                        row++;
                    }
                    worksheet.Range("A1:D" + row).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    worksheet.Columns().AdjustToContents();
                    var saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveFileDialog.DefaultExt = ".xlsx";
                    saveFileDialog.FileName = selectedValue + ".xlsx";
                    if (saveFileDialog.ShowDialog() == true)
                    {
                        workbook.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Отчет был успешно создан и сохранен в " + saveFileDialog.FileName);
                    }
                    break;
                case "Бракованный товар":
                    var query1 = from b in context.BRAK
                                join p in context.Product on b.Product_ID equals p.ID_PROD
                                join u in context.users on b.USER_ID equals u.ID_USERS
                                join s in context.Status on b.Status_ID equals s.ID_STATUS
                                select new { ID = b.ID_BRAK, Дата = b.DataOtgruz, Товар = p.Name, Статус = s.name, Количество = b.quanity, Ответственный = u.login };
                    OperTabl.AutoGenerateColumns = false;
                    OperTabl.Columns.Clear();
                    OperTabl.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("ID") });
                    OperTabl.Columns.Add(new DataGridTextColumn { Header = "Дата", Binding = new Binding("Дата") { StringFormat = "yyyy.MM.dd" } });
                    OperTabl.Columns.Add(new DataGridTextColumn { Header = "Товар", Binding = new Binding("Товар") });
                    OperTabl.Columns.Add(new DataGridTextColumn { Header = "Количество", Binding = new Binding("Количество") });
                    OperTabl.Columns.Add(new DataGridTextColumn { Header = "Статус", Binding = new Binding("Статус") });
                    OperTabl.Columns.Add(new DataGridTextColumn { Header = "Ответственный", Binding = new Binding("Ответственный") });
                    OperTabl.ItemsSource = query1.ToList();
                    var workbook1 = new XLWorkbook();
                    var worksheet1 = workbook1.Worksheets.Add("Бракованный товар");
                    worksheet1.Cell(1, 1).Value = "ID";
                    worksheet1.Cell(1, 2).Value = "Дата";
                    worksheet1.Cell(1, 3).Value = "Товар";
                    worksheet1.Cell(1, 4).Value = "Статус";
                    worksheet1.Cell(1, 5).Value = "Количество";
                    worksheet1.Cell(1, 6).Value = "Ответственный";
                    worksheet1.Range("A1:F1").Style.Font.Bold = true;
                    var row1 = 2;
                    foreach (var item in query1)
                    {
                        worksheet1.Cell(row1, 1).Value = item.ID;
                        worksheet1.Cell(row1, 2).Value = item.Дата;
                        worksheet1.Cell(row1, 3).Value = item.Товар;
                        worksheet1.Cell(row1, 4).Value = item.Статус;
                        worksheet1.Cell(row1, 5).Value = item.Количество;
                        worksheet1.Cell(row1, 6).Value = item.Ответственный;
                        row1++;
                    }
                    worksheet1.Range("A1:F" + row1).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    worksheet1.Columns().AdjustToContents();
                    var saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel files (.xlsx)|.xlsx|All files (.)|.";
                    saveFileDialog1.DefaultExt = ".xlsx";
                    saveFileDialog1.FileName = selectedValue + ".xlsx";
                    if (saveFileDialog1.ShowDialog() == true)
                    {
                        workbook1.SaveAs(saveFileDialog1.FileName);
                        MessageBox.Show("Отчет был успешно создан и сохранен в " + saveFileDialog1.FileName);
                    }
                    break;
                case "Заказы":
                    var zakazi = from z in context.Zakaz
                                 join p in context.Product on z.ProductID equals p.ID_PROD
                                 select new { ID = z.ID_Zakaz, Товар = p.Name, Количество = z.Kolvo };
                    OperTabl.AutoGenerateColumns = false;
                    OperTabl.Columns.Clear();
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "ID", Binding = new Binding("ID") });
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Товар", Binding = new Binding("Товар") });
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Количество", Binding = new Binding("Количество") });
                    OperTabl.ItemsSource = zakazi.ToList();
                    var workbook2 = new XLWorkbook();
                    var worksheet2 = workbook2.Worksheets.Add("Заказы");
                    worksheet2.Cell(1, 1).Value = "ID";
                    worksheet2.Cell(1, 2).Value = "Товар";
                    worksheet2.Cell(1, 3).Value = "Количество";
                    worksheet2.Range("A1:C1").Style.Font.Bold = true;
                    var row2 = 2;
                    foreach (var item in zakazi)
                    {
                        worksheet2.Cell(row2, 1).Value = item.ID;
                        worksheet2.Cell(row2, 2).Value = item.Товар;
                        worksheet2.Cell(row2, 3).Value = item.Количество;
                        row2++;
                    }
                    worksheet2.Range("A1:C" + row2).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    worksheet2.Columns().AdjustToContents();
                    var saveFileDialog2 = new SaveFileDialog();
                    saveFileDialog2.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveFileDialog2.DefaultExt = ".xlsx";
                    saveFileDialog2.FileName = selectedValue + ".xlsx";
                    if (saveFileDialog2.ShowDialog() == true)
                    {
                        workbook2.SaveAs(saveFileDialog2.FileName);
                        MessageBox.Show("Отчет был успешно создан и сохранен в " + saveFileDialog2.FileName);
                    }
                    break;
                case "Ревизия":
                    var revizQuery = from s in context.stock_operations
                                     join o in context.stock_operation_types on s.operation_type_ID equals o.ID_OPTYPE
                                     join p in context.Product on s.product_id equals p.ID_PROD
                                     group s by new { s.operation_type_ID, p.Name, o.name } into g
                                     select new
                                     {
                                         ID = g.Key.operation_type_ID,
                                         Тип = g.Key.name,
                                         Товар = g.Key.Name,
                                         Количество = g.Sum(s => s.quantity)
                                     };

                    OperTabl.AutoGenerateColumns = false;
                    OperTabl.Columns.Clear();
                    OperTabl.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("ID") });
                    OperTabl.Columns.Add(new DataGridTextColumn { Header = "Товар", Binding = new Binding("Товар") });
                    OperTabl.Columns.Add(new DataGridTextColumn { Header = "Тип", Binding = new Binding("Тип") });
                    OperTabl.Columns.Add(new DataGridTextColumn { Header = "Количество", Binding = new Binding("Количество") });
                    OperTabl.ItemsSource = revizQuery.ToList();

                    var workbook3 = new XLWorkbook();
                    var worksheet3 = workbook3.Worksheets.Add("Ревизия");
                    worksheet3.Cell(1, 1).Value = "ID";
                    worksheet3.Cell(1, 2).Value = "Товар";
                    worksheet3.Cell(1, 3).Value = "Тип";
                    worksheet3.Cell(1, 4).Value = "Количество";
                    worksheet3.Range("A1:D1").Style.Font.Bold = true;
                    var row3 = 2;
                    foreach (var item in revizQuery)
                    {
                        worksheet3.Cell(row3, 1).Value = item.ID;
                        worksheet3.Cell(row3, 2).Value = item.Товар;
                        worksheet3.Cell(row3, 3).Value = item.Тип;
                        worksheet3.Cell(row3, 4).Value = item.Количество;
                        row3++;
                    }
                    worksheet3.Range("A1:D" + row3).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    worksheet3.Columns().AdjustToContents();

                    var saveFileDialog3 = new SaveFileDialog();
                    saveFileDialog3.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveFileDialog3.DefaultExt = ".xlsx";
                    saveFileDialog3.FileName = selectedValue + ".xlsx";
                    if (saveFileDialog3.ShowDialog() == true)
                    {
                        workbook3.SaveAs(saveFileDialog3.FileName);
                        MessageBox.Show("Отчет был успешно создан и сохранен в " + saveFileDialog3.FileName);
                    }
                    break;
                case "Приемка":
                    var primy = from s in context.stock_operations
                                join o in context.stock_operation_types on s.operation_type_ID equals o.ID_OPTYPE
                                join p in context.Product on s.product_id equals p.ID_PROD
                                join u in context.users on s.user_id equals u.ID_USERS
                                where o.ID_OPTYPE == 1
                                select new { ID = s.ID_STOKOP, Дата = s.operation_date, Товар = p.Name, Тип = o.name, Количество = s.quantity, Ответственный = u.login };
                    OperTabl.Columns.Clear();
                    OperTabl.AutoGenerateColumns = false;
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "ID", Binding = new Binding("ID") });
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Дата", Binding = new Binding("Дата") { StringFormat = "yyyy.MM.dd" } });
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Тип", Binding = new Binding("Тип") });
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Товар", Binding = new Binding("Товар") });
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Количество", Binding = new Binding("Количество") });
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Ответственный", Binding = new Binding("Ответственный") });
                    OperTabl.ItemsSource = primy.ToList();
                    var workbook4 = new XLWorkbook();
                    var worksheet4 = workbook4.Worksheets.Add("Приемка");
                    worksheet4.Cell(1, 1).Value = "ID";
                    worksheet4.Cell(1, 2).Value = "Дата";
                    worksheet4.Cell(1, 3).Value = "Тип";
                    worksheet4.Cell(1, 4).Value = "Товар";
                    worksheet4.Cell(1, 5).Value = "Количество";
                    worksheet4.Cell(1, 6).Value = "Ответственный";
                    worksheet4.Range("A1:F1").Style.Font.Bold = true;
                    var row4 = 2;
                    foreach (var item in primy)
                    {
                        worksheet4.Cell(row4, 1).Value = item.ID;
                        worksheet4.Cell(row4, 2).Value = item.Дата;
                        worksheet4.Cell(row4, 3).Value = item.Тип;
                        worksheet4.Cell(row4, 4).Value = item.Товар;
                        worksheet4.Cell(row4, 5).Value = item.Количество;
                        worksheet4.Cell(row4, 6).Value = item.Ответственный;
                        row4++;
                    }
                    worksheet4.Range("A1:F" + row4).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    worksheet4.Columns().AdjustToContents();

                    var saveFileDialog4 = new SaveFileDialog();
                    saveFileDialog4.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveFileDialog4.DefaultExt = ".xlsx";
                    saveFileDialog4.FileName = selectedValue + ".xlsx";
                    if (saveFileDialog4.ShowDialog() == true)
                    {
                        workbook4.SaveAs(saveFileDialog4.FileName);
                        MessageBox.Show("Отчет был успешно создан и сохранен в " + saveFileDialog4.FileName);
                    }

                    break;
                case "Отгрузка":
                    var otguzy = from s in context.stock_operations
                                 join o in context.stock_operation_types on s.operation_type_ID equals o.ID_OPTYPE
                                 join p in context.Product on s.product_id equals p.ID_PROD
                                 join u in context.users on s.user_id equals u.ID_USERS
                                 where o.ID_OPTYPE == 2
                                 select new { ID = s.ID_STOKOP, Дата = s.operation_date, Товар = p.Name, Тип = o.name, Количество = s.quantity, Ответственный = u.login };
                    OperTabl.AutoGenerateColumns = false;
                    OperTabl.Columns.Clear();
                    OperTabl.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("ID") });
                    OperTabl.Columns.Add(new DataGridTextColumn { Header = "Дата", Binding = new Binding("Дата") { StringFormat = "yyyy.MM.dd" } });
                    OperTabl.Columns.Add(new DataGridTextColumn { Header = "Тип", Binding = new Binding("Тип") });
                    OperTabl.Columns.Add(new DataGridTextColumn { Header = "Товар", Binding = new Binding("Товар") });
                    OperTabl.Columns.Add(new DataGridTextColumn { Header = "Количество", Binding = new Binding("Количество") });
                    OperTabl.Columns.Add(new DataGridTextColumn { Header = "Ответственный", Binding = new Binding("Ответственный") });
                    OperTabl.ItemsSource = otguzy.ToList();
                    var workbook5 = new XLWorkbook();
                    var worksheet5 = workbook5.Worksheets.Add("Отгрузка");
                    worksheet5.Cell(1, 1).Value = "ID";
                    worksheet5.Cell(1, 2).Value = "Дата";
                    worksheet5.Cell(1, 3).Value = "Тип";
                    worksheet5.Cell(1, 4).Value = "Товар";
                    worksheet5.Cell(1, 5).Value = "Количество";
                    worksheet5.Cell(1, 6).Value = "Ответственный";
                    worksheet5.Range("A1:F1").Style.Font.Bold = true;
                    var row5 = 2;
                    foreach (var item in otguzy)
                    {
                        worksheet5.Cell(row5, 1).Value = item.ID;
                        worksheet5.Cell(row5, 2).Value = item.Дата;
                        worksheet5.Cell(row5, 3).Value = item.Тип;
                        worksheet5.Cell(row5, 4).Value = item.Товар;
                        worksheet5.Cell(row5, 5).Value = item.Количество;
                        worksheet5.Cell(row5, 6).Value = item.Ответственный;
                        row5++;
                    }
                    worksheet5.Range("A1:F" + row5).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    worksheet5.Columns().AdjustToContents();
                    var saveFileDialog5 = new SaveFileDialog();
                    saveFileDialog5.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveFileDialog5.DefaultExt = ".xlsx";
                    saveFileDialog5.FileName = selectedValue + ".xlsx";
                    if (saveFileDialog5.ShowDialog() == true)
                    {
                        workbook5.SaveAs(saveFileDialog5.FileName);
                        MessageBox.Show("Отчет был успешно создан и сохранен в " + saveFileDialog5.FileName);
                    }
                    break;
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
         {
    
        }

        private void OperTabl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ReportChange_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedValue = (string)ReportChange.SelectedItem;
            switch (selectedValue)
            {
                case "Склад":
                    var query = from p in context.Product
                                join s in context.SKLAD on p.ID_PROD equals s.Product_ID
                                join c in context.Category on p.Category_ID equals c.ID_Catregory
                                select new { ID = s.ID_SKLAD, Название = p.Name, Количество = s.Kolvo, Категория = c.Name, };
                    OperTabl.AutoGenerateColumns = false;
                    OperTabl.Columns.Clear();
                    OperTabl.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("ID") });
                    OperTabl.Columns.Add(new DataGridTextColumn { Header = "Название", Binding = new Binding("Название") });
                    OperTabl.Columns.Add(new DataGridTextColumn { Header = "Категория", Binding = new Binding("Категория") });
                    OperTabl.Columns.Add(new DataGridTextColumn { Header = "Количество", Binding = new Binding("Количество") });
                    OperTabl.ItemsSource = query.ToList();
                    break;
                case "Бракованный товар":
                    var btrok = from b in context.BRAK
                                join p in context.Product on b.Product_ID equals p.ID_PROD
                                join u in context.users on b.USER_ID equals u.ID_USERS
                                join s in context.Status on b.Status_ID equals s.ID_STATUS
                                select new { ID = b.ID_BRAK, Дата = b.DataOtgruz, Товар = p.Name, Статус = s.name, Количество = b.quanity, Ответственный = u.login };
                    OperTabl.AutoGenerateColumns = false;
                    OperTabl.Columns.Clear();
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "ID", Binding = new Binding("ID") });
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Дата", Binding = new Binding("Дата") { StringFormat = "yyyy.MM.dd" } });
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Товар", Binding = new Binding("Товар") });
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Количество", Binding = new Binding("Количество") });
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Статус", Binding = new Binding("Статус") });
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Ответственный", Binding = new Binding("Ответственный") });
                    OperTabl.ItemsSource = btrok.ToList();
                    break;
                case "Заказы":
                    var zakazi = from z in context.Zakaz
                                join p in context.Product on z.ProductID equals p.ID_PROD
                                select new { ID = z.ID_Zakaz, Товар = p.Name, Количество = z.Kolvo };
                    OperTabl.AutoGenerateColumns = false;
                    OperTabl.Columns.Clear();
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "ID", Binding = new Binding("ID") });
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Товар", Binding = new Binding("Товар") });
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Количество", Binding = new Binding("Количество") });
                    OperTabl.ItemsSource = zakazi.ToList();
                    break;
                case "Ревизия":
                    var reviz = from s in context.stock_operations
                                join o in context.stock_operation_types on s.operation_type_ID equals o.ID_OPTYPE
                                join p in context.Product on s.product_id equals p.ID_PROD
                                group s by new { s.operation_type_ID, p.Name, o.name } into g
                                select new
                                {
                                    ID = g.Key.operation_type_ID,
                                    Тип = g.Key.name,
                                    Товар = g.Key.Name,
                                    Количество = g.Sum(s => s.quantity)
                                };
                    OperTabl.AutoGenerateColumns = false;
                    OperTabl.Columns.Clear();
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "ID", Binding = new Binding("ID") });
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Товар", Binding = new Binding("Товар") });
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Тип", Binding = new Binding("Тип") });
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Количество", Binding = new Binding("Количество") });
                    OperTabl.ItemsSource = reviz.ToList();
                    break;
                case "Приемка":

                    var primy = from s in context.stock_operations
                                join o in context.stock_operation_types on s.operation_type_ID equals o.ID_OPTYPE
                                join p in context.Product on s.product_id equals p.ID_PROD
                                join u in context.users on s.user_id equals u.ID_USERS
                                where o.ID_OPTYPE == 1
                                select new { ID = s.ID_STOKOP, Дата = s.operation_date, Товар = p.Name, Тип = o.name, Количество = s.quantity, Ответственный = u.login };
                    OperTabl.Columns.Clear();
                    OperTabl.AutoGenerateColumns = false;
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "ID", Binding = new Binding("ID") });
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Дата", Binding = new Binding("Дата") { StringFormat = "yyyy.MM.dd" } });
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Тип", Binding = new Binding("Тип") });
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Товар", Binding = new Binding("Товар") });
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Количество", Binding = new Binding("Количество") });
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Ответственный", Binding = new Binding("Ответственный") });
                    OperTabl.ItemsSource = primy.ToList();

                    break;
                case "Отгрузка":
                    var otguzy = from s in context.stock_operations
                                join o in context.stock_operation_types on s.operation_type_ID equals o.ID_OPTYPE
                                join p in context.Product on s.product_id equals p.ID_PROD
                                join u in context.users on s.user_id equals u.ID_USERS
                                where o.ID_OPTYPE == 2
                                select new { ID = s.ID_STOKOP, Дата = s.operation_date, Товар = p.Name, Тип = o.name, Количество = s.quantity, Ответственный = u.login };
                    OperTabl.AutoGenerateColumns = false;
                    OperTabl.Columns.Clear();
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "ID", Binding = new Binding("ID") });
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Дата", Binding = new Binding("Дата") { StringFormat = "yyyy.MM.dd" } });
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Тип", Binding = new Binding("Тип") });
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Товар", Binding = new Binding("Товар") });
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Количество", Binding = new Binding("Количество") });
                    OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Ответственный", Binding = new Binding("Ответственный") });
                    OperTabl.ItemsSource = otguzy.ToList();
                    break;
                default:
                    break;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
