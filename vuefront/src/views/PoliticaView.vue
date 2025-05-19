<template>
    <div class="vista-politica">
      <MenuPrincipal :nombre="nombre" :apellido="apellido" />
  
      <main class="cuerpo">
        <h2 class="titulo-seccion">Noticias de Política</h2>
        <div class="grupo-noticias">
          <div class="tarjeta" v-for="(noticia, index) in noticiasPolitica" :key="index">
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
    name: 'VistaPolitica',
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
        noticiasPolitica: [
          { titulo: 'Elecciones 2025', contenido: 'Todo lo que debes saber...' },
          { titulo: 'Reformas fiscales', contenido: 'Propuestas del congreso...' },
          { titulo: 'Política internacional', contenido: 'Reunión de líderes en la ONU...' },
          { titulo: 'Medidas económicas', contenido: 'Análisis del nuevo presupuesto...' },
          { titulo: 'Diplomacia', contenido: 'Nuevas alianzas estratégicas...' },
          { titulo: 'Proyectos de ley', contenido: 'Debates sobre legislación clave...' },
          { titulo: 'Crisis gubernamental', contenido: 'Impacto de las decisiones recientes...' },
          { titulo: 'Desarrollo social', contenido: 'Iniciativas para reducir la desigualdad...' }
        ]
      };
    }
  };
  </script>
  
  <style scoped>
  .vista-politica {
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