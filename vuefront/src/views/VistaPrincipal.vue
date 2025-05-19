<template>
    <div class="vista-principal">
      <MenuPrincipal :nombre="nombre" :apellido="apellido" />
  
      <main class="cuerpo">
        <section v-for="(noticias, tipo) in noticiasPorTipo" :key="tipo" class="seccion">
          <div class="subtitulo" @click="verTodas(tipo)">
            <h2>{{ tipo }}</h2>
          </div>
  
          <div class="grupo-noticias">
            <div class="tarjeta" v-for="(noticia, index) in noticias" :key="index">
              <h3>{{ noticia.titulo }}</h3>
              <p>{{ noticia.contenido }}</p>
            </div>
          </div>
        </section>
      </main>
  
      <FooterPrincipal />
    </div>
  </template>
  
  <script>
  import MenuPrincipal from '../components/MenuPrincipal.vue';
  import FooterPrincipal from '../components/FooterPrincipal.vue';
  
  export default {
    name: 'VistaPrincipal',
    components: { MenuPrincipal, FooterPrincipal },
    computed: {
      nombre() {
        return this.$route.query.nombre;
      },
      apellido() {
        return this.$route.query.apellido;
      }
    },
    data() {
      return {
        noticiasPorTipo: {
          Deportes: [
            { titulo: 'Fútbol local', contenido: 'Resumen del partido de ayer...' },
            { titulo: 'NBA', contenido: 'LeBron James lidera su equipo...' },
            { titulo: 'Tenis', contenido: 'Gran victoria de Nadal...' },
            { titulo: 'Formula 1', contenido: 'Carrera emocionante en Mónaco...' }
          ],
          Tecnología: [
            { titulo: 'Nuevo iPhone', contenido: 'Apple lanza su nuevo modelo...' },
            { titulo: 'IA en educación', contenido: 'La inteligencia artificial revoluciona las aulas...' },
            { titulo: 'Robótica', contenido: 'Avances en robots de servicio doméstico...' },
            { titulo: 'Ciberseguridad', contenido: 'Cómo proteger tus datos personales...' }
          ],
          Política: [
            { titulo: 'Elecciones 2025', contenido: 'Todo lo que debes saber...' },
            { titulo: 'Reformas fiscales', contenido: 'Propuestas del congreso...' },
            { titulo: 'Política internacional', contenido: 'Reunión de líderes en la ONU...' },
            { titulo: 'Medidas económicas', contenido: 'Análisis del nuevo presupuesto...' }
          ]
        }
      };
    },
    methods: {
  verTodas(tipo) {
    let ruta = '';
    
    switch (tipo) {
      case 'Deportes':
        ruta = 'Deportes';
        break;
      case 'Tecnología':
        ruta = 'Tecnologia';
        break;
      case 'Política':
        ruta = 'Politica';
        break;
      default:
        ruta = 'VistaPrincipal';
    }

    this.$router.push({
      name: ruta,
      query: {
        nombre: this.nombre,
        apellido: this.apellido
      }
    });
  }
}
  };
  </script>
  
  <style scoped>
  .vista-principal {
    background-color: #f4f4f4;
    min-height: 100vh;
    font-family: Arial, sans-serif;
  }
  
  .seccion {
    margin-bottom: 40px;
  }
  
  .subtitulo {
  display: flex;
  justify-content: space-between;
  align-items: flex-end;
  padding: 0 20px 12px 20px; 
  cursor: pointer;
  color: #1e3a8a;

}
  
  .subtitulo h2 {
    margin-top: 15px;
  }
  
  .ver-todas {
    font-size: 14px;
    color: #3498db;
    text-decoration: underline;
  }
  
  .grupo-noticias {
    display: grid;
    grid-template-columns: repeat(4, 1fr);
    gap: 20px;
    padding: 20px;
  }
  
  .tarjeta {
    background-color: white;
    padding: 16px;
    border-radius: 10px;
    box-shadow: 0px 4px 8px rgba(0,0,0,0.1);
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    height: 320px;
  }
  
  .tarjeta h3 {
    margin-top: 0;
    color: #1E3A8A;
  }
  
  .tarjeta p {
    flex-grow: 1;
    margin-bottom: 0;
  }
  </style>
  