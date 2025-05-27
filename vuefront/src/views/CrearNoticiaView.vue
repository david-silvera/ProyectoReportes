<template>
  <MenuPrincipal :nombre="nombre" :apellido="apellido" :idusuario="idusuario" />

  <div class="cont">
   <video class="banner" autoplay loop muted playsinline>
      <source src="../assets/213102_tiny.mp4" type="video/mp4" />
    </video>
  <div class="vista-crear-noticia">

    <h2 class="titulo">Crear Noticia</h2>

    <form @submit.prevent="crearNoticia" class="form-noticia">
      <label>
        Lugar:
        <input v-model="lugar" type="text" required />
      </label>

      <label>
        Ciudad:
        <input v-model="ciudad" type="text" readonly />
      </label>

      <label>
        Descripción breve:
        <input v-model="descripcion_breve" type="text" required />
      </label>

      <label>
        Descripción ampliada:
        <textarea v-model="descripcion_ampliada" required></textarea>
      </label>

      <label>
        Fecha:
        <input v-model="fecha" type="date" required />
      </label>

      <label>
        URL de la imagen:
        <input v-model="imagen" type="url" />
      </label>

      <button type="submit">Crear Noticia</button>
    </form>

  </div>
  </div>
  <FooterPrincipal />
</template>

<script>
import MenuPrincipal from '../components/MenuPrincipal.vue';
import FooterPrincipal from '../components/FooterPrincipal.vue';

export default {
  name: 'CrearNoticiaView',
  components: { MenuPrincipal, FooterPrincipal },
  data() {
    return {
      lugar: '',
      ciudad: 'Santa Marta',
      descripcion_breve: '',
      descripcion_ampliada: '',
      fecha: '',
      imagen: ''
    };
  },
  computed: {
    nombre() {
      return this.$route.query.nombre || '';
    },
    apellido() {
      return this.$route.query.apellido || '';
    },
    idusuario() {
      return Number(this.$route.query.idusuario) || 0;
    }
  },
  methods: {
    async crearNoticia() {
      const nuevaNoticia = {
        usuarioId: this.idusuario,
        lugar: this.lugar,
        ciudad: this.ciudad,
        descripcionBreve: this.descripcion_breve,
        descripcionAmpliada: this.descripcion_ampliada,
        fecha: this.fecha,
        imagen: this.imagen
      };

      try {
        const response = await this.axios.post('http://localhost:5272/api/Noticia', nuevaNoticia);
        alert('Noticia creada exitosamente');
        console.log(response);

        this.$router.push({
          name: 'vistaprincipal',
          query: {
            nombre: this.nombre,
            apellido: this.apellido,
            idusuario: this.idusuario
          }
        });

      } catch (error) {
        alert('Error al crear la noticia. Revisa la consola.');
        console.error(error);
      }
    }
  }
};
</script>

<style scoped>
.vista-crear-noticia {
min-height: 600px;
max-width: 600px;
position: relative;
  margin: 2rem auto;
  background: rgba(255, 255, 255, 0.85);
  padding: 1.5rem;
  border-radius: 8px;
  font-family: Arial, sans-serif;
  overflow: hidden;
  z-index: 1;
}
.cont{
   position: relative;
   margin: 0;
   border: 1px solid white;
}
.banner {
 position: absolute;
  inset: 0; 
  width: 100%;
  height: 100%;
  object-fit: cover;
  z-index: 0;
  pointer-events: none;
  border-radius: 8px;
}

.titulo {
  text-align: center;
  color: #1e3a8a;
  margin-bottom: 1rem;
  position: relative;
  z-index: 1;
}

.form-noticia label {
  display: block;
  margin-bottom: 1rem;
  font-weight: bold;
  color: #1f2937;
  position: relative;
  z-index: 1;
}

.form-noticia input,
.form-noticia textarea {
  width: 100%;
  padding: 0.5rem;
  font-size: 1rem;
  margin-top: 0.3rem;
  border: 1px solid #ccc;
  border-radius: 4px;
  position: relative;
  z-index: 1;
}

.form-noticia textarea {
  resize: vertical;
  height: 100px;
}

button {
  background-color: #ea580c;
  color: white;
  border: none;
  padding: 0.75rem 1.5rem;
  font-size: 1rem;
  border-radius: 6px;
  cursor: pointer;
  width: 100%;
  position: relative;
  z-index: 1;
}

button:hover {
  background-color: #c94b07;
}
</style>

