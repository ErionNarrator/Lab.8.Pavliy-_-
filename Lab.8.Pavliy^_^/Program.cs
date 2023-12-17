try
{
    Console.Write("Введите количество средств защиты от поражения электрическим током:");
    int n = int.Parse(Console.ReadLine());
    ElectricalProtectionDevice[] devices = new ElectricalProtectionDevice[n];

    for (int i = 0; i < n; i++)
    {
        devices[i] = new ElectricalProtectionDevice();

        Console.Write("Введите инвентарный номер:");
        devices[i].inventoryNumber = Console.ReadLine();

        Console.Write("Введите наименование:");
        devices[i].name = Console.ReadLine();

        Console.Write("Введите ФИО ответственного:");
        devices[i].responsiblePerson = Console.ReadLine();

        Console.Write("Введите дату последней проверки в формате YYYY-MM-DD:");
        devices[i].lastCheckDate = DateOnly.Parse(Console.ReadLine());

        Console.Write("Введите очередность проверки в месяцах:");
        devices[i].checkIntervalMonths = int.Parse(Console.ReadLine());
    }

    foreach (ElectricalProtectionDevice device in devices)
    {
        DateOnly now = DateOnly.FromDateTime(DateTime.Now);
        int monthsSinceLastCheck = (now.Year - device.lastCheckDate.Year) * 12 + now.Month - device.lastCheckDate.Month;

        if (monthsSinceLastCheck >= device.checkIntervalMonths)
        {
            Console.WriteLine("Необходимо проверить " + device.name + " (Инв. номер: " + device.inventoryNumber + ")");
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

struct ElectricalProtectionDevice
{
    public string inventoryNumber;
    public string name;
    public string responsiblePerson;
    public DateOnly lastCheckDate;
    public int checkIntervalMonths;
}