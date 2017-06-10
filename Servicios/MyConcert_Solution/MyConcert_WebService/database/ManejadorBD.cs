using MyConcert_WebService.database;
using MyConcert_WebService.objects;
using System.Collections.Generic;

namespace MyConcert_WebService
{   //FACADE CAPA DE DATOS
    public class ManejadorBD
    {
        private BandasDB banDB;
        private CategoriaDB catDB;
        private EventosDB eveDB;
        private UsuariosDB usuDB ;
        private UtilidadesDB utiDB;
        private VotosDB votDB;

        public ManejadorBD()
        {
             banDB = new BandasDB();
             catDB = new CategoriaDB();
             eveDB = new EventosDB();
             usuDB = new UsuariosDB();
             utiDB = new UtilidadesDB();
             votDB = new VotosDB();
    }
        public bool conexionBaseDatos()
        {
            using (myconcertEntities dbContext = new myconcertEntities())
            {
                 return dbContext.Database.Exists();

            }

        }
        //BANDASDB

        public void añadirBanda(bandas banda, List<integrantes> integ, List<canciones> canciones, List<generos> gen)
        {
            
            banDB.añadirBanda(banda, integ, canciones, gen);

        }

        public bandas obtenerBanda(int PK_banda)
        {
            
            return banDB.obtenerBanda(PK_banda);
        }

        public integrantes obtenerIntegrante(int PK_integrante)
        {
           
            return banDB.obtenerIntegrante(PK_integrante);
        }

        public generosbanda obtenerGenerosBanda(int PK_generosBanda)
        {
            
            return banDB.obtenerGenerosBanda(PK_generosBanda);
        }

        public void añadirCancion(canciones cancion)
        {
            
            banDB.añadirCancion(cancion);
        }

        public canciones obtenerCancion(int PK_cancion)
        {
            
            return banDB.obtenerCancion(PK_cancion);
        }

        public comentarios obtenerComentario(int PK_comentario)
        {
            
            return banDB.obtenerComentario(PK_comentario);
        }

        //CATEGORIASDB
        public categorias obtenerCategoria(int PK_categoria)
        {
            
            return catDB.obtenerCategoria(PK_categoria);
        }

        public List<categorias> obtenerCategorias()
        {
            
            return catDB.obtenerCategorias();
        }

        //EVENTOSDB

        public Evento[] obtenerCarteleras()
        {
            
            return eveDB.obtenerCarteleras();
        }

        public Evento[] obtenerFestivales()
        {
            return eveDB.obtenerFestivales();
        }

        public categoriasevento obtenerCategoriasEvento(int PK_categoriasEvento)
        {
            return eveDB.obtenerCategoriasEvento(PK_categoriasEvento);
        }

        public eventos obtenerEvento(int PK_evento)
        {
            return obtenerEvento(PK_evento);
        }

        public tiposeventos obtenerTipoEvento(int PK_tipoEvento)
        {
            return eveDB.obtenerTipoEvento(PK_tipoEvento);
        }

        public List<bandas> obtenerBandasNoCartelera(eventos cartelera)
        {
            return eveDB.obtenerBandasNoCartelera(cartelera);
        }

        public int getCantidadComentarios(bandas banda)
        {
            return getCantidadComentarios(banda);
        }
        public float getCalificacion(bandas banda)
        {
            return eveDB.getCalificacion(banda);
        }

        public List<canciones> obtenerCanciones(bandas banda)
        {
            return banDB.obtenerCanciones(banda);
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

        public Usuario obtenerUsuario(string username)
        {
            return usuDB.obtenerUsuario(username);
        }
        public void añadirUsuario(Usuario us, int[] gen)
        {
            usuDB.añadirUsuario(us, gen);
        }
        public void añadirGeneroUsuario(generosusuario genUs)
        {
            usuDB.añadirGeneroUsuario(genUs);
        }
        public generosusuario obtenerGenerosUsuario(int PK_generosUsuario)
        {
            return usuDB.obtenerGenerosUsuario(PK_generosUsuario);
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

        public GeneroMusical[] obtenerGeneros()
        {
            return utiDB.obtenerGeneros();
        }

        public Pais[] obtenerPaises()
        {
            return utiDB.obtenerPaises();
        }

        public Universidad[] obtenerUniversidades()
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
        public votos obtenerVoto(int PK_voto)
        {
            return votDB.obtenerVoto(PK_voto);
        }
    }
}
