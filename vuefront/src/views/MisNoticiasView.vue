<template>
  <div class="vista-incidentes">
    <MenuPrincipal :nombre="nombre" :apellido="apellido" :idusuario="idusuario" />

    <h2 class="titulo">Mis Noticias</h2>

    <main class="contenedor-cartas">
      <div
      class="tarjeta"
      v-for="(incidente, index) in incidentes"
      :key="index"
    >
      <img :src="incidente.imagen" alt="Imagen del incidente" />
      <div class="contenido">
        <h3>{{ incidente.lugar }}</h3>
        <p class="fecha">{{ incidente.fecha }}</p>
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
.vista-incidentes {
  background-color: #f4f4f4;
  min-height: 100vh;
  font-family: Arial, sans-serif;
}

.titulo {
  text-align: center;
  color: #1e3a8a;
  margin-top: 20px;
}

.contenedor-cartas {
  display: grid;
  grid-template-columns: repeat(4, 1fr);
  gap: 20px;
  padding: 20px;
}

.tarjeta {
  background-color: white;
  padding: 0;
  border-radius: 12px;
  box-shadow: 0 4px 8px rgba(0,0,0,0.1);
  overflow: hidden;
  display: flex;
  flex-direction: column;
  transition: transform 0.2s ease;
  cursor: pointer;
}

.tarjeta:hover {
  transform: translateY(-4px);
}

.tarjeta img {
  width: 100%;
  height: 250px;
  object-fit: cover;
}

.tarjeta .contenido {
  padding: 12px 16px;
}

.tarjeta h3 {
  margin: 0;
  color: #1e3a8a;
  font-size: 18px;
}

.tarjeta .fecha {
  font-size: 14px;
  color: #444;
  margin: 6px 0;
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
