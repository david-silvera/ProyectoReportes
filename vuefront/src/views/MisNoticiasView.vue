<template>
  <div class="vista-incidentes">
    <MenuPrincipal :nombre="nombre" :apellido="apellido" :idusuario="idusuario" />

    <h2 class="titulo">Mis Noticias</h2>

    <main class="contenedor-cartas">
      <div
        class="tarjeta"
        v-for="(incidente, index) in misIncidentes"
        :key="index"
        @click="abrirModal(incidente, index)"
      >
        <img :src="incidente.imagen" alt="Imagen del incidente" />
        <div class="contenido">
          <h3>{{ incidente.lugar }}</h3>
          <p class="fecha">{{ incidente.fecha }}</p>
          <p class="descripcion">{{ incidente.descripcion_breve }}</p>
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
            <textarea v-model="incidenteSeleccionado.descripcion_breve" required></textarea>
          </label>
          <label>
            Descripción Ampliada:
            <textarea v-model="incidenteSeleccionado.descripcion_ampliada" required></textarea>
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
    },
    misIncidentes() {
      return this.incidentes.filter(
        incidente => incidente.id_usuario === this.idusuario
      );
    }
  },
  data() {
    return {
      incidentes: [
        {
          id_usuario: 1,
          lugar: 'Barrio El Prado',
          ciudad: 'Santa Marta',
          descripcion_breve: 'Accidente de tránsito leve en esquina principal.',
          descripcion_ampliada:
            'Un motorizado sufrió una caída al evitar chocar con un taxi en la intersección.',
          fecha: '2025-05-15',
          imagen: '/accidente1.jpg'
        },
        {
          id_usuario: 2,
          lugar: 'Parque de los Novios',
          ciudad: 'Santa Marta',
          descripcion_breve: 'Robo reportado a turista extranjero.',
          descripcion_ampliada:
            'Se reportó que un turista fue despojado de su bolso por dos individuos en moto.',
          fecha: '2025-05-16',
          imagen:
            'https://imgs.search.brave.com/sKqDeFWcY3qjQL38X9SW08bIWfZnJLe_bGNA_xgiyz0/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly91cGxv/YWQud2lraW1lZGlh/Lm9yZy93aWtpcGVk/aWEvY29tbW9ucy85/LzkxLzIwMTlfU2Fu/dGFfTWFydGFfLV9F/c3RhdHVhX2RlX0Zy/YW5jaXNjb19kZV9Q/YXVsYV9TYW50YW5k/ZXJfZW5fZWxfUGFy/cXVlX2RlX0xvc19O/b3Zpb3MuanBn'
        }
      ],
      modalVisible: false,
      incidenteSeleccionado: null,
      indiceSeleccionado: null
    };
  },
  methods: {
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
    guardarCambios() {
     console.log(this.incidenteSeleccionado)
      this.cerrarModal();
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
</style>
