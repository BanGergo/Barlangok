﻿using Barlangok;

List<Barlang> lista = new List<Barlang>();

FileStream fs = new FileStream("..\\..\\..\\src\\barlangok.txt", FileMode.Open);
StreamReader sr = new StreamReader(fs);
sr.ReadLine();
while (!sr.EndOfStream)
{
    lista.Add(new Barlang(sr.ReadLine()));   
}

sr.Close();
fs.Close();

var f4 = lista.Count();
Console.WriteLine($"4. feladat: Barlangok száma: {f4}");
double f5 = 0;
for (int i = 0; i < lista.Count; i++)
{
    if (lista[i].Telepules.Contains("Miskolc"))
    {
        f5 += lista[i].Melyseg;
    }
}
Console.WriteLine($"5. feladat: Az átlagos mélység: {f5/lista.Count:0.000} m");
Console.Write("6. feladat: Kérem a védettségi szintet: ");
var f6 = Console.ReadLine();

int max = 0;
bool find = false;
int j = 0;

while (find != true)
{
    for (int i = 0; i < lista.Count; i++)
    {
        if (lista[i].Hossz > max && lista[i].Vedettseg == f6)
        {
            max = lista[i].Hossz;
            j = i;
            find = true;
        }
    }
}
if (find == true)
{
    Console.WriteLine($"\tAzon: {lista[j].Azon}\n\tNév: {lista[j].Nev}\n\tHossz: {lista[j].Hossz}\n\tMélység: {lista[j].Melyseg}\n\tTelepülés: {lista[j].Telepules}");
}
else
{
    Console.WriteLine($"\tNincs ilyen védettségi szinttel barlang az adatok között!");
}
var f7 = lista.GroupBy(v => v.Vedettseg);
Console.WriteLine("7. Feladat: Statisztika");
foreach (var grp in f7)
{
    Console.WriteLine($"\t{grp.Key}:----> {grp.Count()} db");
}
