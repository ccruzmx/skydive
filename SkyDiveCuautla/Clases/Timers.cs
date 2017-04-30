using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;


namespace SkyDiveCuautla.Clases
{

    public class Timers
    {

        private Timer _timer = new Timer();
        private volatile bool _requestStop = false;

        public Timers()
        {
        _timer.Interval = 20;
        //_timer.Elapsed += Timed;
        //_timer.AutoReset = false;
        }
    


    private Int32 _idvuelo;
    private Int32 _numerovuelo;
    private string _matricula;
    private string _registrovuelo;
    private string _FreqValue;
    private string _FreqUnit;

    public Int32 idvuelo
    {
        get { return _idvuelo; }
        set { _idvuelo = value; }
    }

    public Int32 numerovuelo
    {
        get { return _numerovuelo; }
        set { _numerovuelo = value; }
    }

    public string matricula
    {
        get { return _matricula; }
        set { _matricula = value; }
    }

    public string registrovuelo
    {
        get { return _registrovuelo; }
        set { _registrovuelo = value; }
    }

    public void CreateTimer(int idvuelo, int numerovuelo, string matricula, string registrovuelo)
    {
        this.idvuelo = idvuelo;
        this.numerovuelo = numerovuelo;
        this.matricula = matricula;
        this.registrovuelo = registrovuelo;


        _timer.Interval = 2000;
        _timer.Start();
    }

    private void Timed(object source, EventArgs e)
    {
        _timer.Stop();

        //StreamWriter sr = new StreamWriter("E:\\downloader\\"+Id+".txt");
        //sr.Write(Url+" "+Save+" "+File+"\n\n");
        //sr.Close();

        //ClassLib.Update.File(Url,Save,File,Id);

        _timer.Start();
    }
    }
}
