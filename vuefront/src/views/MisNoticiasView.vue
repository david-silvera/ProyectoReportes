<template>
  <div class="vista-incidentes">
    <MenuPrincipal :nombre="nombre" :apellido="apellido" :idusuario="idusuario" />
    <main class="contenedor-cartas">
    <h2 class="titulo">Mis Noticias</h2>

     <video class="banner" autoplay loop muted playsinline>
        <source src="../assets/213102_tiny.mp4" type="video/mp4">
    </video>
      <div
      class="tarjeta"
      v-for="(incidente, index) in incidentes"
      :key="index"
    >
      <img :src="incidente.imagen" alt="Imagen del incidente" />
      <div class="contenido">
        <h3>{{ incidente.lugar }}</h3>
        <p class="fecha">{{ formatFecha(incidente.fecha) }}</p>
        <p class="descripcion">{{ incidente.descripcion_breve }}</p>
      </div>
      <div class="acciones">
        <button @click="abrirModal(incidente, index)">Editar</button>
        <button class="eliminar" @click="eliminarNoticia(incidente.id, index)">Eliminar</button>
      </div>
  </div>
    </main>

    <div v-if="modalVisible" class="modal-overlay" @click.self="cerrarModal">
      <div class="modal-content">
        <h3>Editar Noticia</h3>
        <form @submit.prevent="guardarCambios">
          <label>
            Lugar:
            <input v-model="incidenteSeleccionado.lugar" required />
          </label>
          <label>
            Ciudad:
            <input v-model="incidenteSeleccionado.ciudad" required />
          </label>
          <label>
            Fecha:
            <input type="date" v-model="incidenteSeleccionado.fecha" required />
          </label>
          <label>
            Descripción Breve:
            <textarea v-model="incidenteSeleccionado.descripcionBreve" required></textarea>
          </label>
          <label>
            Descripción Ampliada:
            <textarea v-model="incidenteSeleccionado.descripcionAmpliada" required></textarea>
          </label>
          <label>
            URL Imagen:
            <input v-model="incidenteSeleccionado.imagen" />
          </label>
          <div class="botones-modal">
            <button type="submit">Guardar</button>
            <button type="button" @click="cerrarModal">Cancelar</button>
          </div>
        </form>
      </div>
    </div>

    <FooterPrincipal />
  </div>
</template>

<script>
import MenuPrincipal from '../components/MenuPrincipal.vue';
import FooterPrincipal from '../components/FooterPrincipal.vue';

export default {
  name: 'MisNoticiasView',
  components: { MenuPrincipal, FooterPrincipal },
  computed: {
    nombre() {
      return this.$route.query.nombre;
    },
    apellido() {
      return this.$route.query.apellido;
    },
    idusuario() {
      return Number(this.$route.query.idusuario);
    }
  },
  data() {
    return {
      incidentes: [],
      modalVisible: false,
      incidenteSeleccionado: null,
      indiceSeleccionado: null
    };
  },
  created() {
    this.obtenerMisNoticias();
  },
  methods: {
     formatFecha(fechaISO) {
    const fecha = new Date(fechaISO);
    return fecha.toISOString().split('T')[0]; 
  },
    async obtenerMisNoticias() {
      try {
        const res = await this.axios.get(`http://localhost:5272/api/Noticia/${this.idusuario}`);
        this.incidentes = res.data;
      } catch (error) {
        console.error('Error al obtener noticias:', error);
      }
    },
    abrirModal(incidente, index) {
      this.incidenteSeleccionado = { ...incidente };
      this.indiceSeleccionado = index;
      this.modalVisible = true;
    },
    cerrarModal() {
      this.modalVisible = false;
      this.incidenteSeleccionado = null;
      this.indiceSeleccionado = null;
    },
    async guardarCambios() {
      try {
        await this.axios.put(`http://localhost:5272/api/Noticia/${this.incidenteSeleccionado.id}`, this.incidenteSeleccionado);
        this.incidentes[this.indiceSeleccionado] = { ...this.incidenteSeleccionado };
        this.cerrarModal();
        alert('Noticia actualizada con éxito.');
      } catch (error) {
        console.error('Error al actualizar la noticia:', error);
        alert('Error al actualizar la noticia.');
      }
    },
    async eliminarNoticia(id, index) {
      if (confirm('¿Estás seguro de eliminar esta noticia?')) {
        try {
          await this.axios.delete(`http://localhost:5272/api/Noticia/${id}`);
          this.incidentes.splice(index, 1);
          alert('Noticia eliminada.');
        } catch (error) {
          console.error('Error al eliminar la noticia:', error);
          alert('Error al eliminar la noticia.');
        }
      }
    }
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

.modal-overlay {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  display: flex;
  justify-content: center;
  align-items: center;
  z-index: 1000;
}
.modal-content {
  background: white;
  border-radius: 12px;
  padding: 20px;
  width: 400px;
  max-width: 90%;
}
.modal-content form label {
  display: block;
  margin-bottom: 10px;
}
.modal-content form input,
.modal-content form textarea {
  width: 100%;
  padding: 6px;
  margin-top: 4px;
  border-radius: 6px;
  border: 1px solid #ccc;
  resize: vertical;
}
.botones-modal {
  margin-top: 15px;
  display: flex;
  justify-content: flex-end;
  gap: 10px;
}
.botones-modal button {
  padding: 8px 14px;
  border: none;
  border-radius: 6px;
  cursor: pointer;
}
.botones-modal button[type='submit'] {
  background-color: #1e3a8a;
  color: white;
}
.botones-modal button[type='button'] {
  background-color: #ccc;
}
.acciones {
  display: flex;
  justify-content: space-around;
  padding: 10px;
  border-top: 1px solid #eee;
}

.acciones button {
  padding: 6px 12px;
  border: none;
  border-radius: 6px;
  cursor: pointer;
  font-size: 14px;
}

.acciones button:hover {
  opacity: 0.9;
}

.acciones .eliminar {
  background-color: #dc2626;
  color: white;
}

.acciones .eliminar:hover {
  background-color: #b91c1c;
}
</style>
