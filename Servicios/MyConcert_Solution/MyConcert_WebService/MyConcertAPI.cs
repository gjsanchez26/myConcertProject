﻿using MyConcert_WebService.res.usr;
using MyConcert_WebService.server;
using System;

namespace MyConcert_WebService
{
    class MyConcertAPI
    {
        public static void Main(string[] args)
        {
            
            //Server nuevoServidorWeb = new Server();

            ManejadorBD man = new ManejadorBD();
            Console.WriteLine(man.obtenerUsuario("gigi").nombre);
            Console.ReadLine();
        }
    }
}
