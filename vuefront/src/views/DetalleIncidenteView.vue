<template>
  <div class="detalle">
    <MenuPrincipal :nombre="nombre" :apellido="apellido" :idusuario="idusario" />

    <div class="vista-detalle">
      <h2>{{ lugar }}</h2>

      <img :src="imagen" alt="Imagen del incidente" />

      <div class="datos">
        <span>Ciudad: {{ ciudad }}</span>
        <span>Fecha: {{ fecha }}</span>
      </div>

      <p class="descripcion-ampliada">
        {{ descripcion }}
      </p>
    </div>

    <FooterPrincipal />
  </div>
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
  }
};
</script>

<style scoped>
.vista-detalle {
  max-width: 900px;
  margin: 40px auto;
  padding: 24px;
  background-color: #fff;
  border-radius: 16px;
  box-shadow: 0 6px 16px rgba(0, 0, 0, 0.1);
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
