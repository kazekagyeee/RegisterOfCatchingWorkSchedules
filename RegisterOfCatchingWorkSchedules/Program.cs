using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegisterOfCatchingWorkSchedules
{
    internal static class Program
    {
        public static RegisterDBContext DBContext;
        public static Session Session;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DBContext = new RegisterDBContext();
            Session = new Session();

            //var tmn = DBContext.Municipality.Add(new Municipality() { MunicipalityName = "Тюмень" });
            //DBContext.Municipality.Add(new Municipality() { MunicipalityName = "Тобольск" });
            //DBContext.Municipality.Add(new Municipality() { MunicipalityName = "Ишим" });

            //         for (int i = 1; i <= 6; i++)
            //             tmn.Places.Add(new Places() { PlacesName = $"{i} мкр" });

            //var tmn = DBContext.Municipality.Single(x => x.ID == 1);
            //         var str = "Автоград Антипино Бабарынка Березняковский Богандинский Б.Тараскуль Букино Быкова Ватутина Верхний_Бор Войновка Воровского Воронино Восточный Гилево Гилевское Кольцо Гольф-палас Городище Дербыши ДОК Дом_Обороны Дударева Завод_медоборудования Зайково Зарека Заречный Затюменка Казарово Княжева Комарово Копытово КПД Матмасы Маяк Метелева МЖК ММС Московский дворик Московский_п. Московский_тр. М.Тараскуль Мыс Нобель Ново-Патрушево Ожогина Очаково Парфеново Патрушева Патрушево Плеханово Привоз Промзона Утешево Рабочий_поселок Рощино РТС СМП Стрела Суходолье Тараскуль Тарманы Тура_(Лесобаза) ТЭЦ_1 Тюменская слобода Утешево Учхоз Центр Червишевский_тр. Электрон Югра Южный_мкр Ялуторовского_тр.,_11_км Ямальский-2 Ямальский_мкр";
            //         var places = str.Split(' ');
            //         foreach (var place in places)
            //         {
            //	tmn.Places.Add(new Places() { PlacesName = place.Replace('_', ' ') });
            //}

            DBContext.SaveChanges();


            Application.Run(new MainForm());
        }
    }
}
