<template>
    <div class="vista-deportes">
      <MenuPrincipal :nombre="nombre" :apellido="apellido" />
  
      <main class="cuerpo">
        <h2 class="titulo-seccion">Noticias de Deportes</h2>
        <div class="grupo-noticias">
          <div class="tarjeta" v-for="(noticia, index) in noticiasDeportes" :key="index">
            <h3>{{ noticia.titulo }}</h3>
            <p>{{ noticia.contenido }}</p>
          </div>
        </div>
      </main>
  
      <FooterPrincipal />
    </div>
  </template>
  
  <script>
  import MenuPrincipal from '../components/MenuPrincipal.vue';
  import FooterPrincipal from '../components/FooterPrincipal.vue';
  
  export default {
    name: 'DeportesView',
    components: {
      MenuPrincipal,
      FooterPrincipal
    },
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
        noticiasDeportes: [
          { titulo: 'Fútbol local', contenido: 'Resumen del partido de ayer...' },
          { titulo: 'NBA', contenido: 'LeBron James lidera su equipo...' },
          { titulo: 'Tenis', contenido: 'Gran victoria de Nadal...' },
          { titulo: 'Formula 1', contenido: 'Carrera emocionante en Mónaco...' },
          { titulo: 'Juegos Olímpicos', contenido: 'Preparativos para París 2024...' },
          { titulo: 'Voleibol', contenido: 'La selección nacional logra pase...' },
          { titulo: 'Boxeo', contenido: 'Combate por el título mundial...' },
          { titulo: 'Ciclismo', contenido: 'Nueva etapa del Tour de Francia...' }
        ]
      };
    }
  };
  </script>
  
  <style scoped>
  .vista-deportes {
    background-color: #f4f4f4;
    min-height: 100vh;
    font-family: Arial, sans-serif;
  }
  
  .titulo-seccion {
    text-align: center;
    padding: 20px;
    font-size: 28px;
    color: #1e3a8a;
    margin: 0;
  }
  
  .grupo-noticias {
    display: grid;
    grid-template-columns: repeat(4, 1fr);
    gap: 20px;
    padding: 0 20px 20px;
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
  