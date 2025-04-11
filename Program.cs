using System;

abstract class Karyawan
{
    public string Nama { get; set; }
    public string Id { get; set; }
    public double GajiPokok { get; set; }

    public Karyawan(string nama, string id, double gajiPokok)
    {
        Nama = nama;
        Id = id;
        GajiPokok = gajiPokok;
    }

    public abstract double HitungGaji();
}

class KaryawanTetap : Karyawan
{
    public KaryawanTetap(string nama, string id, double gajiPokok) : base(nama, id, gajiPokok) { }

    public override double HitungGaji() => GajiPokok + 500000;
}

class KaryawanKontrak : Karyawan
{
    public KaryawanKontrak(string nama, string id, double gajiPokok) : base(nama, id, gajiPokok) { }

    public override double HitungGaji() => GajiPokok - 200000;
}

class KaryawanMagang : Karyawan
{
    public KaryawanMagang(string nama, string id, double gajiPokok) : base(nama, id, gajiPokok) { }

    public override double HitungGaji() => GajiPokok;
}

class Program
{
    static void Main()
    {
        Console.Write("Pilih karyawan (1: Tetap, 2: Kontrak, 3: Magang): ");
        int pilihan = int.Parse(Console.ReadLine());

        Console.Write("Nama: ");
        string nama = Console.ReadLine();
        Console.Write("ID: ");
        string id = Console.ReadLine();
        Console.Write("Gaji Pokok: ");
        double gajiPokok = double.Parse(Console.ReadLine());

        Karyawan karyawan = pilihan switch
        {
            1 => new KaryawanTetap(nama, id, gajiPokok),
            2 => new KaryawanKontrak(nama, id, gajiPokok),
            3 => new KaryawanMagang(nama, id, gajiPokok),
            _ => null
        };

        if (karyawan == null)
        {
            Console.WriteLine("Pilihan tidak valid!");
            return;
        }

        Console.WriteLine($"\nNama: {karyawan.Nama}\nID: {karyawan.Id}\nGaji Akhir: Rp {karyawan.HitungGaji()}");
    }
}