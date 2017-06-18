using MyConcert.database;
using MyConcert.viewModels;
using System.Collections.Generic;

namespace MyConcert
{   //FACADE CAPA DE DATOS

    /*
     * Controlador basado en el patron facade
     * Comunica capa de datos con capa de negocio.
     * Usado para escritura, lectura, modificacion y eliminacion de datos en la base de datos
     */
    public class FacadeDB
    {
        private BandasDB banDB;
        private CategoriasDB catDB;
        private EventosDB eveDB;
        private UsuariosDB usuDB ;
        private UtilidadesDB utiDB;
        private VotosDB votDB;

        
        public FacadeDB()
        {
             banDB = new BandasDB();
             catDB = new CategoriasDB();
             eveDB = new EventosDB();
             usuDB = new UsuariosDB();
             utiDB = new UtilidadesDB();
            votDB = new VotosDB();
        }

        //BANDASDB


        public void añadirComentario(comentarios coment)
        {
            banDB.añadirComentario(coment);
        }
        public void añadirBanda(bandas banda, List<integrantes> integ, List <canciones> canciones, List<generos> gen)
        {
            
            banDB.añadirBanda(banda, integ, canciones, gen);

        }

        public bandas obtenerBanda(int PK_banda)
        {
            
            return banDB.obtenerBanda(PK_banda);
        }

        public List<bandas> obtenerBandas()
        {

            return banDB.obtenerBandas();
        }

        public bandas obtenerBanda(string PK_banda)
        {

            return banDB.obtenerBanda(PK_banda);
        }

        public List<integrantes> obtenerIntegrantes(bandas banda)
        {
            return banDB.obtenerIntegrantes(banda);
        }
        public List<comentarios> obtenerComentarios(bandas banda)
        {
            return banDB.obtenerComentarios(banda);
        }
        public List<generos> obtenerGenerosBanda(bandas banda)
        {
            return banDB.obtenerGenerosBanda(banda);
        }
        //CATEGORIASDB
        public void añadirCategoria(categorias nuevaCategoria)
        {
            catDB.añadirCategoria(nuevaCategoria);
        }

        public categorias obtenerCategoria(string PK_categoria)
        {

            return catDB.obtenerCategoria(PK_categoria);
        }

        public categorias obtenerCategoria(int PK_categoria)
        {

            return catDB.obtenerCategoria(PK_categoria);
        }

        public List<categorias> obtenerCategorias()
        {
            
            return catDB.obtenerCategorias();
        }

        public List<bandas> obtenerBandasCategoria(int categoria, int evento)
        {
            return catDB.obtenerBandasCategoria(categoria, evento);
        }
        //EVENTOSDB

        public eventos obtenerEvento(int PK_evento)
        {
            return eveDB.obtenerEvento(PK_evento);
        }
        public void añadirCartelera(eventos pCartelera, List<categoriasevento> pCategorias)
        {
            eveDB.añadirEvento(pCartelera, pCategorias);
        }

        public List<eventos> obtenerCarteleras()
        {
            
            return eveDB.obtenerCarteleras();
        }

        public List<eventos> obtenerFestivales()
        {
            return eveDB.obtenerFestivales();
        }

        public List<categorias> obtenerCategoriasEvento(int PK_categoriasEvento)
        {
            return catDB.obtenerCategoriasEvento(PK_categoriasEvento);
        }

        public tiposeventos obtenerTipoEvento(int PK_tipoEvento)
        {
            return eveDB.obtenerTipoEvento(PK_tipoEvento);
        }

        public tiposeventos obtenerTipoEvento(string PK_tipoEvento)
        {
            return eveDB.obtenerTipoEvento(PK_tipoEvento);
        }

        public List<bandas> obtenerBandasNoCartelera(eventos cartelera)
        {
            return eveDB.obtenerBandasNoCartelera(cartelera);
        }

        public int getCantidadComentarios(bandas banda)
        {
            return eveDB.getCantidadComentarios(banda);
        }
        
        public float getCalificacion(bandas banda)
        {
            return eveDB.getCalificacion(banda);
        }

        public List<canciones> obtenerCanciones(bandas banda)
        {
            return banDB.obtenerCanciones(banda);
        }

        public int obtenerCantidadVotos(int cartelera, int categoria, int banda)
        {
            return votDB.obtenerCantidadVotos(cartelera, categoria, banda);
        }
        public int obtenerCantidadVotos(int cartelera, int banda)
        {
            return votDB.obtenerCantidadVotos(cartelera, banda);
        }

        public void crearFestival(eventos festival, List<bandas> perdedoras)
        {
           eveDB.crearFestival(festival, perdedoras);
        }
        //USUARIOSDB
        public tiposusuarios obtenerTipoUsuario(string tipoUsuario)
        {
            return usuDB.obtenerTipoUsuario(tipoUsuario);
        }
        public tiposusuarios obtenerTipoUsuario(int PK_tipoUsuario)
        {
            return usuDB.obtenerTipoUsuario(PK_tipoUsuario);
        }

        public usuarios obtenerUsuario(string username)
        {
            return usuDB.obtenerUsuario(username);
        }
        public usuarios añadirUsuario(usuarios us, List<generos> gen)
        {
            return usuDB.añadirUsuario(us, gen);
        }
        public usuarios añadirUsuario(usuarios us)
        {
            return usuDB.añadirUsuario(us);
        }

        public List<generos> obtenerGenerosUsuario(usuarios us)
        {
            return usuDB.obtenerGenerosUsuario(us);
        }
        //UTILIDADESDB

        public universidades obtenerUniversidad(string universidad)
        {
            return utiDB.obtenerUniversidad(universidad);
        }

        public paises obtenerPais(string pais)
        {
            return utiDB.obtenerPais(pais);
        }

        public List<generos> obtenerGeneros()
        {
            return utiDB.obtenerGeneros();
        }

        public List<paises> obtenerPaises()
        {
            return utiDB.obtenerPaises();
        }

        public List<universidades> obtenerUniversidades()
        {
            return utiDB.obtenerUniversidades();
        }

        public universidades obtenerUniversidad(int PK_universidad)
        {
            return utiDB.obtenerUniversidad(PK_universidad);
        }

        public paises obtenerPais(int PK_pais)
        {
            return utiDB.obtenerPais(PK_pais);
        }

        public estados obtenerEstado(string estado)
        {
            return utiDB.obtenerEstado(estado);
        }
        public estados obtenerEstado(int PK_estado)
        {
            return utiDB.obtenerEstado(PK_estado);
        }
        public generos obtenerGenero(int PK_genero)
        {
            return utiDB.obtenerGenero(PK_genero);
        }

        //VOTOSDB

        public void añadirVotos(List<votos> pVotos)
        {
            votDB.añadirVotos(pVotos);
        }


    }
}
