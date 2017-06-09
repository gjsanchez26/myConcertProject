using MyConcert_WebService.models;
using MyConcert_WebService.res;
using MyConcert_WebService.res.usr;
using MyConcert_WebService.security;
using MyConcert_WebService.server;
using System;
using System.Collections.Generic;

namespace MyConcert_WebService
{
    class MyConcertAPI
    {
        
        public static void Main(string[] args)
        {
            ManejadorBD _db = new ManejadorBD();
            //Server nuevoServidorWeb = new Server();            
            //ManejadorBD man = new ManejadorBD();
            //Console.WriteLine(man.obtenerUsuario("gigi").nombre);                    

            /*********************************************************/
            /*SE LLAMA LA LOGICA DEL CHEF******        */
            
            /*POR MIENTRAS: _WINNER*/
            List<string> _winner = new List<string>();
            _winner.Add("The Doors");
            _winner.Add("Pink Floyd");
            _winner.Add("Metallica");
            _winner.Add("Iron Maiden");
            _winner.Add("Black Sabbath");
            _winner.Add("Scorpions");

            int id_festival = 1;

            ChefModel _chefLogic = new ChefModel();
            _chefLogic.executeChefProcess(_winner, id_festival);



            /* ALGORITMO DE ENCRIPTACION */
            Console.WriteLine("Encriptacion");
            SHA256Encriptation _sha = new SHA256Encriptation();
            string encrypted_str = _sha.sha256Encrypt("hola");
            Console.WriteLine("Hola encriptado: " + encrypted_str);     

        /* ESTRATEGIA 100 DOLARES */
            Console.WriteLine("Estrategia de los 100 dólares");
            DolarStrategy _dolar = new DolarStrategy();
            List<int> dolar_votes = new List<int>();
            dolar_votes.Add(25);
            dolar_votes.Add(25);
            dolar_votes.Add(15);
            dolar_votes.Add(5);
            dolar_votes.Add(30);   

            bool isHundred = _dolar.checkDolars(dolar_votes);
            if (isHundred)
            {
                Console.WriteLine("Su votación está correcta...");
            }  
            
            
            Console.ReadLine();
        }

       
        
    }   
        
}
