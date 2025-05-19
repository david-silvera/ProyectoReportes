<template>
  <div class="vista-tecnologia">
    <MenuPrincipal :nombre="nombre" :apellido="apellido" />

    <main class="cuerpo">
      <h2 class="titulo-seccion">Noticias de Tecnología</h2>
      <div class="grupo-noticias">
        <div class="tarjeta" v-for="(noticia, index) in noticiasTecnologia" :key="index">
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
  name: 'TecnologiaView',
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
      noticiasTecnologia: [
        { titulo: 'Nuevo iPhone', contenido: 'Apple lanza su nuevo modelo...' },
        { titulo: 'IA en educación', contenido: 'La inteligencia artificial revoluciona las aulas...' },
        { titulo: 'Robótica', contenido: 'Avances en robots de servicio doméstico...' },
        { titulo: 'Ciberseguridad', contenido: 'Cómo proteger tus datos personales...' },
        { titulo: 'Quantum Computing', contenido: 'Google y IBM logran nuevos avances...' },
        { titulo: 'Videojuegos', contenido: 'El futuro de la industria gaming...' },
        { titulo: 'Vehículos autónomos', contenido: 'Tesla presenta mejoras en conducción automática...' },
        { titulo: 'Desarrollo Web', contenido: 'Las nuevas tendencias en el diseño UI/UX...' }
      ]
    };
  }
};
</script>

<style scoped>
.vista-tecnologia {
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