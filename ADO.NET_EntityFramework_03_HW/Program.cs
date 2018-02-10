using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ADO.NET_EntityFramework_03_HW.CreateDataBase;
using ADO.NET_EntityFramework_03_HW.GetDataFromEquipmentAndMore;

namespace ADO.NET_EntityFramework_03_HW
{
    class Program
    {
        private static MCS db = new MCS();
        private static MCSContainer DB = new MCSContainer();

        static void Main(string[] args)
        {


            start:
            Console.Clear();
            Console.WriteLine("1 - Первая часть задания\n2 - Вторая часть задания\n3 - Exit");
            var option = 3;
            int.TryParse(Console.ReadLine(), out option);
            switch (option)
            {
                case 1:
                    {
                        Console.WriteLine("Прежде чем что-то запускать...\nСначала подумайте , а надо ли это вам?!\nТак как эта часть для программиста который разбирается в си шарпе , а не для обычного пользователя)");
                        #region Раскоментируйте при первичном запуске программы!
                        //var getEquipment = db.newEquipments.Select(s => new
                        //{
                        //    s.intGarageRoom,
                        //    s.intManufacturerID,
                        //    s.strManufYear,
                        //    s.intSNPrefixID,
                        //    s.intModelID
                        //}).ToList();
                        //var getManufactures = db.TablesManufacturers.Select(s => new
                        //{
                        //    s.intManufacturerID,s.strName,s.strManufacturerChecklistId
                        //}).OrderBy(o=>o.intManufacturerID).ToList();
                        //foreach (var item in getManufactures)
                        //{
                        //    Manufacturer m= new Manufacturer();
                        //    m.strName = item.strName;
                        //    m.ManufacturerDescription = item.strManufacturerChecklistId;
                        //    DB.ManufacturerSet.Add(m);
                        //    DB.SaveChanges();
                        //}
                        //var getModels = db.TablesModels.Select(s => new
                        //{
                        //    s.intManufacturerID,
                        //    s.strName
                        //}).ToList();
                        //foreach (var item in getModels)
                        //{
                        //    Model m = new Model();
                        //    m.intManufacturerID = item.intManufacturerID;
                        //    m.strName = item.strName;
                        //    DB.ModelSet.Add(m);
                        //    DB.SaveChanges();
                        //}
                        //try
                        //{
                        //    foreach (var item in getEquipment)
                        //    {
                        //        Equipment e = new Equipment
                        //        {
                        //            intGarageRoom = item.intGarageRoom,
                        //            Manufacturer_intManufacturerID = item.intManufacturerID,
                        //            strManufYear = item.strManufYear,
                        //            intSNPrefixId = item.intSNPrefixID,
                        //            ModelModelId = item.intModelID
                        //        };
                        //        DB.EquipmentSet.Add(e);
                        //        DB.SaveChanges();
                        //    }
                        //    Console.WriteLine("Данные были выгружены в другую табличку успешно!");
                        //}
                        //catch (Exception e)
                        //{
                        //    // Console.WriteLine(e);
                        //    Console.WriteLine("Данные были выгружены в другую табличку успешно!");
                        //}

                        #endregion
                        Console.ReadLine();
                        goto start;
                    }

                case 2:
                    {
                        Console.WriteLine("Чтобы прислать вам письмо введите почтовый ящик от почты gmail.com\n" +
                                          "Example : mygmail.@gmail.com");
                        string to = Console.ReadLine();
                        string caption = "ChangesWithData";
                        string log = "csharp.sdp.162@gmail.com";
                        string passw = "sdp123456789";
                        string messageForMaster = "Мастер! Прикиньте , сообщения то отправляются!!)";
                        string message = "Changes_with_data может быть)))\nПросто наверное какие изменения или нет, просто отправляется письмо тебе)";
                        if (!string.IsNullOrEmpty(to) && !string.IsNullOrEmpty(caption) && !string.IsNullOrEmpty(message) &&to.Contains('@'))
                            SendMail(@"smtp.gmail.com", log, passw, to, caption,
                                message, null);
                        else
                        {
                            Console.WriteLine("Хэй), вы что-то заполнили пустым или не указали свой правильный почтовый ящик!!)");
                            Console.ReadLine();
                            goto start;
                        }
                    }
                    break;
                case 3: { break; }

            }

        }

        public static void SendMail(string smtpServer, string from, string password,
            string mailto, string caption, string message, string attachFile = null)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(new MailAddress(mailto));
                mail.Subject = caption;
                mail.Body = message;
                if (!string.IsNullOrEmpty(attachFile))
                    mail.Attachments.Add(new Attachment(attachFile));
                SmtpClient client = new SmtpClient();
                client.Host = smtpServer;
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(from.Split('@')[0], password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                Console.WriteLine("Сообщение отправлено успешно на ваш почтовый ящик!");
                mail.Dispose();

            }
            catch (Exception e)
            {
                throw new Exception("Mail.Send: " + e.Message);
            }
        }

    }
}
