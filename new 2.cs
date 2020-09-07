using System;

using Netica;

namespace NeticaDemo

{

class Program

{

static void Main(string[] args)

{

Console.WriteLine("Welcome to Netica API for C# !");

Netica.ApplicationClass app = new Netica.ApplicationClass();

app.Visible = true;

string net_file_name = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\..\\ChestClinic.dne";

 

Streamer file = app.NewStream(net_file_name, null);

BNet net = app.ReadBNet(file, "");

net.Compile();

BNode TB = net.Nodes.get_Item("Tuberculosis");

double bel = TB.GetBelief("present");

Console.WriteLine("The probability of tuberculosis is " + bel.ToString("G4"));

 

BNode XRay = net.Nodes.get_Item("XRay");

XRay.EnterFinding("abnormal");

bel = TB.GetBelief("present");

Console.WriteLine("Given an abnormal X-Ray, the probability of tuberculosis is " + bel.ToString("G4"));

 

net.Nodes.get_Item("VisitAsia").EnterFinding("visit");

bel = TB.GetBelief("present");

Console.WriteLine("Given abnormal X-Ray and visit to Asia, the probability of TB is " + 

bel.ToString("G4"));

 

net.Nodes.get_Item("Cancer").EnterFinding("present");

bel = TB.GetBelief("present");

Console.WriteLine("Given abnormal X-Ray, Asia visit, and lung cancer, the probability of TB is

" + bel.ToString("G4"));

 

net.Delete();

if (!app.UserControl) app.Quit();

 

Console.WriteLine("Press <enter> to quit.");

Console.ReadLine();

}

}

}
 