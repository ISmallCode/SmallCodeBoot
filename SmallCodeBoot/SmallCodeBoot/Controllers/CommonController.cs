using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmallCodeBoot.Controllers
{
    public class CommonController : Controller
    {
        #region 导出excel
        /// <summary>
        /// 公共导出Execl
        /// </summary>
        public FileResult ExportDateExcel(string fileTitle, Dictionary<string, string> titleObj, DataTable dt)
        {
            HSSFWorkbook workbook;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            string fileName = string.Empty;

            DataTable dtExcel = new DataTable(); //新建一张DataTable将想要的数据倒入新的DataTable中
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                foreach (var item in titleObj)
                {
                    if (dt.Columns[i].ColumnName == item.Key) dtExcel.Columns.Add(item.Value);
                }
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dtExcel.NewRow();

                foreach (var item in titleObj)
                {
                    dr[item.Value] = dt.Rows[i][item.Key].ToString();
                }
                dtExcel.Rows.Add(dr);
            }

            workbook = GetSalaryDetailList(dtExcel, fileTitle);
            workbook.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            fileName = fileTitle + ".xls";

            return File(ms, "application/vnd.ms-excel", fileName);
        }

        /// <summary>
        /// Execl
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public HSSFWorkbook GetSalaryDetailList(DataTable dt, string titleName)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();

            ISheet sheet = workbook.CreateSheet();
            //设置单元格宽度
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sheet.SetColumnWidth(i, 100 * 80);
                }
            }

            #region 樣式

            // 單元格背景色
            Color LevelOneColor = Color.FromArgb(255, 255, 255);
            Color LevelTwoColor = Color.FromArgb(255, 255, 0);
            Color TieleColor = Color.FromArgb(140, 180, 226);

            // 字體樣式
            IFont tfont = workbook.CreateFont();
            tfont.FontHeightInPoints = 10;
            IFont headFont = workbook.CreateFont();
            headFont.FontHeightInPoints = 12;

            // title 字体  小区名称,主标题
            IFont headFontBigtitle = workbook.CreateFont();
            headFontBigtitle.FontHeightInPoints = 16;
            //headFont.Color = HSSFColor.BLACK.index;//顏色
            //headFont.Boldweight = 200;//加粗

            // 表头标题字体
            IFont tableFontBigtitle = workbook.CreateFont();
            tableFontBigtitle.FontHeightInPoints = 14;

            // 表头样式
            HSSFCellStyle cellStyleTableHead = (HSSFCellStyle)workbook.CreateCellStyle();
            cellStyleTableHead.Alignment = HorizontalAlignment.Center;//居中显示
            cellStyleTableHead.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.Red.Index;
            cellStyleTableHead.VerticalAlignment = VerticalAlignment.Center;//垂直居中
            cellStyleTableHead.SetFont(tableFontBigtitle);

            // title 字体  小区名称,主标题
            HSSFCellStyle cellStyleHead = (HSSFCellStyle)workbook.CreateCellStyle();
            cellStyleHead.Alignment = HorizontalAlignment.Center;//居中显示
            cellStyleHead.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.Red.Index;

            //cellStyle1.FillPattern = FillPatternType.BRICKS;//填充模式
            cellStyleHead.VerticalAlignment = VerticalAlignment.Center;//垂直居中
            cellStyleHead.SetFont(headFontBigtitle);
            cellStyleHead.BorderBottom = BorderStyle.Thin;
            cellStyleHead.BorderLeft = BorderStyle.Thin;
            cellStyleHead.BorderRight = BorderStyle.Thin;
            cellStyleHead.BorderTop = BorderStyle.Thin;

            // 表头單元格格式

            // 單元格格式
            HSSFCellStyle cellStyle1 = (HSSFCellStyle)workbook.CreateCellStyle();
            cellStyle1.Alignment = HorizontalAlignment.Center;//居中显示
            cellStyle1.FillBackgroundColor = 244;
            //cellStyle1.FillPattern = FillPatternType.BRICKS;//填充模式
            cellStyle1.VerticalAlignment = VerticalAlignment.Center;//垂直居中
            cellStyle1.SetFont(tfont);

            HSSFCellStyle cellStyle2 = (HSSFCellStyle)workbook.CreateCellStyle();
            cellStyle2.Alignment = HorizontalAlignment.Left;//居中显示
            //cellStyle1.FillBackgroundColor = 244;
            //cellStyle1.FillPattern = FillPatternType.BRICKS;//填充模式
            cellStyle2.VerticalAlignment = VerticalAlignment.Center;//垂直居中
            cellStyle2.SetFont(tfont);

            HSSFCellStyle cellStyle3 = (HSSFCellStyle)workbook.CreateCellStyle();
            cellStyle3.Alignment = HorizontalAlignment.Center;//居中显示
            //cellStyle1.FillBackgroundColor = 244;
            //cellStyle1.FillPattern = FillPatternType.BRICKS;//填充模式
            cellStyle3.VerticalAlignment = VerticalAlignment.Center;//垂直居中
            cellStyle3.BorderBottom = BorderStyle.Thin;
            cellStyle3.BorderLeft = BorderStyle.Thin;
            cellStyle3.BorderRight = BorderStyle.Thin;
            cellStyle3.BorderTop = BorderStyle.Thin;
            cellStyle3.SetFont(tfont);

            HSSFCellStyle cellStyle4 = (HSSFCellStyle)workbook.CreateCellStyle();
            cellStyle4.Alignment = HorizontalAlignment.Center;//居中显示
            //cellStyle1.FillBackgroundColor = 244;
            //cellStyle1.FillPattern = FillPatternType.BRICKS;//填充模式
            cellStyle4.VerticalAlignment = VerticalAlignment.Center;//垂直居中
            cellStyle4.BorderBottom = BorderStyle.Thin;
            cellStyle4.BorderLeft = BorderStyle.Thin;
            cellStyle4.BorderRight = BorderStyle.Thin;
            cellStyle4.BorderTop = BorderStyle.Thin;
            //cellStyle4.FillForegroundColor = CommonFuc.GetXLColour(workbook, LevelOneColor);
            //cellStyle4.FillPattern = NPOI.SS.UserModel.FillPatternType.SOLID_FOREGROUND;
            cellStyle4.SetFont(tfont);

            #endregion

            int ColumnCount = dt.Columns.Count;
            if (dt.Rows.Count > 0)
            {
                // 1 总表头
                IRow titleFirstRow = sheet.CreateRow(sheet.LastRowNum);
                titleFirstRow.HeightInPoints = 30;

                // 1.1 先建立单元格
                for (int i = 0; i < ColumnCount; i++)
                {
                    titleFirstRow.CreateCell(i);
                }

                // 1.3 为表头赋值
                ICell cell = titleFirstRow.Cells[titleFirstRow.FirstCellNum];
                cell.SetCellValue(titleName);

                // 1.2 在合并单元格
                SetCellRangeAddress(sheet, sheet.LastRowNum, sheet.LastRowNum, 0, ColumnCount - 1);

                //给合并的单元格设置样式
                for (int i = 0; i < titleFirstRow.Cells.Count; i++)
                {
                    titleFirstRow.Cells[i].CellStyle = cellStyleHead;
                }

                // 3 添加table抬头
                IRow titleThirdRow = sheet.CreateRow(sheet.LastRowNum + 1);
                // 3.1 设置table表头
                for (int i = 0; i < ColumnCount; i++)
                {
                    DataRow dr = dt.Rows[0];
                    ICell cellHead = titleThirdRow.CreateCell(i);
                    cellHead.SetCellValue(dt.Columns[i].ColumnName);
                    cellHead.CellStyle = cellStyleTableHead;
                }

                // 4 设定表格内容
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    IRow ItemRow = sheet.CreateRow(sheet.LastRowNum + 1);

                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        ICell cellHead = ItemRow.CreateCell(j);
                        cellHead.SetCellValue(dr[j].ToString());
                        cellHead.CellStyle = cellStyle1;
                    }
                }
            }
            else
            {
                // 1 总表头
                IRow titleFirstRow = sheet.CreateRow(sheet.LastRowNum);
                titleFirstRow.HeightInPoints = 30;

                // 1.1 先建立单元格
                for (int i = 0; i < ColumnCount; i++)
                {
                    titleFirstRow.CreateCell(i);
                }

                // 1.3 为表头赋值
                ICell cell = titleFirstRow.Cells[titleFirstRow.FirstCellNum];
                cell.SetCellValue("暂无数据！");

                // 1.2 在合并单元格
                SetCellRangeAddress(sheet, sheet.LastRowNum, sheet.LastRowNum, 0, ColumnCount - 1);

                //给合并的单元格设置样式
                for (int i = 0; i < titleFirstRow.Cells.Count; i++)
                {
                    titleFirstRow.Cells[i].CellStyle = cellStyleHead;
                }

                // 2.2 在合并单元格
                SetCellRangeAddress(sheet, sheet.LastRowNum, sheet.LastRowNum, 0, ColumnCount - 1);
            }

            // 設定保險狀況 單元格寬度
            sheet.SetColumnWidth(10, 14 * 256);

            sheet.DefaultColumnWidth = 10;

            return workbook;
        }

        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="sheet">要合并单元格所在的sheet</param>
        /// <param name="rowstart">开始行的索引</param>
        /// <param name="rowend">结束行的索引</param>
        /// <param name="colstart">开始列的索引</param>
        /// <param name="colend">结束列的索引</param>
        public static void SetCellRangeAddress(ISheet sheet, int rowstart, int rowend, int colstart, int colend)
        {
            CellRangeAddress cellRangeAddress = new CellRangeAddress(rowstart, rowend, colstart, colend);
            sheet.AddMergedRegion(cellRangeAddress);
        }
        #endregion
    }
}