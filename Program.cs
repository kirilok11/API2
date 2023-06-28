
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using API.Clients;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//"DefaultConnection": "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Kirill\\source\\repos\\Database\\Database\\Database1.mdf;Integrated Security=True"
//builder.Services.AddDbContext<FavoriteContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<FavoriteContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("FavoritesCS")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();

/*
using API.Clients;
using System;
using System.Net;
class Program 
{
    static void Main(string[] args)
    {
        
        string x = "У старому дерев'яному будинку, Зоє, ексцентричній молодій француженці, з задоволенням поїдала смачну грибну кіш зі спарклінгом. Вона наспівувала романтичну пісню, любувалася панорамним видом з вікна. Раптово отримала таємниче повідомлення від свого друга Жака, який запропонував їй екзотичну експедицію до Нової Каледонії. З великим захопленням вона одразу погодилася і почала готувати своє пригодницьке спорядження: капелюх, бінокль, рюкзак та купальник. Вона з ентузіазмом полетіла до цього сонячного місця, готова досліджувати дику природу і переживати незабутні моменти.";
        string y = "uk";
        string z = "ru";
        TranslatorClient translateClient2 = new TranslatorClient();
        var res4 = translateClient2.TranslateAsync(x, y, z);
        Console.WriteLine(res4.Result.TranslatedText);
        Console.ReadKey();
        
        

    }
}
*/
/*
using API.Clients;
using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите путь к файлу:");
        string filePath = "C:\\Users\\Kirill\\Desktop";
        TTSClient tTSClient = new TTSClient();
        string a = "en-US";
        string b = "Hi HOW ARE YOU";
        var x = tTSClient.ReadTextToSpeachAsync(a, b);

        try
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.Write(x);
                }
            }

            Console.WriteLine("Файл успешно записан.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка при записи файла: " + ex.Message);
        }

        Console.ReadLine();
    }
}
*/
/*
using API.Clients;
using API.Controllers;

TranslatorClient translatorClient = new TranslatorClient();
string l = "en";
string s = "ru";
string t = "как дела";
var x = translatorClient.TranslateAsync(t, s, l).Result;
Console.WriteLine(x.data.translatedText);
*/