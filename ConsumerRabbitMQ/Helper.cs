using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Consumer;
using Model;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsumerRabbitMQ
{
    class Helper
    {
        private static ApplicationDbContext context = new ApplicationDbContext();

        public static void raporolustur(string islemid, string aranankonum)
        {
            var konum = context.KisiDetayModels.Where(data => data.Konum.Contains(aranankonum)).GroupBy(data => new
            {
                data.KisiID,
                data.Konum
            })
              .Select(grouped => new
              {
                  Key = grouped.Key.Konum,
                  id = grouped.Key.KisiID,
                  Count = grouped.Count()
              }).ToList();

            if (konum != null)
            {
                var ExcelSablon = new List<RaporSonucDTO>();

                foreach (var item in konum)
                {
                    var kisiler = context.KisiModels.Where(data => data.Id.Equals(item.id)).ToList();
                    if (kisiler != null && kisiler.Count > 0)
                    {
                        var data = new RaporSonucDTO();
                        data.Adi = kisiler[0].Adi;
                        data.Soyadi = kisiler[0].Soyadi;
                        data.Firma = kisiler[0].Firma;
                        data.Konum = aranankonum;
                        data.RehberdeKayitliTelefonSayisi = item.Count;
                        data.RehberdekiKayitliKisiSayisi = kisiler.Count;
                        ExcelSablon.Add(data);
                    }
                }
                ExcelExport(islemid, ExcelSablon);
            }

        }

        static void ExcelExport(string islemid, List<RaporSonucDTO> exceldata)
        {
            XLWorkbook workbook = new XLWorkbook();
            DataTable dt = new DataTable() { TableName = "Rise Rapor by Arif Özbey" };
            DataSet ds = new DataSet();

            //input data
            var columns = new[] { "RehberdeKayitliTelefonSayisi", "RehberdekiKayitliKisiSayisi", "Konum" };

            List<object[]> rowCollection = new List<object[]>();
            foreach (var item in exceldata)
            {
                rowCollection.Add(new object[] { item.RehberdeKayitliTelefonSayisi, item.RehberdekiKayitliKisiSayisi, item.Konum });

            }


            //Add columns
            dt.Columns.AddRange(columns.Select(c => new DataColumn(c)).ToArray());

            //Add rows
            foreach (var row in rowCollection)
            {
                dt.Rows.Add(row);
            }

            //Convert datatable to dataset and add it to the workbook as worksheet
            ds.Tables.Add(dt);
            workbook.Worksheets.Add(ds);

            //save
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string savePath = Path.Combine(desktopPath, DateTime.Now.Millisecond.ToString() + "test.xlsx");
            workbook.SaveAs(savePath, false);

            //Durum Güncellemesi

            var raporguncelle = context.RaporModels.FirstOrDefault(x => x.Id == new Guid(islemid));
            raporguncelle.Durumu = (int)RaporDurum.Tamamlandi;
            raporguncelle.Dosyapath = savePath;
            context.RaporModels.Update(raporguncelle);
            context.SaveChanges();

            //Durum güncellemesi bitiş
        }
    }
}
