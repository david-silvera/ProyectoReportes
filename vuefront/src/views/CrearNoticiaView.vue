<template>
 <MenuPrincipal :nombre="nombre" :apellido="apellido" :idusuario="idusuario" />
  <div class="vista-crear-noticia">

    <h2 class="titulo">Crear Noticia</h2>

    <form @submit.prevent="crearNoticia" class="form-noticia">
      <label>
        Lugar:
        <input v-model="form.lugar" type="text" required />
      </label>

      <label>
        Ciudad:
        <input v-model="form.ciudad" type="text" readonly />
      </label>

      <label>
        Descripción breve:
        <input v-model="form.descripcion_breve" type="text" required />
      </label>

      <label>
        Descripción ampliada:
        <textarea v-model="form.descripcion_ampliada" required></textarea>
      </label>

      <label>
        Fecha:
        <input v-model="form.fecha" type="date" required />
      </label>

      <label>
        URL de la imagen:
        <input v-model="form.imagen" type="url" />
      </label>

      <button type="submit">Crear Noticia</button>
    </form>

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
      form: {
        lugar: '',
        ciudad: 'Santa Marta',
        descripcion_breve: '',
        descripcion_ampliada: '',
        fecha: '',
        imagen: ''
      }
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
    crearNoticia() {
      const nuevaNoticia = {
        id_usuario: this.idusuario,
        ...this.form
      };
      console.log('Nueva noticia creada:', nuevaNoticia);
      alert('Noticia creada. (Por ahora solo en consola)');

      this.$router.push({
        name: 'vistaprincipal',
        query: {
          nombre: this.nombre,
          apellido: this.apellido,
          idusuario: this.idusuario
        }
      });
    }
  }
};
</script>

<style scoped>
.vista-crear-noticia {
  max-width: 600px;
  margin: 2rem auto;
  background: #fff;
  padding: 1.5rem;
  border-radius: 8px;
  font-family: Arial, sans-serif;
}

.titulo {
  text-align: center;
  color: #1e3a8a;
  margin-bottom: 1rem;
}

.form-noticia label {
  display: block;
  margin-bottom: 1rem;
  font-weight: bold;
  color: #1f2937;
}

.form-noticia input,
.form-noticia textarea {
  width: 100%;
  padding: 0.5rem;
  font-size: 1rem;
  margin-top: 0.3rem;
  border: 1px solid #ccc;
  border-radius: 4px;
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
}

button:hover {
  background-color: #c94b07;
}
</style>
