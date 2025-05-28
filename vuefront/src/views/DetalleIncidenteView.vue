<template>
   <MenuPrincipal :nombre="nombre" :apellido="apellido" :idusuario="idusario" />
  <div class="detalle">
    <video class="banner" autoplay loop muted playsinline>
        <source src="../assets/213102_tiny.mp4" type="video/mp4">
    </video>
    <div class="vista-detalle">
      <h2>{{ lugar }}</h2>

      <img :src="imagen" alt="Imagen del incidente" />

      <div class="datos">
        <span>Ciudad: {{ ciudad }}</span>
        <span>Fecha: {{ formatFecha(fecha) }}</span>
      </div>

      <p class="descripcion-ampliada">
        {{ descripcion }}
      </p>
    </div>
  </div>
      <FooterPrincipal />
</template>


<script>
import MenuPrincipal from '../components/MenuPrincipal.vue';
import FooterPrincipal from '../components/FooterPrincipal.vue';

export default {
  name: 'DetalleIncidente',
  components: { MenuPrincipal, FooterPrincipal },
  computed: {
    lugar() {
      return this.$route.query.lugar;
    },
    ciudad() {
      return this.$route.query.ciudad;
    },
    fecha() {
      return this.$route.query.fecha;
    },
    imagen() {
      return this.$route.query.imagen;
    },
    descripcion() {
      return this.$route.query.descripcion;
    },
    nombre() {
      return this.$route.query.nombre;
    },
    apellido() {
      return this.$route.query.apellido;
    },
    idusario() {
      return this.$route.query.idusuario;
    }
  },
  methods:{
     formatFecha(fechaISO) {
    const fecha = new Date(fechaISO);
    return fecha.toISOString().split('T')[0]; 
  },
  }
};
</script>

<style scoped>
* {
      margin: 0;
      padding: 0;
      box-sizing: border-box;
    }
  .detalle{
    border: 1px solid rgba(0, 0, 0, 0);
    position: relative;
  }
 .banner{
   position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  object-fit: cover;
  z-index: -1;
  pointer-events: none; 
}
.vista-detalle {
  max-width: 900px;
  margin: 40px auto;
  padding: 24px;
    background-color: rgba(255, 255, 255, 0.9); 
  border-radius: 16px;
  box-shadow: 0 6px 16px rgba(0, 0, 0, 0.15);
   object-fit: cover;
font-family: Arial, sans-serif;
}

.vista-detalle h2 {
  font-size: 28px;
  text-align: center;
  margin-bottom: 24px;
  color: #1e3a8a;
}

.vista-detalle img {
  width: 100%;
  height: 540px;
  object-fit: cover;
  border-radius: 12px;
  margin-bottom: 24px;
}

.vista-detalle .datos {
  display: flex;
  justify-content: space-between;
  margin-bottom: 16px;
  font-size: 16px;
  font-weight: 600;
}

.vista-detalle .datos span {
  color: #333;
}

.vista-detalle .descripcion-ampliada {
  font-size: 17px;
  line-height: 1.6;
  color: #444;
   word-wrap: break-word;
  overflow-wrap: break-word;
  white-space: pre-wrap;
}

</style>
