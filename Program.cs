using System.Security.Claims;

namespace ortalama_hesaplama
{
    class Program
    {
        static void Main(string[] args)
        {
            Input input = new Input();
            FibonacciSerisi  fibonacciSerisi=new FibonacciSerisi();
            OrtHesaplama ort = new OrtHesaplama();

            try
            {
                int derinlik=input.DerinlikAl();
                List<int> seri = FibonacciSerisi.Olustur(derinlik);
                double ortalama = OrtHesaplama.Ortalama(seri);

                Console.WriteLine($"Fibonacci serisinin {derinlik} derinliğindeki ortalaması: {ortalama} ");
                
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
    class Input
    {
        public int DerinlikAl()
        {
            Console.WriteLine("Lütfen Fibonacci serisi için derinliği giriniz: ");
            if (int.TryParse(Console.ReadLine(), out int derinlik) && derinlik > 0)
            {
                return derinlik;
            }
            throw new ArgumentException("Geçerli bir sayı girilmelidir.");

        }

    }



    class FibonacciSerisi
    {
        public static List<int> Olustur(int derinlik)
        {
            List<int> seri = new List<int> { 0, 1 };
            for (int i = 2; i < derinlik; i++)
            {
                seri.Add(seri[i - 1] + seri[i - 2]);
            }
            return seri.Take(derinlik).ToList();
        }

    }
    class OrtHesaplama
    {
        public static double Ortalama(List<int> sayilar)
        {
            return sayilar.Average();
        }
    }

}