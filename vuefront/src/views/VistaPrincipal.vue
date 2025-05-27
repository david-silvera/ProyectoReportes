<template>
  <div class="vista-incidentes">
    <MenuPrincipal :nombre="nombre" :apellido="apellido" :idusuario="idusuario" />
    <main class="contenedor-cartas">

     <h2 class="titulo">Incidentes en Santa Marta</h2>
  
         <video class="banner" autoplay loop muted playsinline>
        <source src="../assets/213102_tiny.mp4" type="video/mp4">
    </video>
      <div
        class="tarjeta"
        v-for="(incidente, index) in incidentes"
        :key="index"
        @click="verDetalle(incidente)"
      >
          <img :src="incidente.imagen" alt="Imagen del incidente" />
          <div class="contenido">
          <h3>{{ incidente.lugar }}</h3>
          <p class="fecha">{{ formatFecha(incidente.fecha) }}</p>
          <p class="descripcion">{{ incidente.descripcionBreve }}</p>
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
  name: 'VistaPrincipal',
  components: { MenuPrincipal, FooterPrincipal },
  computed: {
    nombre() {
      return this.$route.query.nombre;
    },
    apellido() {
      return this.$route.query.apellido;
    },
     idusuario() {
      return this.$route.query.idusuario;
    }
  },
  data() {
    return {
      incidentes: []
    };
  },
  methods: {
    formatFecha(fechaISO) {
    const fecha = new Date(fechaISO);
    return fecha.toISOString().split('T')[0]; 
  },
    verDetalle(incidente) {
      this.$router.push({
        name: 'DetalleIncidente',
        query: {
          lugar: incidente.lugar,
          ciudad: incidente.ciudad,
          fecha: incidente.fecha,
          imagen: incidente.imagen,
          descripcion: incidente.descripcionAmpliada,
          nombre: this.nombre,
          apellido: this.apellido,
          idusuario: this.idusuario
        }
      });
    },
     async cargarNoticias() {
      try {
        const response = await this.axios.get('http://localhost:5272/api/Noticia');
        this.incidentes = response.data;  
      } catch (error) {
        console.error('Error al cargar noticias:', error);
      }
    }
  },
   created() {
    this.cargarNoticias();
  }
};
</script>

<style scoped>
* {
      margin: 0;
      padding: 0;
      box-sizing: border-box;
    }
   .banner{
   position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  object-fit: cover;
  z-index: 0;
  pointer-events: none; 
}
.vista-incidentes {
  background-color: #f4f4f4;
  min-height: 100vh;
  font-family: Arial, sans-serif;
   object-fit: cover;
}

.titulo {
   grid-column: 1 / -1; 
  position: relative;
  z-index: 2; 
  text-align: center;
  margin: 20px 0;
  color:white;
  font-size: 24px;
  font-weight: bold;
  background: none; 
  padding: 0; 
}

.contenedor-cartas {
 position: relative;
  display: grid;
  grid-template-columns: repeat(4, 1fr);
  gap: 20px;
  padding: 0 40px 40px;
  box-sizing: border-box;
  overflow: hidden; 
  min-height: 70vh;
}

@media (max-width: 1200px) {
  .contenedor-cartas {
    grid-template-columns: repeat(3, 1fr);
  }
}

@media (max-width: 768px) {
  .contenedor-cartas {
    grid-template-columns: repeat(2, 1fr);
  }
}

@media (max-width: 480px) {
  .contenedor-cartas {
    grid-template-columns: 1fr;
  }
}

.tarjeta {

  position: relative;
  background-color: rgba(255, 255, 255, 0.9); 
  border-radius: 12px;
  overflow: hidden;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
  transition: transform 0.2s ease;
  cursor: pointer;
  z-index: 1; 

}

.tarjeta:hover {
  transform: scale(1.02);
}

.tarjeta img {
  width: 100%;
  height: 180px;
  object-fit: cover;
}

.tarjeta .contenido {
 padding: 15px;
}

.tarjeta h3 {
   color: #0d47a1;
  margin: 0 0 10px;
  font-size: 18px;
}

.tarjeta .fecha {
  margin: 0;
  color: #333;
}

.tarjeta .descripcion {
  font-size: 15px;
  color: #222;
}
</style>

