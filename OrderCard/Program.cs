namespace OrderCard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string law, identifying, number, objects, requester, cost, dateStart, dateEnd, place, placeUrl, postAddress, location, responsible, email, phone, fax;
            byte[] bytes;

            while (true)
            {
                try
                {
                    using HttpClient httpClient = new();
                    bytes = httpClient.GetByteArrayAsync(requestUri).Result;

                    break;
                }
                catch (Exception) { }
            }

            string input = Encoding.UTF8.GetString(bytes);

            law = Law.GetString(input);
            identifying = Identifying.GetString(input);
            number = Number.GetString(input);
            objects = Objects.GetString(input);
            requester = Requester.GetString(input);
            cost = Cost.GetString(input);
            dateStart = DateStart.GetString(input);
            dateEnd = DateEnd.GetString(input);
            place = Place.GetString(input);
            placeUrl = PlaceUrl.GetString(input);
            postAddress = PostAddress.GetString(input);
            location = Location.GetString(input);
            responsible = Responsible.GetString(input);
            email = Email.GetString(input);
            phone = Phone.GetString(input);
            fax = Fax.GetString(input);

            Console.WriteLine($"Закон: {law}\n" +
                $"Способ определения поставщика (подрядчика, исполнителя): {identifying}\n" +
                $"# {number}\n" +
                $"Объект закупки: {objects}\n" +
                $"Заказчик: {requester}\n" +
                $"Начальная цена: {cost}\n" +
                $"Дата и время начала срока подачи заявок: {dateStart}\n" +
                $"Дата и время окончания срока подачи заявок: {dateEnd}\n" +
                $"Наименование электронной площадки в информационно-телекоммуникационной сети \"Интернет\": {place}\n" +
                $"Адрес электронной площадки в информационно-телекоммуникационной сети \"Интернет\": {placeUrl}\n" +
                $"Почтовый адрес: {postAddress}\n" +
                $"Место нахождения: {location}\n" +
                $"Ответственное должностное лицо: {responsible}\n" +
                $"Адрес электронной почты: {email}\n" +
                $"Номер контактного телефона: {phone}\n" +
                $"Факс: {fax}");
        }
    }

    public sealed class Law
    {
        static readonly Regex regex = new(@"<div class=""cardMainInfo__title d-flex text-truncate""\n(?<space>.*?)\n(?<space>.*?)>(?<val>.*?)\n(?<space>.*?)</div>", options);

        public static string GetString(string input)
        {
            string value;
            value = regex.Split(input)[2];
            return value;
        }
    }

    public sealed class Identifying
    {
        static readonly Regex regex = new(@"<span class=""cardMainInfo__title distancedText ml-1"">\n                            (?<val>.*?)\n(?<space>.*?)</span>", options);

        public static string GetString(string input)
        {
            string value;
            value = regex.Split(input)[1];
            return value;
        }
    }

    public sealed class Number
    {
        static readonly Regex regex = new(@"<a href=""#"" target=""_blank"">№ (?<val>.*?)</a>", options);

        public static string GetString(string input)
        {
            string value;
            value = regex.Split(input)[1];
            return value;
        }
    }

    public sealed class Objects
    {
        static readonly Regex regex = new(@"<span class=""cardMainInfo__content"">(?<val>.*?)</span>", options);

        public static string GetString(string input)
        {
            string value;
            value = regex.Split(input)[1];
            return value;
        }
    }

    public sealed class Requester
    {
        static readonly Regex regex = new(@"<a href=""https://zakupki.gov.ru/epz/organization(?<space>.*?)"" target=""_blank"">(?<val>.*?)</a>", options);

        public static string GetString(string input)
        {
            string value;
            value = regex.Split(input)[2];
            return value;
        }
    }

    public sealed class Cost
    {
        static readonly Regex regex = new(@"<span class=""cardMainInfo__content cost"">\n                        (?<val>.*?) &#8381;", options);

        public static string GetString(string input)
        {
            string value;
            value = regex.Split(input)[1];
            return value;
        }
    }

    public sealed class Place
    {
        static readonly Regex regex = new(@"Наименование электронной площадки(?<space>.*?)</span>(?<space>.*?)>(?<val>.*?)<", options);

        public static string GetString(string input)
        {
            string value;
            value = regex.Split(input)[2];
            return value;
        }
    }

    public sealed class PlaceUrl
    {
        static readonly Regex regex = new(@"Адрес электронной площадки(?<space>.*?)</span>(?<space>.*?)href=""(?<val>.*?)""", options);

        public static string GetString(string input)
        {
            string value;
            value = regex.Split(input)[2];
            return value;
        }
    }

    public sealed class PostAddress
    {
        static readonly Regex regex = new(@"Почтовый адрес</span>(?<space>.*?)\n                    (?<val>.*?)\n", options);

        public static string GetString(string input)
        {
            string value;
            value = regex.Split(input)[2];
            return value;
        }
    }

    public sealed class Location
    {
        static readonly Regex regex = new(@"Место нахождения</span>(?<space>.*?)\n                    (?<val>.*?)\n", options);

        public static string GetString(string input)
        {
            string value;
            value = regex.Split(input)[2];
            return value;
        }
    }

    public sealed class Responsible
    {
        static readonly Regex regex = new(@"Ответственное должностное лицо</span>(?<space>.*?)\n                    (?<val>.*?)<", options);

        public static string GetString(string input)
        {
            string value;
            value = regex.Split(input)[2];
            return value;
        }
    }

    public sealed class Email
    {
        static readonly Regex regex = new(@"Адрес электронной почты</span>(?<space>.*?)                        (?<val>.*?)\n", options);

        public static string GetString(string input)
        {
            string value;
            value = regex.Split(input)[2];
            return value;
        }
    }

    public sealed class Phone
    {
        static readonly Regex regex = new(@"Номер контактного телефона</span>(?<space>.*?)                    (?<val>.*?)\n", options);

        public static string GetString(string input)
        {
            string value;
            value = regex.Split(input)[2];
            return value;
        }
    }

    public sealed class Fax
    {
        static readonly Regex regex = new(@"Факс</span>(?<space>.*?)>(?<val>.*?)<", options);

        public static string GetString(string input)
        {
            string value;
            value = regex.Split(input)[2];
            return value;
        }
    }

    public sealed class DateStart
    {
        static readonly Regex regex = new(@"Дата и время начала срока подачи заявок</span>(?<space>.*?)\n                    (?<valFirst>.*?) <span(?<space>.*?)>(?<valSecond>.*?)</span>", options);

        public static string GetString(string input)
        {
            string value;
            value = $"{regex.Split(input)[2]} {regex.Split(input)[3]}";
            return value;
        }
    }

    public sealed class DateEnd
    {
        static readonly Regex regex = new(@"Дата и время окончания срока подачи заявок</span>(?<space>.*?)\n                    (?<valFirst>.*?) <span(?<space>.*?)>(?<valSecond>.*?)</span>", options);

        public static string GetString(string input)
        {
            string value;
            value = $"{regex.Split(input)[2]} {regex.Split(input)[3]}";
            return value;
        }
    }
}